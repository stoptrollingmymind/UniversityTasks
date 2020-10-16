using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STPExam
{
    class Program
    {
        static void Main(string[] args)
        {
            Airplane airplane = new Airplane ();
            airplane.AddCarryable(new Passenger { Name = "Steave", Id = 324 });
            airplane.AddCarryable(new Luggage { Id = 24 });

            airplane.AddCarryable(new Passenger { Name = "John", Id = 325 });
            airplane.AddCarryable(new Luggage { Id = 25 });

            airplane.PrintPassengers();
            airplane.PrintLuggage();

            Console.ReadKey();


        }
    }
}
