using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultimate_Boxing_Simulator.Fighters;

namespace Ultimate_Boxing_Simulator.Strategies.CoefficientStrategies
{
    public class BaseCoefficientStrategy : ICoefficientStrategy
    {
        public double CalculateCoefficient(IFighter fighter)
        {
            return fighter.Strength * 0.9 +
                   fighter.Technique * 0.5 +
                   fighter.Endurance * 0.6 +
                   fighter.Speed * 0.3 +
                   fighter.Reflexes * 0.5;
        }
    }
}
