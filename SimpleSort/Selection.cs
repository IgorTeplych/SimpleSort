using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSort
{
    public class Selection
    {
        long[] mass;
        public Selection(long[] mass)
        {
            this.mass = mass;
        }
        public long AsgCounter { get; private set; }
        public long CMPCounter { get; private set; }

        public long[] Basic()
        {
            long countBig = mass.Length;
            while(countBig > 0)
            {
                long count = 0;
                long maxIdx = 0;
                while (count < countBig)
                {
                    if ((++CMPCounter > 0) && mass[count] > mass[maxIdx])
                    {
                        maxIdx = count;
                    }
                    count++;
                }
                Swap(ref mass[maxIdx], ref mass[countBig - 1]);
                countBig--;
            } 
            return mass;
        }


        void Swap(ref long value1, ref long value2)
        {
            long temp = value1; AsgCounter++;
            value1 = value2; AsgCounter++;
            value2 = temp; AsgCounter++;
        }
    }
}
