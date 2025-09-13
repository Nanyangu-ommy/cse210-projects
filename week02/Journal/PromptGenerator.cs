using System;
using System.Collections.Generic;

class PromptGenerator
{
    private List<string> prompts;
    private Random random;

    public PromptGenerator()
    {
        prompts = new List<string>
        {
            "What are you grateful for today?",
            "what is a challenging moment you faced today?",
            "What is a goal you want to achieve this month?",
            "How did you see the hand of the Lord in your life today.",
            "Did you meet someone new today?"
        };
        random = new Random();
    }

    public string GetRandomPrompt()
    {
        int index = random.Next(prompts.Count);
        return prompts[index];
    }
}


