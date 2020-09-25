using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeMachine
{
    class CoffeMachine
    {
        Milk milk = new Milk();
        
       
        public ICoffee CreateCoffee(int coffeType, int sugar)
        {
            

            if (coffeType == 0)
            {
                
                CoffeCapuccino capuccino = new CoffeCapuccino();
                capuccino.AddComponent(milk);
                for (int i = 0; i < sugar; i++)
                {
                    Sugar sugar1 = new Sugar(); 
                    capuccino.AddComponent(sugar1);
                }
                return capuccino;
            }
            if (coffeType==1)
            {
                
                CoffeEspresso espresso = new CoffeEspresso();
                for (int i = 0; i < sugar; i++)
                {
                    Sugar sugar1 = new Sugar();
                    espresso.AddComponent(sugar1);
                }
                return espresso;

            }
            return null;
        }
    }
}
