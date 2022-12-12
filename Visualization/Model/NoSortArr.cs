using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visualization.Model
{
    internal class NoSortArr
    {
        static Random random = new Random();
        public NoSortArr()
        {

        }

        public long[] GetArray(int size, int min, int max)
        {
            long[] mass = new long[size];
            int count = 0;
            while (count < size)
            {
                mass[count++] = random.Next(min, max);
            }
            return mass;
        }
    }
}
