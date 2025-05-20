using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using Ultimate_Boxing_Simulator.Equipment.Abstract_Products;
using Ultimate_Boxing_Simulator.Equipment.Concrete_Products;
using Ultimate_Boxing_Simulator.Equipment.Decorators;
using Ultimate_Boxing_Simulator.Fighters;

namespace Ultimate_Boxing_Simulator.Equipment.PurchaseHandlers
{
    public class JacketPurchaseHandler : BasePurchaseHandler
    {
        public override void Handle(IFighter character, object equipment)
        {
            if (equipment is Jacket)
            {
                Jacket concreteElement;
                if (equipment is CheapJacket)
                {
                    concreteElement = equipment as CheapJacket;
                }
                else if (equipment is MediumJacket)
                {
                    concreteElement = equipment as MediumJacket;
                }
                else if (equipment is ExpensiveJacket)
                {
                    concreteElement = equipment as ExpensiveJacket;
                }
                else
                {
                    concreteElement = equipment as ReinforcedJacket;
                }
                if (character.Money < concreteElement.Price)
                {
                    MessageBox.Show("Недостатньо коштів!", "Помилка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                try
                {
                    character.SetJacket(concreteElement);
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
