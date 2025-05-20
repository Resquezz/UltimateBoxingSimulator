using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultimate_Boxing_Simulator.Equipment.Abstract_Products;
using Ultimate_Boxing_Simulator.Fighters;

namespace Ultimate_Boxing_Simulator.Equipment.Concrete_Products
{
    public class MediumJacket : Jacket
    {
        public MediumJacket() : base("Мотоциклетна накладка", 60, "icons/armor.jpg") { }

        public override void Apply(IFighter fighter)
        {
            fighter.UpdateEndurance(2);
            fighter.UpdateTechnique(3);
            fighter.UpdateReflexes(5);
            fighter.UpdateSpeed(-1);
        }
    }
}
