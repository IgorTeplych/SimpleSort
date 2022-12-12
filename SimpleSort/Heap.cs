using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSort
{
    public class Heap
    {
        long[] mass;
        public Heap(long[] mass)
        {
            this.mass = mass;
        }
        public long AsgCounter { get; private set; }
        public long CMPCounter { get; private set; }

        public void Basic()
        {
            for (long i = mass.Length / 2 - 1; i >= 0; i--)
                Heapify(i, mass.Length);

            for (long i = mass.Length - 1; i > 0; i--)
            {
                Swap(ref mass[0], ref mass[i]);
                Heapify(0, i);
            }
        }

        void Heapify(long root, long size)
        {
            long X = root;
            long L = 2 * X + 1;
            long R = L + 1;
            if (L < size && mass[L] > mass[X]) { X = L; }
            if (R < size && mass[R] > mass[X]) { X = R; }
            if (X == root)
                return;
            Swap(ref mass[root], ref mass[X]);
            Heapify(X, size);
        }

        void Swap(ref long value1, ref long value2)
        {
            long temp = value1; AsgCounter++;
            value1 = value2; AsgCounter++;
            value2 = temp; AsgCounter++;
        }
    }
}
