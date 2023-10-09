using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using csvEditor;

namespace csvWPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private List<string> Rows = new List<string>();
    private ObservableCollection<Columns> Table = new();

    public MainWindow()
    {
        InitializeComponent();

        DataGrid.ItemsSource = Table;
    }

    private void SaveFileAs_Click(object sender, RoutedEventArgs e)
    {

    }
}

public class Columns
{

    public string A { get; set; } = string.Empty;
    public string B { get; set; } = string.Empty;
    public string C { get; set; } = string.Empty;
    public string D { get; set; } = string.Empty;
    public string E { get; set; } = string.Empty;

}