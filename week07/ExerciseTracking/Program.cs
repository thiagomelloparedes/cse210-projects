using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        activities.Add(new Running(new DateTime(2022, 11, 3), 30, 3.0));   // 3.0 miles in 30 min
        activities.Add(new Cycling(new DateTime(2022, 11, 3), 45, 12.0));  // 12 mph for 45 min
        activities.Add(new Swimming(new DateTime(2022, 11, 3), 25, 40));   // 40 laps in 25 min

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
