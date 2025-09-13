using System;

class Entry
{
    public string Date;
    public string Prompt;
    public string Response;

    public void Display()
    {
        Console.WriteLine($"{Date} - {Prompt}");
        Console.WriteLine($"Response: {Response}");
        Console.WriteLine();
    }
}
