
using System;

class Program
{
    static void Main(string[] args)
    {
        // Creativity:
        // I added a leveling system to my Eternal Quest Program.
        // The user starts as a Beginner and earns new levels
        // as they collect points from completing goals.
        //
        // The levels are:
        // Beginner: 0-499 points
        // Apprentice: 500-999 points
        // Achiever: 1000-1999 points
        // Goal Master: 2000 or more points
        //
        // The program displays the current level with the score.
        // It also congratulates the user when they level up.
        // I added this to make completing goals more rewarding.

        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
