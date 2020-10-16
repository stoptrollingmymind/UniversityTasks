using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STPExam
{
    class Luggage : Carryable
    {
        public override int Id { get; set; }
        public override int GetWeight()
        {
            return 20;
        }
    }
}
