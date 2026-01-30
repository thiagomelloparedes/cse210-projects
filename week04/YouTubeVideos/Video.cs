using System;
using System.Collections.Generic;

public class Video
{
    public string _title = "";
    public string _author = "";
    public int _lengthSeconds = 0;

    public List<Comment> _comments = new List<Comment>();

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    public void Display()
    {
        Console.WriteLine("==================================");
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length (seconds): {_lengthSeconds}");
        Console.WriteLine($"Number of comments: {GetNumberOfComments()}");
        Console.WriteLine("Comments:");

        foreach (Comment c in _comments)
        {
            c.Display();
        }
    }
}
