using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Age_Of_Empires
{

   
    class Program
    {
       
        static void Main(string[] args)
        {
            Peasant[] peasant;
            peasant = new Peasant[1000];
            Timer time = new Timer();
            Board board = new Board();
           
            string action;
            string numberString;
            string timerString;
            int timer;
            string typeString;
            int peasantCounter = 0;
            int foodCounter = 0;
            int woodCounter = 0;
            int ironCounter = 0;
            int goldCounter = 0;
            int movedcounter = 0;
            int foodSum = 0;
            int woodSum = 0;
            int ironSum = 0;
            int goldSum = 0;
            int savedFoodCounter = 0;
            int savedWoodCounter = 0;
            int savedIronCounter = 0;
            int savedGoldCounter = 0;
            int savedMovedcounter = 0;
            int savedFoodSum = 0;
            int savedWoodSum = 0;
            int savedIronSum = 0;
            int savedGoldSum = 0;
            Regex nameinputFilter = new Regex(@"(^[Pp]([1-9][0-9]{0,2}|1000) (move) (up|down|right|left)$)");
            Regex typeinputFilter = new Regex(@"(^[Pp]([1-9][0-9]{0,2}|1000) (gather) (food|wood|gold|iron)$)");
            Regex numberFilter = new Regex(@"\d+");
            Regex wordFilter = new Regex(@"\b(\w+)$");
            Regex inventoryFilter = new Regex(@"(^(inventory|INVENTORY)$)");
            Regex statsFilter = new Regex(@"(^(stats|STATS)$)");
            StreamWriter save_file = new StreamWriter("save.txt");

            bool con = true;
            for (int i = 0; i < 1000; i++)
            {
                peasant[i] = new Peasant();    //Initializing villagers and their names
                peasant[i].set("P" + i);
            }
            time.startTime();
           
            do
            {
                time.printTime();
                Console.WriteLine("Awaiting Command");
                action = Console.ReadLine();
                action = action.ToLowerInvariant();

                if (nameinputFilter.IsMatch(action))  //Matching input
                {
                    Console.WriteLine("Peasant " + numberFilter.Match(action) + " moved " + wordFilter.Match(action));  //Printing name input in the correct form
                    numberString = Regex.Match(action, @"\d+").Value;
                    int index = Int32.Parse(numberString);
                    new FindMove(index, action, peasant[index]);



                }

                else if (typeinputFilter.IsMatch(action) )
                {
                    if (typeinputFilter.IsMatch(action))
                        Console.WriteLine("Peasant " + numberFilter.Match(action) + " becomes a " + wordFilter.Match(action) + " gatherer");  //Printing gathering input in the correct form

                    numberString = Regex.Match(action, @"\d+").Value;
                    int index = Int32.Parse(numberString);
                    typeString = Regex.Match(action, @"\b(\w+)$").Value;
                    Console.WriteLine("For how much time should I gather?");
                    timerString = Console.ReadLine();
                    timer = Int32.Parse(timerString);
                    if (typeString == "food" )   //Gathering
                    {
                        new FindMove(index, action, peasant[index]);
                        peasant[index].occupation = "food gatherer";
                        Food foodGatherer = new Food();
                       
                        foodGatherer.gather(timer, index, peasant);
                        
                            
                        peasant[index].food += foodGatherer.food;
                        foodSum += foodGatherer.food;

                    }


                    if (typeString == "wood")
                    {
                        
                        peasant[index].occupation = "wood gatherer";

                        Wood woodGatherer = new Wood();
                       
                        woodGatherer.gather(timer, index, peasant);
                            
                        peasant[index].wood += woodGatherer.wood;
                        woodSum += woodGatherer.wood;

                    }

                    if (typeString == "gold")
                    {
                        peasant[index].occupation = "gold gatherer";

                        Gold goldGatherer = new Gold();

                        goldGatherer.gather(timer, index, peasant);
                       
                        peasant[index].gold += goldGatherer.gold;
                        goldSum += goldGatherer.gold;

                    }

                    if (typeString == "iron")
                    {
                        peasant[index].occupation = "iron gatherer";

                        Iron ironGatherer = new Iron();

                       
                        ironGatherer.gather(timer, index, peasant);
                      


                       peasant[index].iron += ironGatherer.iron;
                       goldSum += ironGatherer.iron;

                    }
                }



                else if (action == "stats")
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        if (peasant[i].moved != "IDLE")
                            ++movedcounter;

                        if (peasant[i].occupation == "peasant")
                        {
                            ++peasantCounter;
                        }

                        if (peasant[i].occupation == "food gatherer")
                        {
                            ++foodCounter;
                            ++movedcounter;
                        }

                        if (peasant[i].occupation == "wood gatherer")
                        {
                            ++woodCounter;
                            ++movedcounter;
                        }

                        if (peasant[i].occupation == "gold gatherer")
                        {
                            ++goldCounter;
                            ++movedcounter;
                        }

                        if (peasant[i].occupation == "iron gatherer")
                        {
                            ++ironCounter;
                            ++movedcounter;
                        }


                    }
                    /* string line1 = File.ReadLines("save.txt").First();
                     if (statsFilter.IsMatch(line1))
                     {
                         Console.WriteLine("stats in");
                     }*/
                    Console.WriteLine("Peasants are " + peasantCounter + "\nFood Gatherers are " + foodCounter + "\nWood Gatherers are " + woodCounter + "\nGold Gatherers are " + goldCounter + "\nIron Gatherers are " + ironCounter + "\nPeople moved " + movedcounter);
                }

                else if (action == "inventory")
                {
                    /*string line1 = File.ReadLines("save.txt").First();
                    if (inventoryFilter.IsMatch(line1))
                    {
                        Console.WriteLine("inv in");
                    }*/
                    Console.WriteLine("Total food " + foodSum + "\nTotal wood " + woodSum + "\nTotal gold " + goldSum + "\nTotal iron " + ironSum);


                }

              

                else if (action == "cancel")
                {
                    break;
                }


                else
                {
                    Console.WriteLine("Error in command, please reenter your input in the correct form (e.g P100 gather wood)\n");
                }

                save_file.WriteLine("STATS\n" + peasantCounter + "\n" + foodCounter + "\n" + woodCounter + "\n" + goldCounter + "\n" + ironCounter + "\n" + movedcounter + "\n");
                save_file.WriteLine("INVENTORY\n" + foodSum + "\n" + woodSum + "\n" + goldSum + "\n" + ironSum + "\n");
                
            } while (true);
            save_file.Close();
            time.stopTime();
        }
    }
}
