using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSort
{
    internal class ExternalSort
    {
        Files files;
        long[] mass;
        public ExternalSort(long[] mass)
        {
            this.mass = mass;
        }
        public ExternalSort(int N, int T)
        {
            //files = new Files();
            //files.Generate(N, T);
        }

        public void Sort()
        {
            files.Split(1000);


        }

        void Start()
        {
            
        }
    }
}
