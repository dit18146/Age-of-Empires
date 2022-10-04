using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Age_Of_Empires
{
    class Board 
    {
        int[,] position = new int[10,10];



        public void moveUp (int peasant_number, Peasant peasant)
        {
            peasant.x = --peasant.x; 
            drawPosition(peasant_number, peasant.x, peasant.y);
        }

        public void moveDown(int peasant_number, Peasant peasant)
        {
            peasant.x = ++peasant.x;
            drawPosition(peasant_number, peasant.x, peasant.y);
        }

        public void moveRight(int peasant_number, Peasant peasant)
        {
            peasant.y = ++peasant.y;
            drawPosition(peasant_number, peasant.x, peasant.y);
        }

        public void moveLeft(int peasant_number, Peasant peasant)
        {
            peasant.y = --peasant.y;
            drawPosition(peasant_number, peasant.x, peasant.y);
        }

        

        public void drawPosition(int peasant_number, int x, int y)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write("+  ");
                    if (i == x && j == y)
                        Console.Write(peasant_number + "  ");
                    else
                        Console.Write("+  ");
                }
                Console.Write("\n");
            }
        }
    }
}
