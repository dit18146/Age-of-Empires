using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Age_Of_Empires
{
    public class Gold : Peasant, Gatherer
    {
        public async void gather(int time, int index, Peasant[] peasant)
        {
            var now = DateTime.Now;
            while (DateTime.Now < now.AddSeconds(time))
            {
                gold = 3;
                Console.WriteLine("Gathering...");
                await Task.Factory.StartNew(() => Thread.Sleep(15000));
                Console.WriteLine("You have gathered 3 pieces of gold");
            }
          
            
            
        }
    }
}
