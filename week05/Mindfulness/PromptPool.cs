using System;
using System.Collections.Generic;

public class PromptPool
{
    private List<string> _all;
    private List<string> _bag;
    private Random _rand = new Random();

    public PromptPool(List<string> items)
    {
        _all = new List<string>(items);
        Refill();
    }

    public string Next()
    {
        if (_bag.Count == 0)
            Refill();

        int idx = _rand.Next(_bag.Count);
        string item = _bag[idx];
        _bag.RemoveAt(idx);
        return item;
    }

    private void Refill()
    {
        _bag = new List<string>(_all);
    }
}
