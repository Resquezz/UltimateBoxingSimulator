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
using Ultimate_Boxing_Simulator.Fighters.States;

namespace Ultimate_Boxing_Simulator.Equipment.PurchaseHandlers
{
    public class BoostersHandler : BasePurchaseHandler
    {
        public override void Handle(IFighter character, object equipment)
        {
            if (equipment is Booster element)
            {
                if (character.Money < element.Price)
                {
                    MessageBox.Show("Недостатньо коштів!", "Помилка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                var mainCharacter = character as MainCharacterProxy;
                if (mainCharacter.Status == "Ви травмовані!" && equipment is HealingPot pot)
                {
                    mainCharacter.SetState(new ReadyState());
                }
                else if (mainCharacter.Status == "Ви стомлені!" && equipment is EnergyDrink drink)
                {
                    mainCharacter.SetState(new ReadyState());
                }
                else
                {
                    try
                    {
                        throw new ArgumentException("Ви здорові!");
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, "Помилка!", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                character.UpdateMoney(-element.Price);
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
