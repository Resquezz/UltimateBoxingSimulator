using Ultimate_Boxing_Simulator.Equipment.Abstract_Products;
using Ultimate_Boxing_Simulator.Fighters;

namespace Ultimate_Boxing_Simulator.Equipment.Concrete_Products
{
    public class CheapGloves : Gloves
    {
        public CheapGloves() : base("Старі рукавиці", 15, "icons/gloves.jpg") { }

        public override void Apply(IFighter fighter)
        {
            fighter.UpdateStrength(2);
        }
    }
}
