using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreparingToExam
{
    class Adder : IMathOperation
    {
        public  int PerformMathAction(int oper1, int oper2)
        {
            return oper1 + oper2;
        }
    }
}
