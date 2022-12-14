using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSort
{
    internal class QuickSort
    {
        long[] mass;
        public QuickSort(long[] mass)
        {
            this.mass = mass;
        }

        public long AsgCounter { get; private set; }
        public long CMPCounter { get; private set; }
        public void Sort()
        {
            Sort(0, mass.Length - 1);
        }

        public void Sort(long[] mass)
        {
            this.mass = mass;
            Sort(0, mass.Length - 1);
        }

        void Sort(long L, long R)
        {
            if (L >= R) return;

            long M = Split(L, R);
            Sort(L, M - 1);
            Sort(M + 1, R);
        }

        long Split(long L, long R)
        {
            long P = mass[R];
            long m = L - 1;

            long count = L;
            while(count <= R)
            {
                if ((++CMPCounter > 0) && mass[count] <= P)
                    Swap(ref mass[++m], ref mass[count]);

                count++;
            }
            return m;
        }

        void Swap(ref long value1, ref long value2)
        {
            long temp = value1; AsgCounter++;
            value1 = value2; AsgCounter++;
            value2 = temp; AsgCounter++;
        }
    }
}
