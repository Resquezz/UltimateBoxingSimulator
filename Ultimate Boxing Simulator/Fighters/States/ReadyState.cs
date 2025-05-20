using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Ultimate_Boxing_Simulator.Fighters.States
{
    public class ReadyState : ICharacterState
    {
        public bool CanFight() => true;
        public string GetStatus() => "Готовий до бою!";
    }
}
