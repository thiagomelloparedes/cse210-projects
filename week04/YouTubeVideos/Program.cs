using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // 1) Create videos
        Video v1 = new Video();
        v1._title = "How to Cook Perfect Rice";
        v1._author = "Easy Kitchen";
        v1._lengthSeconds = 420;

        Video v2 = new Video();
        v2._title = "Top 5 C# Tips for Beginners";
        v2._author = "Code With Pepe";
        v2._lengthSeconds = 615;

        Video v3 = new Video();
        v3._title = "10-Minute Home Workout";
        v3._author = "FitDaily";
        v3._lengthSeconds = 600;

        // 2) Add 3-4 comments to each video
        Comment c1 = new Comment();
        c1._commenterName = "Ana";
        c1._text = "This worked great, thanks!";
        v1._comments.Add(c1);

        Comment c2 = new Comment();
        c2._commenterName = "Luis";
        c2._text = "I used a bit more water and it turned out fine.";
        v1._comments.Add(c2);

        Comment c3 = new Comment();
        c3._commenterName = "Maria";
        c3._text = "Does this also work for brown rice?";
        v1._comments.Add(c3);

        Comment c4 = new Comment();
        c4._commenterName = "Jorge";
        c4._text = "Great tip about List<T>.";
        v2._comments.Add(c4);

        Comment c5 = new Comment();
        c5._commenterName = "Camila";
        c5._text = "This helped me understand classes, thank you.";
        v2._comments.Add(c5);

        Comment c6 = new Comment();
        c6._commenterName = "Rosa";
        c6._text = "Can you make one about inheritance next?";
        v2._comments.Add(c6);

        Comment c7 = new Comment();
        c7._commenterName = "Diego";
        c7._text = "I tested it and it compiles perfectly.";
        v2._comments.Add(c7);

        Comment c8 = new Comment();
        c8._commenterName = "Sofi";
        c8._text = "Loved the workout, I really felt it!";
        v3._comments.Add(c8);

        Comment c9 = new Comment();
        c9._commenterName = "Pedro";
        c9._text = "How many times per week do you recommend?";
        v3._comments.Add(c9);

        Comment c10 = new Comment();
        c10._commenterName = "Karla";
        c10._text = "Simple and effective.";
        v3._comments.Add(c10);

        // 3) Put videos into a list
        List<Video> videos = new List<Video>();
        videos.Add(v1);
        videos.Add(v2);
        videos.Add(v3);

        // 4) Iterate and display each video + its comments
        foreach (Video v in videos)
        {
            v.Display();
        }
    }
}
