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
    public class GlovesPurchaseHandler : BasePurchaseHandler
    {
        public override void Handle(IFighter character, object equipment)
        {
            if (equipment is Gloves)
            {
                Gloves concreteElement;
                if (equipment is CheapGloves)
                {
                    concreteElement = equipment as CheapGloves;
                }
                else if (equipment is MediumGloves)
                {
                    concreteElement = equipment as MediumGloves;
                }
                else if (equipment is ExpensiveGloves)
                {
                    concreteElement = equipment as ExpensiveGloves;
                }
                else
                {
                    concreteElement = equipment as ReinforcedGloves;
                }
                if (character.Money < concreteElement.Price)
                {
                    MessageBox.Show("Недостатньо коштів!", "Помилка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                try
                {
                    character.SetGloves(concreteElement);
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
