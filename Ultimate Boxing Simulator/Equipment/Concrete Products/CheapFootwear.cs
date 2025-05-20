using Ultimate_Boxing_Simulator.Equipment.Abstract_Products;
using Ultimate_Boxing_Simulator.Fighters;

namespace Ultimate_Boxing_Simulator.Equipment.Concrete_Products
{
    public class CheapFootwear : Footwear
    {
        public CheapFootwear() : base("Старі кросівки", 15, "icons/footwear.png") { }

        public override void Apply(IFighter fighter)
        {
            fighter.UpdateSpeed(2);
        }
    }
}
