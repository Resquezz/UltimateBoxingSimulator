using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultimate_Boxing_Simulator.Fighters;

namespace Ultimate_Boxing_Simulator.Equipment.Abstract_Products
{
    public abstract class Booster : IEquipment
    {
        public string Name { get; protected set; }
        public int Price { get; protected set; } = 0;
        public string IconPath { get; protected set; }

        protected Booster(string name, int price, string iconPath)
        {
            Name = name;
            Price = price;
            IconPath = iconPath;
        }

        public abstract void Apply(IFighter fighter);
    }
}
