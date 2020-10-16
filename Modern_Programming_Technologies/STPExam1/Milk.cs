using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeMachine
{
    class Milk : ICoffeeComponent
    {
        public override string ToString()
        {
            return "Milk";
        }
    }
}
