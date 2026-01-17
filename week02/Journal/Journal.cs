using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            Console.WriteLine(entry.GetDisplayText());
        }
    }

    public void SaveToFile(string filename)
    {
        // Build the saves directory path
        string savesDirectory = Path.Combine(Directory.GetCurrentDirectory(), "saves");

        // Ensure the directory exists
        Directory.CreateDirectory(savesDirectory);

        // Build the full file path
        string filePath = Path.Combine(savesDirectory, filename);

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine(entry.ToFileString());
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();

        // Build the saves directory path
        string savesDirectory = Path.Combine(Directory.GetCurrentDirectory(), "saves");
        string filePath = Path.Combine(savesDirectory, filename);

        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filePath);
        foreach (string line in lines)
        {
            string[] parts = line.Split("|");
            Entry entry = new Entry(parts[0], parts[1], parts[2]);
            _entries.Add(entry);
        }
    }
}

