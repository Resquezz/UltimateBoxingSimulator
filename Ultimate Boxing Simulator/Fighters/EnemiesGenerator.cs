using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultimate_Boxing_Simulator.Equipment.Abstract_Factory;
using Ultimate_Boxing_Simulator.Equipment.Abstract_Products;
using Ultimate_Boxing_Simulator.Equipment.Concrete_Fabrics;
using Ultimate_Boxing_Simulator.Strategies.CoefficientStrategies;

namespace Ultimate_Boxing_Simulator.Fighters
{
    public class EnemiesGenerator
    {
        private List<string> Names = new List<string>
        {
            "Саша \"Клинок\"",
            "Діма \"Гром\"",
            "Вітя \"Скорпіон\"",
            "Льоша \"Тінь\"",
            "Серьога \"Бик\"",
            "Тьома \"Сталь\"",
            "Коля \"Вогонь\"",
            "Макс \"Кіготь\"",
            "Женя \"Ворон\"",
            "Паша \"Дим\""
        };
        public List<EnemyFighter> Generate(int amount)
        {
            var randomizer = new Random();
            double[] weights = new double[]
            {
                0.65, 0.2, 0.1, 0.05
            };

            Gloves gloves = GetGloves(weights);
            Jacket jacket = GetJacket(weights);
            Footwear footwear = GetFootwear(weights);
            var enemies = new List<EnemyFighter>(amount)
            {
                new EnemyFighter(Names[randomizer.Next(0, 10)], randomizer.Next(1, 11), randomizer.Next(1, 11), randomizer.Next(1, 11),
                randomizer.Next(1, 11), randomizer.Next(1, 11), gloves, jacket, footwear)
            };
            for(int i = 1; i < amount; ++i)
            {
                enemies.Add((EnemyFighter)enemies[0].Clone());
                enemies[i].SetStrategy(new IncreasedSpeedValueStrategy());
                enemies[i].SetName(Names[randomizer.Next(0, 10)]);
                enemies[i].SetEndurance(randomizer.Next(1, 11));
                enemies[i].SetReflexes(randomizer.Next(1, 11));
                enemies[i].SetSpeed(randomizer.Next(1, 11));
                enemies[i].SetStrength(randomizer.Next(1, 11));
                enemies[i].SetTechnique(randomizer.Next(1, 11));
            }
            return enemies;
        }
        private Gloves GetGloves(double[] weights)
        {
            Gloves gloves = null;
            var randomizer = new Random();
            var factory = new AbstractFactory[]
            {
                new CheapEquipmentFactory(),
                new MediumEquipmentFactory(),
                new ExpensiveEquipmentFactory()
            };
            double roll = randomizer.NextDouble();
            double cumulative = 0;
            for (int i = 0; i < weights.Length; i++)
            {
                cumulative += weights[i];
                if (roll <= cumulative)
                {
                    if (i == 0) gloves = null;
                    else if (i == 1) gloves = factory[0].CreateGloves();
                    else if (i == 2) gloves = factory[1].CreateGloves();
                    else if (i == 3) gloves = factory[2].CreateGloves();
                }
            }
            return gloves;
        }
        private Footwear GetFootwear(double[] weights)
        {
            Footwear footwear = null;
            var randomizer = new Random();
            var factory = new AbstractFactory[]
            {
                new CheapEquipmentFactory(),
                new MediumEquipmentFactory(),
                new ExpensiveEquipmentFactory()
            };
            double roll = randomizer.NextDouble();
            double cumulative = 0;
            for (int i = 0; i < weights.Length; i++)
            {
                cumulative += weights[i];
                if (roll <= cumulative)
                {
                    if (i == 0) footwear = null;
                    else if (i == 1) footwear = factory[0].CreateFootwear();
                    else if (i == 2) footwear = factory[1].CreateFootwear();
                    else if (i == 3) footwear = factory[2].CreateFootwear();
                }
            }
            return footwear;
        }
        private Jacket GetJacket(double[] weights)
        {
            Jacket jacket = null;
            var randomizer = new Random();
            var factory = new AbstractFactory[]
            {
                new CheapEquipmentFactory(),
                new MediumEquipmentFactory(),
                new ExpensiveEquipmentFactory()
            };
            double roll = randomizer.NextDouble();
            double cumulative = 0;
            for (int i = 0; i < weights.Length; i++)
            {
                cumulative += weights[i];
                if (roll <= cumulative)
                {
                    if (i == 0) jacket = null;
                    else if (i == 1) jacket = factory[0].CreateJacket();
                    else if (i == 2) jacket = factory[1].CreateJacket();
                    else if (i == 3) jacket = factory[2].CreateJacket();
                }
            }
            return jacket;
        }
    }
}
