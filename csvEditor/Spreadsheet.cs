using csvEditor.Models;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace csvEditor;

public class Spreadsheet
{
    public static void SaveFileAs(ObservableCollection<Columns>table)
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "CSV file (*.csv)|*.csv";
        saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        if (saveFileDialog.ShowDialog() == true)
        {
            string filePath = saveFileDialog.FileName;
            ConvertToCsv(table, filePath);
        }
    }
    
    private static void ConvertToCsv(ObservableCollection<Columns> table, string filePath)
    {
        using (StreamWriter sw = new StreamWriter(filePath))
        {
            foreach (var row in table)
            {
                if (!string.IsNullOrEmpty(row.A) ||
                    !string.IsNullOrEmpty(row.B) || 
                    !string.IsNullOrEmpty(row.C) || 
                    !string.IsNullOrEmpty(row.D) || 
                    !string.IsNullOrEmpty(row.E))
                {
                    sw.WriteLine($"{row.A},{row.B},{row.C},{row.D},{row.E}");
                }
            }
        }
    }
}
