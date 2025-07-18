using System;

class Entry
{
    public string Prompt { get; private set; }
    public string Response { get; private set; }
    public string Date { get; private set; }
    public string Mood { get; private set; }

    public Entry(string prompt, string response, string date, string mood)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
        Mood = mood;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Response: {Response}");
        Console.WriteLine($"Mood: {Mood}");
    }
}