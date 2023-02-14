using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal class Program
    {
        static Random random = new Random();
        static int DiceRoll(int numberOfRolls, int diceSides, int fixedBonus = 0)
        {
            int result = 0;

            for (int i = 0; i < numberOfRolls; i++)
            {
                result += random.Next(1, diceSides + 1);
            }
            result += fixedBonus;

            return result;
        }

        static void SimulateCombat(List<string> characterNames, string monsterName, int monsterHP, int savingThrowDC)
        {
            var deadCharacters = new List<string>();
            int currentHP = monsterHP;
            List<string> currentCharacters = characterNames;

            Console.WriteLine($"A random {monsterName} with {monsterHP} HP appears and stands in the groups way!");

            while (currentHP > 0 && currentCharacters.Count > 0)
            {
                foreach (var character in currentCharacters)
                {
                    int damageHitPoints = DiceRoll(2, 6);
                    currentHP -= damageHitPoints;

                    if (currentHP < 0)
                    {
                        currentHP = 0;
                    }

                    Console.Write(character);

                    Console.WriteLine($" swings their sword and deals {damageHitPoints} damage and the {monsterName} now has {currentHP} HP remaining!");
                }

                //Orc attacks

                int randomCharacterIndex = random.Next(currentCharacters.Count);
                string randomCharacter = currentCharacters[randomCharacterIndex];

                if (currentHP > 0)
                {
                    int dodge = DiceRoll(1, 20);

                    if (dodge < savingThrowDC)
                    {
                        Console.WriteLine($"The {monsterName} attacks!");
                        Console.WriteLine($"{randomCharacter} rolls a {dodge} and fails to be saved. {randomCharacter} is killed");
                        deadCharacters.Add(randomCharacter);
                    }
                    else
                    {
                        Console.WriteLine($"{randomCharacter} rolls a {dodge} was able to dodge the attack and is still alive");
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
                }
            }
        }
        static void Main(string[] args)
        {
            //characters and health

            var characterNames = new List<string> { "Bill", "Franics", "Louis", "Zoey" };

            int orcHitPoints = DiceRoll(2, 8, 6);

            int azerHitPoints = DiceRoll(6, 8, 12);

            int trollHitPoints = DiceRoll(8, 10, 40);

            var deadCharacters = new List<string>();

            Console.WriteLine("A party of recognizable names have joined the party");

            Console.Write(String.Join(" ", characterNames));

            Console.WriteLine(" each one of them ready to fight");

            SimulateCombat(characterNames, "Orc", orcHitPoints, 6);

            if (characterNames.Count > 0)
            {
                SimulateCombat(characterNames, "Azer", azerHitPoints, 8);

                if (characterNames.Count > 0)
                {
                    SimulateCombat(characterNames, "Troll", trollHitPoints, 10);
                }
                if (characterNames.Count > 0)
                {
                    Console.WriteLine("It's finally over. After many tough battles our remaining heroes:");
                    Console.Write(String.Join(" ", characterNames));
                    Console.WriteLine(" gets to live for another day");
                }
            }
        }
    }
}
