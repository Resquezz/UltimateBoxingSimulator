using Ultimate_Boxing_Simulator.Equipment.Abstract_Products;
using Ultimate_Boxing_Simulator.Fighters;

namespace Ultimate_Boxing_Simulator.Equipment.Decorators
{
    public abstract class GlovesDecorator : Gloves
    {
        protected Gloves _baseGloves;

        protected GlovesDecorator(Gloves baseGloves) : base(baseGloves.Name, baseGloves.Price, baseGloves.IconPath)
        {
            _baseGloves = baseGloves;
        }

        public override void Apply(IFighter fighter)
        {
            _baseGloves.Apply(fighter);
        }
    }
}