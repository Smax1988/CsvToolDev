using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace csvEditor
{
    public class Spreadsheet
    {
        /// <summary>
        /// Generates a WPF grid element. Columns and rows will be calculated
        /// based on window width and window height.
        /// </summary>
        /// <param name="windowWidth">Width of the window</param>
        /// <param name="windowHeight">Height of the window</param>
        /// <returns>Grid element</returns>
        public static Grid GenerateDataGrid(double windowWidth, double windowHeight)
        {
            var dataGrid = new Grid();

            // calc number of columns and number of rows
            int numberOfColumns = (int) Math.Floor(windowWidth / 70);
            int numberOfRows = (int) Math.Floor(windowHeight / 20);

            // add columns to grid
            for (int i = 0; i < numberOfColumns-1; i++)
                dataGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto, MinWidth = 70 });

            // add rows to grid
            for (int i = 0; i < numberOfRows-1; i++)
                dataGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto, MinHeight = 20 });

            // add textboxes in each grid element
            for (int row = 0; row < numberOfRows - 1; row++)
            {
                for (int column = 0; column < numberOfColumns - 1; column++)
                {
                    var border = new Border
                    {
                        BorderBrush = Brushes.Black,
                        BorderThickness = new Thickness(0.4)
                    };

                    var textBox = new TextBox
                    {
                        Tag = row.ToString() + column.ToString(),
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        VerticalAlignment = VerticalAlignment.Stretch,
                        Background = Brushes.White,
                        BorderThickness = new Thickness(0),
                        AcceptsReturn = true,
                        TextWrapping = TextWrapping.Wrap
                    };
                    border.Child = textBox;

                    Grid.SetRow(border, row);
                    Grid.SetColumn(border, column);

                    dataGrid.Children.Add(border);
                }
            }
            return dataGrid;
        }
    }
}
