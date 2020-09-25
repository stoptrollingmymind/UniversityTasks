using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreparingToExam
{
    class Program
    {
        static void Main(string[] args)
        {
            MathFactory mathFactory = new MathFactory();
            Console.WriteLine(mathFactory.GetMathOperation(0).PerformMathAction(10,6));


            Console.ReadKey();
        }
    }
}
