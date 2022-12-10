using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSort
{
    public class Shell
    {
        long[] mass;
        public Shell(long[] mass)
        {
            this.mass = mass;
        }
        public long AsgCounter { get; private set; }
        public long CmpCounter { get; private set; }

        public void ToSort()
        {

        }
    }
}
