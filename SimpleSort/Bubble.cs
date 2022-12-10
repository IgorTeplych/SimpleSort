using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSort
{
    public class Bubble
    {
        long[] mass;
        public Bubble(long[] mass)
        {
            this.mass = mass;
        }

        public long AsgCounter { get; private set; }
        public long CmpCounter { get; private set; }
        public long[] Basic()
        {
            long count = 0;
            long bigcount = 0;

            while ((++CmpCounter > 0) && bigcount < mass.Length)
            {
                while ((++CmpCounter > 0) && count < mass.Length - 1)
                {
                    if ((++CmpCounter > 0) && mass[count] > mass[count + 1])
                    {
                        Swap(ref mass[count], ref mass[count + 1]);
                    }
                    count++;
                }
                bigcount++;
                count = 0;
            }
            return mass;
        }
        public long[] Modern()
        {
            long count = 0;
            long bigcount = 0;
            bool swap = false;
            while ((++CmpCounter > 0) && bigcount < mass.Length)
            {
                while ((++CmpCounter > 0) && count < mass.Length - bigcount - 1)
                {
                    if ((++CmpCounter > 0) && mass[count] > mass[count + 1])
                    {
                        Swap(ref mass[count], ref mass[count + 1]);
                        swap = true;
                    }
                    count++;
                }
                if (!swap)
                    break;

                bigcount++;
                count = 0;
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
