using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeMachine
{
    class CoffeEspresso : ICoffee
    {
        List<ICoffeeComponent> recipe = new List<ICoffeeComponent>();
        public override string ToString()
        {
            string str="Espresso: {\n";
            for (int i = 0; i < recipe.Count(); i++)
            {
                str += " ";
                str += recipe[i].ToString();
                str += "\n";
            }
            return str + "}";
        }
        public void AddComponent(ICoffeeComponent component)
        {
            recipe.Add(component);
        }
    }
}
