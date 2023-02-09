using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists_Boss
{
    internal class Program
    {
        static void SimulateCombat(List<string> characterNames, string monsterName, int monsterHP, int savingThrowDC)
        {
            var random = new Random();
            var deadCharacters = new List<string>();
            int currentHP = monsterHP;
            List<string> currentCharacters = characterNames;

            Console.WriteLine($"A random {monsterName} with {monsterHP} HP appears and stands in the groups way!");

            while (currentHP > 0 && currentCharacters.Count > 0)
            {
                foreach (var character in currentCharacters)
                {
                    int damageHitPoints = 0;

                    for (int i = 0; i < 2; i++)
                    {
                        damageHitPoints += random.Next(1, 8);
                    }

                    currentHP -= damageHitPoints;

                    if (currentHP < 0)
                    {
                        currentHP = 0;
                    }

                    Console.Write(character);

                    Console.WriteLine($" swings their sword and deals {damageHitPoints} damage and the {monsterName} now has {currentHP} HP remaining!");
                }

                //Orc attacks

                foreach (var character in currentCharacters)
                {
                    if (currentHP > 0)
                    {
                        int dodge = random.Next(1, 21);

                        if (dodge < savingThrowDC)
                        {
                            Console.WriteLine($"{character} rolls a {dodge} and fails to be saved. {character} is killed");
                            deadCharacters.Add(character);
                        }
                        else
                        {
                            Console.WriteLine($"{character} rolls a {dodge} was able to dodge the attack and is still alive");
                        }
                    }
                }
                foreach (var deadCharacter in deadCharacters)
                {
                    currentCharacters.Remove(deadCharacter);
                }
                Console.WriteLine();
                if (currentHP == 0)
                {
                    Console.WriteLine($"The {monsterName} has been slain!");
                }
                else if (currentCharacters.Count == 0)
                {
                    Console.WriteLine($"It's over. All characters have been killed and the {monsterName} walks away");
                    break;
                }
            }
        }
        static void Main(string[] args)
        {
            //characters and health

            var random = new Random();

            var characterNames = new List<string> { "Bill", "Franics", "Louis", "Zoey" };

            int orcHitPoints = 15;

            int azerHitPoints = 39;

            int trollHitPoints = 84;

            var deadCharacters = new List<string>();

            Console.WriteLine("A party of recognizable names have joined the party");

            Console.Write(String.Join(" ", characterNames));

            Console.WriteLine(" each one of them ready to fight");

            SimulateCombat(characterNames, "Orc", orcHitPoints, 10);

            SimulateCombat(characterNames, "Azer", azerHitPoints, 18);

            SimulateCombat(characterNames, "Troll", trollHitPoints, 16);
        }
    }
}
