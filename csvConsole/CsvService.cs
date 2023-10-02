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
    public void DisplayFile()
    {
        string path = "D:\\Coding\\EKE\\2APEC\\ITL-Singer\\CsvToolDev\\csvConsole\\test.csv";
        List<List<string>> rows = GetRows(path);
        List<List<string>> columns = GetColumns(rows);
        List<List<string>> unifiedRows = UnifyColumns(columns);

        foreach (List<string> records in unifiedRows)
        {
            foreach(string record in records)
            {
                Console.Write(record);
            }
            Console.Write("\n");
        }
    }

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

    public static List<List<string>> UnifyColumns(List<List<string>> columns)
    {
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
        return GetUnifiedRows(columns);
    }

    private static List<List<string>> GetUnifiedRows(List<List<string>> columns)
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
