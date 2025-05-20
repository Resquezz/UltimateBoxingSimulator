using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ultimate_Boxing_Simulator.Fighters.States
{
    public class InjuredState : ICharacterState
    {
        public bool CanFight() => false;
        public string GetStatus() => "Ви травмовані!";
    }
}
