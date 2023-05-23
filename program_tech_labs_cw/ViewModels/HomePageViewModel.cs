using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using CommunityToolkit.Mvvm.ComponentModel;

namespace program_tech_labs_cw.ViewModels;

public partial class HomePageViewModel : ObservableObject
{
    [ObservableProperty] private ObservableCollection<string> _stringCollection;
    [ObservableProperty] private ObservableCollection<double> _doubleCollection;

    public HomePageViewModel()
    {
        _stringCollection = GenerateStrings_OnInit();
        _doubleCollection = GenerateDoubles_OnInit();
    }

    private static ObservableCollection<string> GenerateStrings_OnInit()
    {
        Random random = new Random();
        ObservableCollection<string> strings = new ObservableCollection<string>();
        
        string[] adjectives = { "Red", "Green", "Blue" };
        string[] types = { "candy", "marshmello", "marmalade" };
        string[] objects = { "doll", "house", "car" };
        
        for (int i = 0; i < 10; i++)
        {
            strings.Add($"{random.Next(1,100)} {adjectives[random.Next(0,2)]} {types[random.Next(0,2)]} {objects[random.Next(0,2)]}");
        }

        return strings;
    }
    
    private static ObservableCollection<double> GenerateDoubles_OnInit()
    {
        Random random = new Random();
        ObservableCollection<double> doubles = new ObservableCollection<double>();
        
        for (int i = 0; i < 10; i++)
        {
            doubles.Add(random.NextDouble() * 100);
        }

        return doubles;
    }
}