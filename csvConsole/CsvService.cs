using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace csvConsole;

public class CsvService
{
    /// <summary>
    /// Writes the content of a .csv file to the console.
    /// </summary>
    public void DisplayFile()
    {
        string path = "D:\\Coding\\EKE\\2APEC\\ITL-Singer\\CsvToolDev\\csvConsole\\test.csv";
        List<List<string>> rows = GetRows(path);
        List<List<string>> unifiedRows = UnifyRows(rows);

        foreach (List<string> records in unifiedRows)
        {
            foreach(string record in records)
            {
                Console.Write(record);
            }
            Console.Write("\n");
        }
    }

    /// <summary>
    /// Reads a .csv file and saves the content as single rows in a List<List<string>>.
    /// It also removes the separator
    /// </summary>
    /// <param name="csvFilePath"></param>
    /// <returns></returns>
    private static List<List<string>> GetRows(string csvFilePath)
    {
        List<List<string>> rows = new List<List<string>>();
        string[] records = File.ReadAllLines(csvFilePath);

        foreach (string record in records)
        {
            List<string> words = new List<string>(record.Split(','));
            rows.Add(words);
        }

        return rows;
    }


    /// <summary>
    /// Adds empty spaces to the end of each element of a column until each element
    /// has a length of the longest item from that column + 2 (to get a gap between columns).
    /// </summary>
    /// <param name="rows">All rows with all its elements</param>
    /// <returns>all rows with all its elements having the same string length of the longest item + 2</returns>
    public static List<List<string>> UnifyRows(List<List<string>> rows)
    {
        List<List<string>> columns = GetColumns(rows);

        foreach (List<string> column in columns)
        {
            int longestItemLength = column.Aggregate("", (max, cur) => max.Length > cur.Length ? max : cur).Length + 2; // add two more space for a little gap between columns

            // loop through each column
            for (int j = 0; j < column.Count; j++)
            {
                // loop through each item of column
                for (int i = 0; i < column.Count; i++)
                {
                    while (column[i].Length <= longestItemLength)
                    {
                        column[i] += " ";
                    }
                }
            }
        }
        return SwapInnerAndOuterList(columns);
    }

    /// <summary>
    /// Gets the Columns from rows
    /// </summary>
    /// <param name="rows">List of all rows</param>
    /// <returns>List of all columns</returns>
    private static List<List<string>> GetColumns(List<List<string>> rows)
    {
        int maxWords = rows.Max(record => record.Count);

        List<List<string>> columns = new List<List<string>>();
        for (int i = 0; i < maxWords; i++)
        {
            List<string> column = new List<string>();
            foreach (List<string> record in rows)
            {
                if (i < record.Count)
                {
                    column.Add(record[i]);
                }
                else
                {
                    column.Add(""); // Fill with empty string if there are no more words in the record
                }
            }
            columns.Add(column);
        }

        return columns;
    }

    /// <summary>
    /// Basically swaps the inner List with the outer List. 
    /// Pass the list of columns and get the list of rows
    /// </summary>
    /// <param name="columns">List of all columns with all strings of each column</param>
    /// <returns>List of all rows with all strings for each row</returns>
    private static List<List<string>> SwapInnerAndOuterList(List<List<string>> columns)
    {
        //basically swap inner and outer List
        int numRows = columns.Count;
        int numCols = columns[0].Count;

        List<List<string>> unifiedRows = new List<List<string>>();
        for (int i = 0; i < numCols; i++)
        {
            List<string> row = new List<string>();
            for (int j = 0; j < numRows; j++)
            {
                row.Add(columns[j][i]);
            }
            unifiedRows.Add(row);
        }
        return unifiedRows;
    }
}
