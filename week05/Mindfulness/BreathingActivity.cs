using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity() 
        : base("Breathing Activity", "This activity will help you relax by guiding you through slow breathing.") { }

    public override void Run()
    {
        DisplayStartingMessage();

        DateTime end = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < end)
        {
            Console.Write("\nBreathe in... ");
            ShowCountdown(4);
            Console.Write("\nNow breathe out... ");
            ShowCountdown(6);
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}
