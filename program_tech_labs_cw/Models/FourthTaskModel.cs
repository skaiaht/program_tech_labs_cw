// Запись в бинарный файл всех пользовательских настроек и считывание их оттуда. 

using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using program_tech_labs_cw.Providers;

namespace program_tech_labs_cw.Models;

public class FourthTaskModel
{
    public static DirectoryInfo GetDirectory(string dialogDescription)
    {
        if (string.IsNullOrEmpty(dialogDescription))
        {
            dialogDescription = InscriptionProvider.DirectorySelect;
        }
        FolderBrowserDialog folderBrowserDialog = new()
        {
            Description = dialogDescription,
            UseDescriptionForTitle = true
        };
        folderBrowserDialog.ShowDialog();
        
        if (string.IsNullOrEmpty(folderBrowserDialog.SelectedPath))
            throw new InvalidDataException(InscriptionProvider.DirectoryNotSpecified);

        DirectoryInfo directoryInfo = new(folderBrowserDialog.SelectedPath);

        if (!directoryInfo.Exists)
            throw new DirectoryNotFoundException($"{InscriptionProvider.DirectoryNotFound}: {directoryInfo.FullName}");

        return directoryInfo;
    }

    public static FileInfo GetFile(string dialogTitle, string fileExtension)
    {
        if (string.IsNullOrEmpty(dialogTitle))
        {
            dialogTitle = InscriptionProvider.FileSelect;
        }
        OpenFileDialog dialog = new()
        {
            DefaultExt = $".{fileExtension}",
            Filter = $"{fileExtension.ToUpper()} Files (*.{fileExtension})|*.{fileExtension}",
            Multiselect = true,
            Title = dialogTitle
        };
        
        dialog.ShowDialog();
        
        if (string.IsNullOrEmpty(dialog.FileName))
            throw new InvalidDataException(InscriptionProvider.FileNotSpecified);
        
        FileInfo fileInfo = new(dialog.FileName);

        if (!fileInfo.Exists)
            throw new FileNotFoundException($"{InscriptionProvider.FileNotFound}: {fileInfo.FullName}");

        return fileInfo;
    }
    
    public static void SetAppSetting(string? key, string? value)
    {
        try
        {
            if (value is null or "")
            {
                throw new InvalidDataException(InscriptionProvider.SettingsValueError);
            }
            if (key is null or "")
            {
                throw new InvalidDataException(InscriptionProvider.SettingsKeyError);
            }
            
            Configuration? configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationCollection? settings = configFile.AppSettings.Settings;

            if (settings[key] == null)
            {
                settings.Add(key, value);
            }
            else
            {
                settings[key].Value = value;
            }
            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
        }
        catch (Exception)
        {
            throw new InvalidOperationException(InscriptionProvider.SettingsWriteError);
        }
    }
    
    public static string GetAppSetting(string? key)
    {  
        try  
        {  
            var appSettings = ConfigurationManager.AppSettings;
            string result = appSettings[key] ?? throw new InvalidOperationException();
            return result;
        }  
        catch (Exception)
        {
            throw new InvalidOperationException(InscriptionProvider.SettingsReadError);
        }  
    }
}