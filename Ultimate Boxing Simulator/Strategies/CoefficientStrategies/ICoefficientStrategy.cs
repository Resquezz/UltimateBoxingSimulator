using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultimate_Boxing_Simulator.Fighters;

namespace Ultimate_Boxing_Simulator.Strategies.CoefficientStrategies
{
    public interface ICoefficientStrategy
    {
        double CalculateCoefficient(IFighter fighter);
    }
}
