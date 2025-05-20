using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultimate_Boxing_Simulator.Fighters;

namespace Ultimate_Boxing_Simulator.Equipment.PurchaseHandlers
{
    public abstract class BasePurchaseHandler : IPurchaseHandler
    {
        protected IPurchaseHandler _next;
        public abstract void Handle(IFighter character, object equipment);
        public abstract void SetNext(IPurchaseHandler handler);
    }
}
