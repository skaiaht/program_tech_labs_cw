using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using program_tech_labs_cw.Models;
using SkiaSharp;

namespace program_tech_labs_cw.ViewModels;

public partial class HomePageViewModel : ObservableObject
{
    [ObservableProperty] private ObservableCollection<StringItem> _stringItemsCollection;
    [ObservableProperty] private ObservableCollection<DoubleItem> _doubleItemsCollection;
    [ObservableProperty] private ObservableCollection<RowSeries<double>> _doubleItemsSeries;

    public HomePageViewModel()
    {
        _stringItemsCollection = GenerateStrings_OnInit();
        _doubleItemsCollection = GenerateDoubles_OnInit();
        
        _doubleItemsSeries = GetCollection(SKColor.Parse(FourthTaskModel.GetAppSetting("Color")), 1);
    }
    
    public void Update(SKColor color, double multiplyFactor)
    {
        DoubleItemsSeries = GetCollection(color, multiplyFactor);
    }

    public void HotReload(SKColor color, double multiplyFactor)
    {
        StringItemsCollection = GenerateStrings_OnInit();
        DoubleItemsCollection = GenerateDoubles_OnInit();
        Update(color, multiplyFactor);
    }
    
    public void HotClear(SKColor color, double multiplyFactor)
    {
        StringItemsCollection = new ObservableCollection<StringItem>();
        DoubleItemsCollection = new ObservableCollection<DoubleItem>();
        Update(color, multiplyFactor);
    }
    
    private static ObservableCollection<StringItem> GenerateStrings_OnInit()
    {
        Random random = new Random();
        ObservableCollection<StringItem> strings = new ObservableCollection<StringItem>();
        
        string[] sizes = { "Huge", "Big", "Medium", "Small", "Tiny" };
        string[] adjectives = { "red", "green", "blue", "yellow", "purple" };
        string[] types = { "candy", "marshmello", "marmalade", "cookie", "ice cream" };
        string[] objects = { "doll", "house", "car", "teddy bear", "ball" };
        
        for (int i = 0; i < 10; i++)
        {
            strings.Add(new StringItem
            {
                Value = $"{sizes[random.Next(0,4)]} " +
                        $"{adjectives[random.Next(0,4)]} " +
                        $"{types[random.Next(0,4)]} " +
                        $"{objects[random.Next(0,4)]}"
            });
        }

        return strings;
    }

    private static ObservableCollection<DoubleItem> GenerateDoubles_OnInit()
    {
        Random random = new Random();
        ObservableCollection<DoubleItem> observableCollection = new ObservableCollection<DoubleItem>();
        for (int i = 0; i < 10; i++)
        {
            observableCollection.Add(new DoubleItem {Value = random.NextDouble() * 100});
        }

        return observableCollection;
    }

    private static IEnumerable<double> ToValuesList(IEnumerable<DoubleItem> collection, double multiplyFactor)
    {
        return collection.Select(variableDoubleItem => variableDoubleItem.Value * multiplyFactor).ToList();
    }

    private ObservableCollection<RowSeries<double>> GetCollection(SKColor color, double multiplyFactor)
    {
        return new ObservableCollection<RowSeries<double>>
        {
            new()
            {
                Name = "Double series",
                Values = ToValuesList(DoubleItemsCollection, multiplyFactor),
                Fill = new SolidColorPaint(color)
            }
        };
    }
    
    
}