using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultimate_Boxing_Simulator.Equipment.Abstract_Products;
using Ultimate_Boxing_Simulator.Fighters;

namespace Ultimate_Boxing_Simulator.Equipment.Decorators
{
    public abstract class FootwearDecorator : Footwear
    {
        protected Footwear _baseFootwear;

        protected FootwearDecorator(Footwear baseFootwear) : base(baseFootwear.Name, baseFootwear.Price, baseFootwear.IconPath)
        {
            _baseFootwear = baseFootwear;
        }

        public override void Apply(IFighter fighter)
        {
            _baseFootwear.Apply(fighter);
        }
    }
}
