using System;
using System.Collections.Generic;

namespace ScriptureMemorization
{
    
    class Word
    {
        public string Text { get; private set; }
        public bool IsHidden { get; private set; }

        public Word(string text)
        {
            Text = text;
            IsHidden = false;
        }

        public void Hide() => IsHidden = true;
        public string GetDisplayText() => IsHidden ? new string('_', Text.Length) : Text;
    }

    
    class Reference
    {
        public string Book { get; private set; }
        public int Chapter { get; private set; }
        public int Verse { get; private set; }

        public Reference(string book, int chapter, int verse)
        {
            Book = book;
            Chapter = chapter;
            Verse = verse;
        }

        public string GetDisplayText() => $"{Book} {Chapter}:{Verse}";
    }

    class Scripture
    {
        private List<Word> words;
        public Reference Reference { get; private set; }

        public Scripture(Reference reference, string verseText)
        {
            Reference = reference;
            words = new List<Word>();
            foreach (string w in verseText.Split(' '))
            {
                words.Add(new Word(w));
            }
        }

        public void HideRandomWords(int count)
        {
            Random rand = new Random();
            for (int i = 0; i < count; i++)
            {
                int index = rand.Next(words.Count);
                words[index].Hide();
            }
        }

        public bool IsFullyHidden()
        {
            foreach (var w in words)
            {
                if (!w.IsHidden)
                    return false;
            }
            return true;
        }

        public void Display()
        {
            foreach (var w in words)
            {
                Console.Write(w.GetDisplayText() + " ");
            }
            Console.WriteLine($"\n\n{Reference.GetDisplayText()}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            Reference reference = new Reference("John", 3, 16);
            string verseText = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";
            Scripture scripture = new Scripture(reference, verseText);

            while (true)
            {
                Console.Clear();
                scripture.Display();

                if (scripture.IsFullyHidden())
                {
                    Console.WriteLine("\nAll words are hidden. Program ending.");
                    break;
                }

                Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
                string input = Console.ReadLine();
                if (input.ToLower() == "quit") break;

                scripture.HideRandomWords(3);
            }
        }
    }
}
