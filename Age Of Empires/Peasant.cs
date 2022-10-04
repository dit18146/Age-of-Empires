using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Age_Of_Empires
{
    public class Peasant
    {
        public string name;
        public string occupation = "peasant";
        public int food;
        public int wood;
        public int gold;
        public int iron;
        public int x = 5;
        public int y = 5;
        public String moved = "IDLE";

        public void set(String name)
        {
            this.name = name;
        }

        public String get()
        {
            return name;
        }
    }
}
