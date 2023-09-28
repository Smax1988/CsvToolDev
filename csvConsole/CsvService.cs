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

        UnifyColumns(columns);
    }

    private List<List<string>> GetRows(string csvFilePath)
    {
        List<List<string>> recordsAndWords = new List<List<string>>();
        string[] records = File.ReadAllLines(csvFilePath);

        foreach (string record in records)
        {
            List<string> words = new List<string>(record.Split(','));
            recordsAndWords.Add(words);
        }

        return recordsAndWords;
    }

    private List<List<string>> GetColumns(List<List<string>> recordsAndWords)
    {
        int maxWords = recordsAndWords.Max(record => record.Count);

        List<List<string>> columns = new List<List<string>>();
        for (int i = 0; i < maxWords; i++)
        {
            List<string> column = new List<string>();
            foreach (List<string> record in recordsAndWords)
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

    public void UnifyColumns(List<List<string>> columns)
    {
        foreach (List<string> column in columns)
        {
            UnifyColumn(column);
        }
    }

    public void UnifyColumn(List<string> column)
    {
        int longestItemLength = column.Aggregate("", (max, cur) => max.Length > cur.Length ? max : cur).Length;

        // loop through each column
        for (int j = 0; j < column.Count; j++)
        {
            // loop through each item of column
            for (int i = 0; i < longestItemLength; i++)
            {
                while (column[i].Length < longestItemLength)
                {
                    column[i] += " ";
                }
            }
        }
    }
}
