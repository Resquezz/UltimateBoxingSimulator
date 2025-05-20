using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultimate_Boxing_Simulator.Equipment.Abstract_Products;
using Ultimate_Boxing_Simulator.Fighters;

namespace Ultimate_Boxing_Simulator.Equipment.Concrete_Products
{
    public class ExpensiveGloves : Gloves
    {
        public ExpensiveGloves() : base("Елітні боксерські рукавиці", 130, "icons/gloves.jpg") { }

        public override void Apply(IFighter fighter)
        {
            fighter.UpdateStrength(8);
            fighter.UpdateEndurance(2);
            fighter.UpdateTechnique(1);
        }
    }
}
