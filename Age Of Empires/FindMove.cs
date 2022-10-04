using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Age_Of_Empires
{
    class FindMove : Board
    {
        
        public FindMove(int peasant_number, string movement, Peasant peasant)
        {
            
            movement= Regex.Match(movement, @"\b(\w+)$").Value;
            if (movement == "up")
                moveUp(peasant_number, peasant);

            if (movement == "down")
                moveDown(peasant_number, peasant);

            if (movement == "left")
                moveLeft(peasant_number, peasant);

            if (movement == "right")
                moveRight(peasant_number, peasant);
        }

        

    }
}
