using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultimate_Boxing_Simulator.Equipment.Abstract_Factory;
using Ultimate_Boxing_Simulator.Equipment.Abstract_Products;
using Ultimate_Boxing_Simulator.Equipment.Concrete_Products;

namespace Ultimate_Boxing_Simulator.Equipment.Concrete_Fabrics
{
    public class ExpensiveEquipmentFactory : AbstractFactory
    {
        public override Footwear CreateFootwear() => new ExpensiveFootwear();

        public override Gloves CreateGloves() => new ExpensiveGloves();

        public override Jacket CreateJacket() => new ExpensiveJacket();
    }
}
