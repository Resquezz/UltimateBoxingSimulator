using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Ultimate_Boxing_Simulator.Equipment.Abstract_Products;
using Ultimate_Boxing_Simulator.Equipment.Concrete_Products;
using Ultimate_Boxing_Simulator.Equipment.Decorators;
using Ultimate_Boxing_Simulator.Fighters;

namespace Ultimate_Boxing_Simulator.Equipment.PurchaseHandlers
{
    public class FootwearPurchaseHandler : BasePurchaseHandler
    {
        public override void Handle(IFighter character, object equipment)
        {
            if (equipment is Footwear)
            {
                Footwear concreteElement = null;
                if (equipment is CheapFootwear)
                    concreteElement = equipment as CheapFootwear;
                else if (equipment is MediumFootwear)
                    concreteElement = equipment as MediumFootwear;
                else if (equipment is ExpensiveFootwear)
                    concreteElement = equipment as ExpensiveFootwear;
                else
                    concreteElement = equipment as ReinforcedFootwear;
                if (character.Money < concreteElement.Price)
                {
                    MessageBox.Show("Недостатньо коштів!", "Помилка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                try
                {
                    character.SetFootwear(concreteElement);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Помилка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                concreteElement.Apply(character);
                character.UpdateMoney(-concreteElement.Price);
            }
            else
            {
                if (_next is not null)
                {
                    _next.Handle(character, equipment);
                }
                else
                {
                    throw new ArgumentException("Неможливо обробити передані дані.");
                }
            }
        }

        public override void SetNext(IPurchaseHandler handler)
        {
            _next = handler;
        }
    }
}
