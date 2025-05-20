using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultimate_Boxing_Simulator.Equipment.Abstract_Products;
using Ultimate_Boxing_Simulator.Fighters;

namespace Ultimate_Boxing_Simulator.Equipment.Concrete_Products
{
    class ExpensiveFootwear : Footwear
    {
        public ExpensiveFootwear() : base("Професійні кросівки", 110, "icons/footwear.png") { }

        public override void Apply(IFighter fighter)
        {
            fighter.UpdateSpeed(9);
            fighter.UpdateEndurance(3);
            fighter.UpdateTechnique(2);
        }
    }
}
