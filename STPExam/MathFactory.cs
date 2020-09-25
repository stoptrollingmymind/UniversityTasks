using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreparingToExam
{
    class MathFactory
    {
        
        public IMathOperation GetMathOperation(int MathOperType)
        {
            if (MathOperType == 0)
            {
                Adder adder = new Adder();               
                return adder;
            }
            if (MathOperType == 1)
            {
                Multiplier multiplier = new Multiplier();
                return multiplier;
            }
            else return null;
        }
    }
}
