using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSort
{
    public class Insertion
    {
        long[] mass;
        public Insertion(long[] mass)
        {
            this.mass = mass;
        }
        public long AsgCounter { get; private set; }
        public long CMPCounter { get; private set; }
        public long[] Basic()
        {
            long count = 0;
            long countBig = 0;

            while ((++CMPCounter > 0) && countBig < mass.Length - 1)
            {
                count = countBig;
                while ((++CMPCounter > 0) && count >= 0 && mass[count] > mass[count + 1])
                {
                    Swap(ref mass[count], ref mass[count + 1]);
                    count--;
                }
                countBig++;
            }
            return mass;
        }

        public long[] Shift()
        {
            long count = 0;
            long countBig = 1;

            while (((++CMPCounter > 0)) && countBig < mass.Length)
            {
                long k = mass[countBig]; AsgCounter++;
                count = countBig - 1;
                while ((++CMPCounter > 0) && count >= 0 && mass[count] > k)
                {
                    mass[count + 1] = mass[count]; AsgCounter++;
                    count--;
                }
                mass[count + 1] = k; AsgCounter++;
                countBig++;
            }
            return mass;
        }

        public long[] Dichotomy()
        {
            long count = 0;
            long countBig = 1;

            while ((++CMPCounter > 0) && countBig < mass.Length)
            {
                long k = mass[countBig]; AsgCounter++;
                long p = BinarySearch(k, 0, countBig - 1); AsgCounter++;

                count = countBig - 1;
                while ((++CMPCounter > 0) && count >= p)
                {
                    mass[count + 1] = mass[count]; AsgCounter++;
                    count--;
                }
                mass[count + 1] = k; AsgCounter++;
                countBig++;
            }
            return mass;
        }

        long BinarySearch(long value, long lowIndex, long highIndex)
        {
            //условие выхода из рекурсии
            if ((++CMPCounter > 0) &&  lowIndex >= highIndex)
            {
                if ((++CMPCounter > 0) && value > mass[lowIndex])
                    return lowIndex + 1;
                else
                    return lowIndex;
            }
            //конец условия выхода из рекурсии

            long mid = (lowIndex + highIndex) / 2;

            if ((++CMPCounter > 0) && value > mass[mid])
                return BinarySearch(value, mid + 1, highIndex);
            else
                return BinarySearch(value, lowIndex, mid - 1);

        }

        void Swap(ref long value1, ref long value2)
        {
            long temp = value1; AsgCounter++;
            value1 = value2; AsgCounter++;
            value2 = temp; AsgCounter++;
        }
    }
}
