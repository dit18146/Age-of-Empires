using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Age_Of_Empires
{
    public class Timer
    {
        Stopwatch timer = new Stopwatch();

        
        public void startTime()
        {
            //A: Setup and stuff you don't want timed
            
            timer.Start();


        }


        public void stopTime()
        {
            //B: Run stuff you want timed
            timer.Stop();

            TimeSpan timeTaken = timer.Elapsed;
            Console.WriteLine("Time : " + timeTaken.ToString(@"m\:ss\.fff"));
        }

        public void printTime()
        {
            TimeSpan timeTaken = timer.Elapsed;
            Console.WriteLine("Time : " + timeTaken.ToString(@"m\:ss\.fff"));
        }
    }
}
