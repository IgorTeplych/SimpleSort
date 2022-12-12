using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSort
{
    public class AlgShell
    {
        long[] mass;
        public AlgShell(long[] mass)
        {
            this.mass = mass;
        }
        Action swapComplited;
        Action Complited;
        public AlgShell(Action swapComplited, Action Complited)
        {
            this.swapComplited = swapComplited;
            this.Complited = Complited;
        }
        public long AsgCounter { get; private set; }
        public long CMPCounter { get; private set; }

        public long[] Basic(long[] mass)
        {
            this.mass = mass;
            for (long gap = mass.Length / 2; gap > 0; gap /= 2)
            {
                for (long i = gap; i < mass.Length; i++)
                {
                    for (long j = i; (++CMPCounter > 0) && j >= gap && mass[j - gap] > mass[j]; j -= gap)
                    {
                        Swap(ref mass[j - gap], ref mass[j]);
                    }
                }
            }
            Complited.Invoke();
            return mass;
        }

        public long[] Hibbard(long[] mass)
        {
            this.mass = mass;
            int pow = (int)Math.Log(mass.Length, 2);
            long gap = 2;
            while (gap > 1)
            {
                gap = (long)Math.Pow(2, pow--) - 1;
                for (long i = gap; i < mass.Length; i++)
                {
                    for (long j = i; (++CMPCounter > 0) && j >= gap && mass[j - gap] > mass[j]; j -= gap)
                    {
                        Swap(ref mass[j - gap], ref mass[j]);
                    }
                }
            }
            Complited.Invoke();
            return mass;
        }

        public long[] Tsiur(long[] mass)
        {
            this.mass = mass;
            long[] tsiur = new long[] { 1, 4, 10, 23, 57, 132, 301, 701, 1750 };

            int count = tsiur.Length - 1;
            while (count >= 0)
            {
                long gap = tsiur[count--];
                for (long i = gap; i < mass.Length; i++)
                {
                    for (long j = i; (++CMPCounter > 0) && j >= gap && mass[j - gap] > mass[j]; j -= gap)
                    {
                        Swap(ref mass[j - gap], ref mass[j]);
                    }
                }
            }
            Complited.Invoke();
            return mass;
        }

        public long[] Pratt(long[] mass)
        {
            this.mass = mass;
            int N = (mass.Length / 2);

            int pow1 = (int)Math.Log(N, 2);
            int pow2 = (int)Math.Log(N, 3);

            int _pow2 = pow2;

            while (pow1 >= 0)
            {
                while (pow2 >= 0)
                {
                    long gap = (long)Math.Pow(2, pow1) * (long)Math.Pow(3, pow2--);

                    for (long i = gap; i < mass.Length; i++)
                    {
                        for (long j = i; (++CMPCounter > 0) && j >= gap && mass[j - gap] > mass[j]; j -= gap)
                        {
                            Swap(ref mass[j - gap], ref mass[j]);
                        }
                    }
                }
                pow2 = _pow2;
                pow1--;
            }
            Complited.Invoke();
            return mass;
        }

        void Swap(ref long value1, ref long value2)
        {
            long temp = value1; AsgCounter++;
            value1 = value2; AsgCounter++;
            value2 = temp; AsgCounter++;
            swapComplited.Invoke();
        }
    }
}
