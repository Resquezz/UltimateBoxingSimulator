using Ultimate_Boxing_Simulator.Equipment.Abstract_Products;
using Ultimate_Boxing_Simulator.Fighters;

namespace Ultimate_Boxing_Simulator.Equipment.Concrete_Products
{
    public class CheapJacket : Jacket
    {
        public CheapJacket() : base("Стара куртка", 25, "icons/armor.jpg") { }

        public override void Apply(IFighter fighter)
        {
            fighter.UpdateEndurance(2);
            fighter.UpdateTechnique(1);
            fighter.UpdateReflexes(1);
        }
    }
}
