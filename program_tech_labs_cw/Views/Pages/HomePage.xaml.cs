using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Controls;
using program_tech_labs_cw.ViewModels;
using Wpf.Ui.Controls.Navigation;

namespace program_tech_labs_cw.Views.Pages;

public partial class HomePage : INavigableView<HomePageViewModel>
{
    public HomePageViewModel ViewModel { get; }
    
    public HomePage(HomePageViewModel viewModel)
    {
        ViewModel = viewModel;
        DataContext = this;
        
        InitializeComponent();
    }
    
    public HomePage()
    {
        ViewModel = new HomePageViewModel();
        DataContext = this;
        
        InitializeComponent();
    }

    private void DataGrid_OnCellEditEnding(object? sender, DataGridCellEditEndingEventArgs e)
    {
        
    }
}