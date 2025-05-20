using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultimate_Boxing_Simulator.Equipment.Abstract_Products;
using Ultimate_Boxing_Simulator.Fighters;

namespace Ultimate_Boxing_Simulator.Equipment.Decorators
{
    public abstract class JacketDecorator : Jacket
    {
        protected Jacket _baseJacket;

        protected JacketDecorator(Jacket baseJacket) : base(baseJacket.Name, baseJacket.Price, baseJacket.IconPath)
        {
            _baseJacket = baseJacket;
        }
        public override void Apply(IFighter fighter)
        {
            _baseJacket.Apply(fighter);
        }
    }
}
