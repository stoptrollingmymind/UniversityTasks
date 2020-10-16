using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            CoffeMachine coffeMachine = new CoffeMachine();
            Console.WriteLine(coffeMachine.CreateCoffee(1,3));
            Console.WriteLine(coffeMachine.CreateCoffee(0, 2));

            Console.ReadKey();


        }
    }
}
