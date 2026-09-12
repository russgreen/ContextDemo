using Autodesk.Revit.UI;
using RevitAddin1.ViewModels;
using System;
using System.Windows;
using System.Windows.Data;

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

        // Built here in code, not in XAML: the compiled BAML for this window would
        // otherwise bake in a reference to Syncfusion.SfGrid.WPF that WPF's
        // AssemblyLoadContext-unaware XAML resolver can mis-resolve to a different
        // add-in's isolated copy (see the comment in MainView.xaml). Constructing the
        // type directly in C# resolves it through the normal, correctly-isolated CLR
        // assembly loader instead.
        var sfDataGrid = new Syncfusion.UI.Xaml.Grid.SfDataGrid
        {
            AutoGenerateColumns = true
        };
        sfDataGrid.SetBinding(Syncfusion.UI.Xaml.Grid.SfDataGrid.ItemsSourceProperty, new Binding(nameof(MainViewModel.Views)));
        sfDataGridHost.Content = sfDataGrid;

        //enable this line of code if XAML Behaviors is used
        //var _ = new Microsoft.Xaml.Behaviors.DefaultTriggerAttribute(typeof(Trigger), typeof(Microsoft.Xaml.Behaviors.TriggerBase), null);

        _viewModel.ClosingRequest += (sender, e) => this.Close();

    }

}
