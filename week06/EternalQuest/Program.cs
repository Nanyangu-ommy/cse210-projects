using System;
using System.Collections.Generic;

class Program
{
    // A list to store all goals
    static List<Goal> goals = new List<Goal>();
    static int totalScore = 0;

    static void Main()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine($"\nYou have {totalScore} points.\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");

            Console.Write("\nSelect a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoals(); break;
                case "3": RecordEvent(); break;
                case "4": SaveGoals(); break;
                case "5": LoadGoals(); break;
                case "6": running = false; break;
                default: Console.WriteLine("Invalid choice, please try again."); break;
            }
        }
    }

    // ✅ CreateGoal method
    static void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        string typeChoice = Console.ReadLine();

        Console.Write("Enter the name of your goal: ");
        string name = Console.ReadLine();

        Console.Write("Enter a short description: ");
        string description = Console.ReadLine();

        Console.Write("Enter the points associated with this goal: ");
        int points = int.Parse(Console.ReadLine());

        switch (typeChoice)
        {
            case "1":
                goals.Add(new SimpleGoal(name, description, points));
                Console.WriteLine("✅ Simple goal created successfully!");
                break;

            case "2":
                goals.Add(new EternalGoal(name, description, points));
                Console.WriteLine("✅ Eternal goal created successfully!");
                break;

            case "3":
                Console.Write("Enter the number of times this goal must be completed: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter the bonus points for completing it: ");
                int bonus = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                Console.WriteLine("✅ Checklist goal created successfully!");
                break;

            default:
                Console.WriteLine("⚠️ Invalid goal type.");
                break;
        }
    }

    // ✅ List all goals
    static void ListGoals()
    {
        Console.WriteLine("\nYour Goals:");
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals yet. Try creating one!");
        }
        else
        {
            int i = 1;
            foreach (Goal g in goals)
            {
                Console.Write($"{i}. ");
                g.DisplayProgress();
                i++;
            }
        }
    }

    // ✅ Record progress on a goal
    static void RecordEvent()
    {
        Console.WriteLine("\nSelect a goal to record:");
        ListGoals();
        Console.Write("Enter goal number: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < goals.Count)
        {
            int pointsEarned = goals[index].RecordEvent();
            totalScore += pointsEarned;
            Console.WriteLine($"You earned {pointsEarned} points! Total score: {totalScore}");
        }
        else
        {
            Console.WriteLine("⚠️ Invalid goal number.");
        }
    }

    // ✅ Save goals (simple text format)
    static void SaveGoals()
    {
        using (StreamWriter outputFile = new StreamWriter("goals.txt"))
        {
            outputFile.WriteLine(totalScore);
            foreach (Goal g in goals)
            {
                outputFile.WriteLine(g.GetStringRepresentation());
            }
        }
        Console.WriteLine("💾 Goals saved successfully!");
    }

    // ✅ Load goals from file
    static void LoadGoals()
    {
        if (File.Exists("goals.txt"))
        {
            string[] lines = File.ReadAllLines("goals.txt");
            goals.Clear();
            totalScore = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split("|");
                string type = parts[0];

                if (type == "SimpleGoal")
                {
                    goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3])));
                }
                else if (type == "EternalGoal")
                {
                    goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                }
                else if (type == "ChecklistGoal")
                {
                    goals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]),
                                                int.Parse(parts[4]), int.Parse(parts[5])));
                }
            }

            Console.WriteLine("📂 Goals loaded successfully!");
        }
        else
        {
            Console.WriteLine("⚠️ No saved goals found.");
        }
    }
}

