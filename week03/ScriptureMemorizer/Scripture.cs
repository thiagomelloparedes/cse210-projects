using System;
using System.Collections.Generic;
using System.Linq;

class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    // Shared Random so repeated calls don't get the same sequence.
    private static readonly Random _rng = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;

        // Split on spaces to create Word objects.
        // This keeps punctuation attached to tokens (e.g., "world,") which is fine for core requirements.
        _words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                     .Select(token => new Word(token))
                     .ToList();
    }

    public void HideRandomWords(int numberToHide)
    {
        // Stretch: Choose only from words that are not already hidden.
        List<Word> available = _words.Where(w => !w.IsHidden()).ToList();

        if (available.Count == 0)
        {
            return;
        }

        int countToHide = Math.Min(numberToHide, available.Count);

        for (int i = 0; i < countToHide; i++)
        {
            int index = _rng.Next(available.Count);
            available[index].Hide();
            available.RemoveAt(index); // Prevent hiding the same word twice this round
        }
    }

    public string GetDisplayText()
    {
        string referenceText = _reference.GetDisplayText();
        string scriptureText = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{referenceText} - {scriptureText}";
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }
}
