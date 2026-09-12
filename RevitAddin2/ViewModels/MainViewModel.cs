using Autodesk.Revit.DB;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Nice3point.Revit.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Input;

namespace RevitAddin2.ViewModels;

internal partial class MainViewModel : BaseViewModel
{
    public string WindowTitle { get; private set; }

    [ObservableProperty]
    private bool _isCommandEnabled = true;

    [ObservableProperty]
    private List<View> _views = new();

    public MainViewModel()
    {
        var informationVersion = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
        WindowTitle = $"RevitAddin2 {informationVersion} ({App.RevitDocument.Title})";

        Views = App.RevitDocument.CollectElements()
           .Instances()
           .OfCategory(BuiltInCategory.OST_Views)
           .Cast<View>()
           .ToList();
    }

    [RelayCommand]
    private void Run()
    {
        //DO STUFF HERE
        IsCommandEnabled = false;
    }
}
