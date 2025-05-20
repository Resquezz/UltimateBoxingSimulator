using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultimate_Boxing_Simulator.Equipment.Abstract_Products;
using Ultimate_Boxing_Simulator.Fighters;

namespace Ultimate_Boxing_Simulator.Equipment.PurchaseHandlers
{
    public interface IPurchaseHandler
    {
        void SetNext(IPurchaseHandler handler);
        void Handle(IFighter character, object equipment);
    }
}
