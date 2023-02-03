using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists_Boss_Battle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //characters and health

            var random = new Random();
            
            var characters = new List<string> { "Bill", "Franics", "Louis", "Zoey" };
            
            int basiliskHitPoints = 0;

            var deadCharacters = new List<string>();

            int charactersRemaining = 4;

            Console.WriteLine("A party of recognizable names have joined the party");

            Console.Write(String.Join(" ", characters));

            Console.WriteLine(" Each one of them ready to fight");

            //Basilisk

            for (int i = 0; i < 8; i++)
            {
                basiliskHitPoints += random.Next(1, 9);
            }
            basiliskHitPoints += 16;

            Console.WriteLine($"A basilik with {basiliskHitPoints} HP appears and stands in the groups way!");

            //Fight

            while (basiliskHitPoints > 0 && charactersRemaining > 0) 
            {
                foreach (var character in characters)
                {
                    int damageHitPoints = 0;

                    for (int i = 0; i < 2; i++)
                    {
                        damageHitPoints += random.Next(1, 5);
                    }

                    basiliskHitPoints -= damageHitPoints;

                    if (basiliskHitPoints < 0)
                    {
                        basiliskHitPoints = 0;
                    }

                    Console.Write(character);

                    Console.WriteLine($" swings their sword and deals {damageHitPoints} damage and the Basilik now has {basiliskHitPoints} HP remaining!");
                }
                
                //Basilisk attacks

                foreach (var character in characters)
                {
                    if (basiliskHitPoints > 0)
                    {
                        int basiliskAttack = 0;
                        int dodge = random.Next(1, 21);

                        if (dodge < 12)
                        {
                            Console.WriteLine($"{character} couldn't save themself was turned into stone");
                            deadCharacters.Add(character);
                            charactersRemaining -= 1;
                        }
                        else if (dodge > 12)
                        {
                            Console.WriteLine($"{character} was able to dodge the attack ans is still alive");
                        }
                    }
                }
                foreach (var deadCharacter in deadCharacters)
                {
                    characters.Remove(deadCharacter);
                }
                Console.WriteLine();
                if (basiliskHitPoints == 0)
                {
                    Console.WriteLine("The basilik has been slain!");
                }
                else if (charactersRemaining == 0)
                {
                    Console.WriteLine("It's over. All characters have been turned into stone and the basilisk walks away");
                }
            }
        }
    }
}
