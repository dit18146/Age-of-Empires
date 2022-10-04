using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Age_Of_Empires
{
    public class Food : Peasant, Gatherer
    {
        public bool stop;
        int steps = 0;
        public async void gather(int time, int index, Peasant[] peasant)
        {
            
            



            var now = DateTime.Now;
            while (DateTime.Now < now.AddSeconds(time))
            {
                ++steps;
                food = 10;
                new FindMove(index, "up", peasant[index]);
                Console.WriteLine("Gathering...");
                await Task.Factory.StartNew(() => Thread.Sleep(15000));
                //cts.Cancel();
                Console.WriteLine("You have gathered 10 pieces of food");
            }

            Console.WriteLine("Gathering ended, returning to base");

            while (steps !=1)
            {
                --steps;
                new FindMove(index, "down", peasant[index]);
                await Task.Factory.StartNew(() => Thread.Sleep(1000));
                Console.WriteLine();

            }


        }

        
    }
}
