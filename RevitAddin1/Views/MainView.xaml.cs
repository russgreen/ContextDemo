using Autodesk.Revit.UI;
using RevitAddin1.ViewModels;
using System;
using System.Windows;

namespace RevitAddin1.Views;
/// <summary>
/// Interaction logic for MainWindowView.xaml
/// </summary>
public partial class MainView : Window
{
    private readonly ViewModels.MainViewModel _viewModel;

    public MainView()
    {
        InitializeComponent();

        _viewModel = new ViewModels.MainViewModel();

        this.DataContext = _viewModel;

        //enable this line of code if XAML Behaviors is used
        //var _ = new Microsoft.Xaml.Behaviors.DefaultTriggerAttribute(typeof(Trigger), typeof(Microsoft.Xaml.Behaviors.TriggerBase), null);

        _viewModel.ClosingRequest += (sender, e) => this.Close();

    }

}
