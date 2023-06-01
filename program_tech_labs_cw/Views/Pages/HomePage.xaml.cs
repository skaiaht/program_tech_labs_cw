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

    private void HeapSort_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            var button = (Button)sender;
            string? tag = button.Tag.ToString();
            Worker worker;
            switch (tag)
            {
                case "StringItem":
                    ThirdTaskModel.Log(ThirdTaskModel.LogLevel.Info, "Heap sorting start...");
                    ThirdTaskModel.Log(ThirdTaskModel.LogLevel.Info, $"Collection items amount: {ViewModel.StringItemsCollection.Count} items.");
                    ThirdTaskModel.Log(ThirdTaskModel.LogLevel.Info, $"Collection items data type: {ViewModel.StringItemsCollection[0].Type}.");
                    worker = new Worker(ViewModel.StringItemsCollection, DataType.String);
                    worker.Sort(SortType.HeapSort);
                    break;
                case "DoubleItem":
                    ThirdTaskModel.Log(ThirdTaskModel.LogLevel.Info, "Heap sorting start...");
                    ThirdTaskModel.Log(ThirdTaskModel.LogLevel.Info, $"Collection items amount: {ViewModel.DoubleItemsCollection.Count} items.");
                    ThirdTaskModel.Log(ThirdTaskModel.LogLevel.Info, $"Collection items data type: {ViewModel.DoubleItemsCollection[0].Type}.");
                    worker = new Worker(ViewModel.DoubleItemsCollection, DataType.Double);
                    worker.Sort(SortType.HeapSort);
                    break;
                default:
                    return;
            }
            ThirdTaskModel.Log(ThirdTaskModel.LogLevel.Trace, "==================================================");
        
            ViewModel.Update(SKColor.Parse(FourthTaskModel.GetAppSetting("Color")), MultiplyFactor.Value ?? 1);
        }
        catch (Exception exception)
        {
            ThirdTaskModel.Log(ThirdTaskModel.LogLevel.Error, $"BUTTON ACTION FAILED: {exception}");
        }
    }
    
    private void SelectionSort_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            var button = (Button)sender;
            string? tag = button.Tag.ToString();
            Worker worker;
            switch (tag)
            {
                case "StringItem":
                    ThirdTaskModel.Log(ThirdTaskModel.LogLevel.Info, "Selection sorting start...");
                    ThirdTaskModel.Log(ThirdTaskModel.LogLevel.Info, $"Collection items amount: {ViewModel.StringItemsCollection.Count} items.");
                    ThirdTaskModel.Log(ThirdTaskModel.LogLevel.Info, $"Collection items data type: {tag}.");
                    worker = new Worker(ViewModel.StringItemsCollection, DataType.String);
                    worker.Sort(SortType.SelectionSort);
                    break;
                case "DoubleItem":
                    ThirdTaskModel.Log(ThirdTaskModel.LogLevel.Info, "Selection sorting start...");
                    ThirdTaskModel.Log(ThirdTaskModel.LogLevel.Info, $"Collection items amount: {ViewModel.DoubleItemsCollection.Count} items.");
                    ThirdTaskModel.Log(ThirdTaskModel.LogLevel.Info, $"Collection items data type: {tag}.");
                    worker = new Worker(ViewModel.DoubleItemsCollection, DataType.Double);
                    worker.Sort(SortType.SelectionSort);
                    break;
                default:
                    return;
            }
            ThirdTaskModel.Log(ThirdTaskModel.LogLevel.Trace, "==================================================");
        
            ViewModel.Update(SKColor.Parse(FourthTaskModel.GetAppSetting("Color")), MultiplyFactor.Value ?? 1);
        }
        catch (Exception exception)
        {
            ThirdTaskModel.Log(ThirdTaskModel.LogLevel.Error, $"BUTTON ACTION FAILED: {exception}");
        }
    }
}