using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using program_tech_labs_cw.Models;
using program_tech_labs_cw.ViewModels;
using SkiaSharp;
using Wpf.Ui.Controls.Navigation;

namespace program_tech_labs_cw.Views.Pages;

public partial class HomePage : INavigableView<HomePageViewModel>
{
    public HomePageViewModel ViewModel { get; set; }

    public HomePage()
    {
        ViewModel = new HomePageViewModel();
        DataContext = this;
        
        InitializeComponent();
    }

    private void DataGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ViewModel.Update(SKColor.Parse(FourthTaskModel.GetAppSetting("Color")), MultiplyFactor.Value ?? 1);
    }
}