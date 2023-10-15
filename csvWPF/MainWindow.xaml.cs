using csvEditor;
using csvEditor.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace csvWPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private ObservableCollection<Columns> Table = new ObservableCollection<Columns>();

    public MainWindow()
    {
        InitializeComponent();
        DataGrid.ItemsSource = Table;
        Table.Add(new Columns());
    }

    private void SaveFileAs_Click(object sender, RoutedEventArgs e)
    {
        Spreadsheet.SaveFileAs(Table);
    }
}