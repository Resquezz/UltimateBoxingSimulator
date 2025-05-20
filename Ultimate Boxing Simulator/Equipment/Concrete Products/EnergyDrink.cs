using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultimate_Boxing_Simulator.Equipment.Abstract_Products;
using Ultimate_Boxing_Simulator.Fighters;

namespace Ultimate_Boxing_Simulator.Equipment.Concrete_Products
{
    public class EnergyDrink : Booster
    {
        public EnergyDrink(string name, int price, string iconPath) : base(name, price, iconPath) { }
        public override void Apply(IFighter fighter)
        {
            
        }
    }
}
