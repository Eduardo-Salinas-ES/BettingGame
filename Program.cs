using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace BettingGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            double odds = .75;

            Guy player = new Guy() { Name = "The player", Cash = 100 };

            Console.WriteLine("Welcome to the casino. The odds are 0.75");

            while(player.Cash > 0)
            {
                player.WriteMyInfo();
                //Console.WriteLine("The player has " + player.Cash + " bucks.");


                Console.Write("How much money do you want to bet: ");
                string howMuch = Console.ReadLine();

                if(int.TryParse(howMuch, out int howMuchAsInt))
                {

                    //int pot = howMuchAsInt * 2;
                    int pot = player.GiveCash(howMuchAsInt);
                    if(pot > 0)
                    {
                        if (random.NextDouble() > odds)
                        {
                            player.Cash += pot;
                            Console.WriteLine("You win " + pot);
                        }
                        else
                        {
                            player.Cash -= howMuchAsInt;
                            Console.WriteLine("Bad luck, you lose.");
                        }

                    }

                }
                else
                {
                    Console.WriteLine("Your entry was invalid, try again.");
                }

            }

            Console.WriteLine("The house always wins.");
            Console.ReadLine();
            

        }
    }
}
