using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create some videos
        Video video1 = new Video("C# programing", "bro code", 600);
        video1.AddComment(new Comment("Lisa", "Great explanation, thank you!"));
        video1.AddComment(new Comment("Omega", "Can you make one on classes?"));
        video1.AddComment(new Comment("Jonathan", "This was very helpful."));

        Video video2 = new Video("Top 10 Programming Languages", "TechwithOmmy", 900);
        video2.AddComment(new Comment("Eden", "Python should be #1!"));
        video2.AddComment(new Comment("Eve", "I love JavaScript ❤️"));
        video2.AddComment(new Comment("Jordan", "C# is the best"));

        Video video3 = new Video("Learn JavaScript in 15 Minutes", "techmade easy", 750);
        video3.AddComment(new Comment("Sellina", "Very concise and clear."));
        video3.AddComment(new Comment("Henry", "Helped me for my assignment."));
        video3.AddComment(new Comment("Ruth", "Thank you, Looking forward to more."));

        
        List<Video> videos = new List<Video> { video1, video2, video3 };

        
        foreach (Video v in videos)
        {
            Console.WriteLine($"Title: {v.GetTitle()}");
            Console.WriteLine($"Author: {v.GetAuthor()}");
            Console.WriteLine($"Length: {v.GetLengthSeconds()} seconds");
            Console.WriteLine($"Number of comments: {v.GetCommentCount()}");

            foreach (Comment c in v.GetComments())
            {
                Console.WriteLine($" - {c.GetCommenterName()}: {c.GetText()}");
            }
            Console.WriteLine();
        }
    }
}
