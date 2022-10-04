using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Age_Of_Empires
{
    public interface Gatherer
    {
        void gather(int time, int index, Peasant[] peasant);

    }
}
