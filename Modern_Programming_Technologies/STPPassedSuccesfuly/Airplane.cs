using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STPExam
{
    class Airplane
    {        
        public List<Carryable> carryables = new List<Carryable>();
        

        private int _sumWeight;

        public void AddCarryable(Carryable c)
        {
            if (_sumWeight + c.GetWeight() > 3000)
                throw new Exception("Airplane Overloaded");
            _sumWeight += c.GetWeight();

            
                carryables.Add(c);
            
                
            
        }

        public void PrintPassengers()
        {
            foreach (var carryable  in carryables )
            {
                if (carryable is Passenger )
                Console.WriteLine("Passenger :(" + carryable.Id + ", " + (carryable as Passenger).Name + ")\n");
            }
        }

        public void PrintLuggage()
        {
            foreach (var carryable in carryables)
            {
                if (carryable is Luggage luggage)
                Console.WriteLine("Luggage :(" + luggage.Id + ")\n");
            }
        }
    }
}
