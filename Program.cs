using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();

            var rolls = new List<int>();
            var stats = new List<int>();
            int totalRolls;

            for (int i = 0; i < 6; i++)
            {
                //Roll dice four times
                for (totalRolls = 0; totalRolls < 4; totalRolls++)
                {
                    int roll = random.Next(6) + 1;
                    Console.WriteLine($"You rolled a {roll}");
                    rolls.Add(roll);
                }

                //Determing lowest roll and remove it from our list.
                int lowestRoll = rolls[0];
                for (int rollIndex = 1; rollIndex <= 3; rollIndex++)
                {
                    int roll = rolls[rollIndex];
                    if (roll < lowestRoll)
                    {
                        lowestRoll = roll;
                    }
                }
                rolls.Remove(lowestRoll);

                //Adding all numbers for a total score
                int totalScore = rolls[0] + rolls[1] + rolls[2];
                Console.WriteLine($"Your total ability score is: {totalScore}");
                rolls.Clear();
                stats.Add(totalScore);
            }
        }
    }
}
