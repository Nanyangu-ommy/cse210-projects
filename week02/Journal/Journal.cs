using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        entries.Add(entry);
    }

    public void DisplayJournal()
    {
        foreach (Entry entry in entries)
        {
            Console.WriteLine($"{entry.Date} - {entry.Prompt}");
            Console.WriteLine(entry.Response);
            Console.WriteLine();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in entries)
            {
                // Just separate each part with "|"
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
        Console.WriteLine("Journal saved!");
    }

    public void LoadFromFile(string filename)
    {
        entries.Clear();

        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3) // make sure it's a full entry
                {
                    Entry entry = new Entry();
                    entry.Date = parts[0];
                    entry.Prompt = parts[1];
                    entry.Response = parts[2];
                    entries.Add(entry);
                }
            }
            Console.WriteLine("Journal loaded!");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
