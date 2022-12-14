using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSort
{
    internal class MergeSort
    {
        long[] mass;
        public MergeSort(long[] mass)
        {
            this.mass = mass;
        }

        public long AsgCounter { get; private set; }
        public long CMPCounter { get; private set; }
        public void Sort()
        {
            Sort(0, mass.Length - 1);
        }

        void Sort(long L, long R)
        {
            if (L >= R) return;
            long M = (L + R) / 2;

            Sort(L, M);
            Sort(M + 1, R);
            Merge(L, M, R);
        }
        void Merge(long Left, long Middle, long Right)
        {
            long[] mergeMass = new long[Right - Left + 1];
            long left = Left;
            long middle = Middle + 1;

            int count = 0;
            while (left <= Middle && middle <= Right)
                if ((++CMPCounter > 0) && mass[left] < mass[middle])
                    mergeMass[count++] = mass[left++];
                else
                    mergeMass[count++] = mass[middle++];

            while (left <= Middle)
            {
                mergeMass[count++] = mass[left++];
                AsgCounter++;
            }
            while((++AsgCounter > 0) && middle <= Right)
            {
                mergeMass[count++] = mass[middle++];
                AsgCounter++;
            }

            for (long i = Left; i <= Right; i++)
            {
                mass[i] = mergeMass[i - Left];
                AsgCounter++;
            }
        }
    }
}
