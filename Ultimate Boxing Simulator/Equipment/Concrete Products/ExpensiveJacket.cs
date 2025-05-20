using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultimate_Boxing_Simulator.Equipment.Abstract_Products;
using Ultimate_Boxing_Simulator.Fighters;

namespace Ultimate_Boxing_Simulator.Equipment.Concrete_Products
{
    public class ExpensiveJacket : Jacket
    {
        public ExpensiveJacket() : base("Бронежилет", 170, "icons/armor.jpg") { }

        public override void Apply(IFighter fighter)
        {
            fighter.UpdateEndurance(4);
            fighter.UpdateTechnique(6);
            fighter.UpdateReflexes(8);
            fighter.UpdateStrength(2);
            fighter.UpdateSpeed(-3);
        }
    }
}
