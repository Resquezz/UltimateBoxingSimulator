using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultimate_Boxing_Simulator.Equipment.Abstract_Products;
using Ultimate_Boxing_Simulator.Fighters;

namespace Ultimate_Boxing_Simulator.Equipment.Decorators
{
    public class ReinforcedFootwear : FootwearDecorator
    {
        public ReinforcedFootwear(Footwear baseFootwear) : base(baseFootwear)
        {
            Name = $"{baseFootwear.Name} (Посилені)";
            Price += 20;
        }

        public override void Apply(IFighter fighter)
        {
            base.Apply(fighter);
            fighter.UpdateSpeed(2);
        }
    }
}
