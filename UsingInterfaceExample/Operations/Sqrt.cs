using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsingInterfaceExample.Interface;

namespace UsingInterfaceExample
{
    internal class Sqrt : IOperation
    {
        public int RunOperation(int value1, int value2)
        {
            return (int)Math.Sqrt(value1 * value2);
        }
    }
}
