using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultimate_Boxing_Simulator.Fighters;

namespace Ultimate_Boxing_Simulator.Equipment.Abstract_Products
{
    public interface IEquipment
    {
        public string Name { get; }
        public int Price { get; }
        public string IconPath { get; }
        abstract void Apply(IFighter fighter);
    }
}
