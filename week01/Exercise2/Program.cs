using System;
using System.Formats.Asn1;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("What is your grade percentage? ");
        string grade = Console.ReadLine();
        int percent = int.Parse(grade);

        string letter = "";

        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }
        Console.WriteLine("your grade is: " + letter);

        if (percent >= 70)
        {
            Console.WriteLine("Congratulations You have Passed!");
        }
        else
        {
            Console.WriteLine("Sorry you have failed!");
        }

    }
        
}