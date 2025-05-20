using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultimate_Boxing_Simulator.Equipment.Abstract_Products;

namespace Ultimate_Boxing_Simulator.Equipment.Abstract_Factory
{
    public abstract class AbstractFactory
    {
        public abstract Gloves CreateGloves();
        public abstract Jacket CreateJacket();
        public abstract Footwear CreateFootwear();
    }
}
