using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultimate_Boxing_Simulator.Equipment.Abstract_Products;
using Ultimate_Boxing_Simulator.Fighters;

namespace Ultimate_Boxing_Simulator.Equipment.Concrete_Products
{
    public class MediumGloves : Gloves
    {
        public MediumGloves() : base("Боксерські рукавиці", 40, "icons/gloves.jpg") { }

        public override void Apply(IFighter fighter)
        {
            fighter.UpdateStrength(5);
        }
    }
}
