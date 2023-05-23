using System.Windows;
using program_tech_labs_cw.Models;
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
}
