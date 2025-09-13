using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        int choice = 0;
        while (choice != 5)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                if (choice == 1)
                {
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();

                    Entry newEntry = new Entry();
                    newEntry.Date = DateTime.Now.ToShortDateString();
                    newEntry.Prompt = prompt;
                    newEntry.Response = response;

                    journal.AddEntry(newEntry);
                }
                else if (choice == 2)
                {
                    journal.DisplayJournal();
                }
                else if (choice == 3)
                {
                    Console.Write("Enter filename : ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                }
                else if (choice == 4)
                {
                    Console.Write("Enter filename : ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                }
                else if (choice == 5)
                {
                    Console.WriteLine("Goodbye!");
                }
                else
                {
                    Console.WriteLine("Try again.");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
        }
    }
}
