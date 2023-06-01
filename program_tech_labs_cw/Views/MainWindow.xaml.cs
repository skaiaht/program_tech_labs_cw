using System.Configuration;
using System.Windows;
using program_tech_labs_cw.Providers;
using program_tech_labs_cw.Views.Pages;
using Wpf.Ui.Appearance;

namespace program_tech_labs_cw.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            DataContext = this;

            Watcher.Watch(this);

            InitializeComponent();

            Loaded += (_, _) =>
            {
                Watcher.Watch(this);
                RootNavigationView.Navigate(typeof(HomePage));
                ApplyDefaultTheme_OnLoad();
            };
        }
        
        private void ThemeSwitchButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (Theme.GetAppTheme() == ThemeType.Dark)
            {
                Theme.Apply(ThemeType.Light);
                ThemeSwitchButtonSymbol.Filled = true;
            }
            else
            {
                Theme.Apply(ThemeType.Dark);
                ThemeSwitchButtonSymbol.Filled = false;
            }
        }
    
        private static void ApplyDefaultTheme_OnLoad()
        {
            string? themeValue = ConfigurationManager.AppSettings.Get("Theme");
            switch (themeValue)
            {
                case "Dark":
                    Theme.Apply(ThemeType.Dark);
                    break;
                case "Light":
                    Theme.Apply(ThemeType.Light);
                    break;
                case "System":
                    if (Theme.GetSystemTheme() == SystemThemeType.Dark)
                    {
                        Theme.Apply(ThemeType.Dark);
                    }
                    else if (Theme.GetSystemTheme() == SystemThemeType.Light)
                    {
                        Theme.Apply(ThemeType.Light);
                    }
                    break;
                default:
                    Theme.Apply(ThemeType.HighContrast);
                    break;
            }
        }

        private void TitleBar_OnLoaded(object sender, RoutedEventArgs e)
        {
            TitleBar.Title += InscriptionProvider.AssemblyName + "_v" + InscriptionProvider.AssemblyVersion;
        }
    }
}