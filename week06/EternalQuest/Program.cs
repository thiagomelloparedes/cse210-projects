using System;

class Program
{
    /*
     * EXCEEDING REQUIREMENTS (for 100%):
     * - Added a Leveling System: the user levels up every 1000 points and receives a fun title.
     * - Added Badges (achievements): awarded automatically at score milestones (1000, 5000, 10000, 20000).
     * - Added extra celebrations when leveling up / earning badges.
     */

    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
