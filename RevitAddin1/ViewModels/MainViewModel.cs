using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Reflection;
using System.Windows.Documents;
using System.Windows.Input;
using Autodesk.Revit.DB;
using Nice3point.Revit.Extensions;
using System.Collections.Generic;

namespace RevitAddin1.ViewModels;

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
        WindowTitle = $"RevitAddin1 {informationVersion} ({App.RevitDocument.Title})";

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
