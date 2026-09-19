using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("There are no entries in the journal.");
            Console.WriteLine();
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string fileName)
    {
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.GetFileString());
            }
        }

        Console.WriteLine("Journal saved successfully.");
        Console.WriteLine();
    }

    public void LoadFromFile(string fileName)
    {
        if (!File.Exists(fileName))
        {
            Console.WriteLine("File does not exist.");
            Console.WriteLine();
            return;
        }

        _entries.Clear();

        string[] lines = File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            Entry entry = Entry.FromFileString(line);
            _entries.Add(entry);
        }

        Console.WriteLine("Journal loaded successfully.");
        Console.WriteLine();
    }
}