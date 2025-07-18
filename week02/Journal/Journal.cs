using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    private List<Entry> entries;
    private readonly List<string> prompts;
    private Random random;

    public Journal()
    {
        entries = new List<Entry>();
        random = new Random();
        prompts = new List<string>
        {
            "Who was the most interesting person you interacted with today?",
            "What was the best moment of your day?",
            "How did you see positivity in your life today?",
            "What was the strongest emotion you felt today?",
            "If you could relive one moment from today, what would it be?",
            "What did you learn about yourself today?",
            "What was a challenge you faced today and how did you overcome it?"
        };
    }

    public void WriteNewEntry()
    {
        string prompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        
        Console.Write("How would you describe your mood today?: ");
        string mood = Console.ReadLine();
        
        Entry entry = new Entry(prompt, response, DateTime.Now.ToString("yyyy-MM-dd"), mood);
        entries.Add(entry);
        Console.WriteLine("Entry added successfully!");
    }

    public void DisplayJournal()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("\nNo entries in the journal.");
            return;
        }

        Console.WriteLine("\nJournal Entries:");
        foreach (Entry entry in entries)
        {
            Console.WriteLine("------------------------");
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine("Date,Prompt,Response,Mood");
            foreach (Entry entry in entries)
            {
                string escapedPrompt = $"\"{entry.Prompt.Replace("\"", "\"\"")}\"";
                string escapedResponse = $"\"{entry.Response.Replace("\"", "\"\"")}\"";
                string escapedMood = $"\"{entry.Mood.Replace("\"", "\"\"")}\"";
                writer.WriteLine($"{entry.Date},{escapedPrompt},{escapedResponse},{escapedMood}");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        entries.Clear();
        try
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                
                reader.ReadLine();
                
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = ParseCsvLine(line);
                    if (parts.Length == 4)
                    {
                        Entry entry = new Entry(parts[1], parts[2], parts[0], parts[3]);
                        entries.Add(entry);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
        }
    }

    private string[] ParseCsvLine(string line)
    {
        List<string> result = new List<string>();
        bool inQuotes = false;
        string field = "";
        
        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];
            
            if (c == '"' && line[i + 1] == '"')
            {
                field += '"';
                i++;
            }
            else if (c == '"')
            {
                inQuotes = !inQuotes;
            }
            else if (c == ',' && !inQuotes)
            {
                result.Add(field);
                field = "";
            }
            else
            {
                field += c;
            }
        }
        
        result.Add(field);
        return result.ToArray();
    }

    public void ShowStatistics()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("\nNo entries to analyze.");
            return;
        }

        Dictionary<string, int> moodCounts = new Dictionary<string, int>();
        foreach (Entry entry in entries)
        {
            if (!moodCounts.ContainsKey(entry.Mood))
                moodCounts[entry.Mood] = 0;
            moodCounts[entry.Mood]++;
        }

        Console.WriteLine("\nJournal Statistics:");
        Console.WriteLine($"Total entries: {entries.Count}");
        Console.WriteLine("Mood distribution:");
        foreach (var mood in moodCounts)
        {
            Console.WriteLine($"  {mood.Key}: {mood.Value} entries");
        }
        
        if (entries.Count > 0)
        {
            Console.WriteLine($"First entry: {entries[0].Date}");
            Console.WriteLine($"Last entry: {entries[entries.Count - 1].Date}");
        }
    }
}