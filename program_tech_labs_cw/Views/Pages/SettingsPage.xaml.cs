using System.Threading;
using System.Windows;
using program_tech_labs_cw.Models;
using program_tech_labs_cw.Providers;
using Wpf.Ui.Appearance;

namespace program_tech_labs_cw.Views.Pages;

public partial class SettingsPage
{
    public SettingsPage()
    {
        InitializeComponent();

        Loaded += (_, _) =>
        {
            DefaultThemeRadioButton_OnLoad();
            DefaultColorRadioButton_OnLoad();
            Accent.ApplySystemAccent();
            Theme.GetAppTheme();
            AppInfoTextBlock.Text = InscriptionProvider.AssemblyName + " " + InscriptionProvider.AssemblyVersion;
        };
    }

    private void DefaultThemeRadioButton_OnLoad()
    {
        string themeValue = FourthTaskModel.GetAppSetting("Theme");
        switch (themeValue)
        {
            case "Dark":
                DarkThemeRadioButton.IsChecked = true;
                break;
            case "Light":
                LightThemeRadioButton.IsChecked = true;
                break;
            case "System":
                SystemThemeRadioButton.IsChecked = true;
                break;
            default:
                return;
        }
    }
    
    private void DefaultColorRadioButton_OnLoad()
    {
        string colorValue = FourthTaskModel.GetAppSetting("Color");
        switch (colorValue)
        {
            case "ff0000":
                RedColorRadioButton.IsChecked = true;
                break;
            case "00ff00":
                GreenColorRadioButton.IsChecked = true;
                break;
            case "0000ff":
                BlueColorRadioButton.IsChecked = true;
                break;
            default:
                return;
        }
    }

    private void ChangeDefaultTheme_OnClick(object sender, RoutedEventArgs e)
    {
        if (Equals(sender, DarkThemeRadioButton))
        {
            FourthTaskModel.SetAppSetting("Theme", "Dark");
            Theme.Apply(ThemeType.Dark);
        }
        else if (Equals(sender, LightThemeRadioButton))
        {
            FourthTaskModel.SetAppSetting("Theme", "Light");
            Theme.Apply(ThemeType.Light);
        }
        else if (Equals(sender, SystemThemeRadioButton)) 
        {
            FourthTaskModel.SetAppSetting("Theme", "System");
            if (Theme.GetSystemTheme() == SystemThemeType.Dark)
            {
                Theme.Apply(ThemeType.Dark);
            }
            else if (Theme.GetSystemTheme() == SystemThemeType.Light)
            {
                Theme.Apply(ThemeType.Light);
            }
        }
    }

    private void ChangeDefaultColor_OnClick(object sender, RoutedEventArgs e)
    {
        if (Equals(sender, RedColorRadioButton))
        {
            FourthTaskModel.SetAppSetting("Color", "ff0000");
        }
        else if (Equals(sender, GreenColorRadioButton))
        {
            FourthTaskModel.SetAppSetting("Color", "00ff00");
        }
        else if (Equals(sender, BlueColorRadioButton)) 
        {
            FourthTaskModel.SetAppSetting("Color", "0000ff");
        }
    }
}
