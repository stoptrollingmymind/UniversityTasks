using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STPExam
{
    abstract class Carryable
    {   
        
        public abstract int Id { get; set; }       
        public abstract int GetWeight();
    }   
}
