using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultimate_Boxing_Simulator.Equipment.Abstract_Products;
using Ultimate_Boxing_Simulator.Strategies.CoefficientStrategies;

namespace Ultimate_Boxing_Simulator.Fighters
{
    public class EnemyFighter : ICloneable, IFighter
    {
        private ICoefficientStrategy _coefficientStrategy;
        private const int _maxPoints = 30;
        private string _bettingPrediction;
        private Gloves _gloves = null;
        private Jacket _jacket = null;
        private Footwear _footwear = null;
        public EnemyFighter(string name, int strength, int endurance, int speed, int technique, int reflexes, Gloves gloves,
            Jacket jacket, Footwear footwear)
        {
            _coefficientStrategy = new BaseCoefficientStrategy();
            Name = name;
            Strength = strength;
            Endurance = endurance;
            Speed = speed;
            Technique = technique;
            Reflexes = reflexes;
            _gloves = gloves;
            _jacket = jacket;
            _footwear = footwear;
        }
        public double BettingCoefficient { get => _coefficientStrategy.CalculateCoefficient(this); set => BettingCoefficient = value; }
        public void SetStrategy(ICoefficientStrategy strategy)
        {
            _coefficientStrategy = strategy;
        }
        public string Name { get; private set; }
        public int Endurance { get; protected set; }
        public int Reflexes { get; private set; }
        public int Speed { get; private set; }
        public int Strength { get; private set; }
        public int Technique { get; private set; }
        public IEnumerable<Tick> EnduranceTicks => GenerateTicks(Endurance, _maxPoints);
        public IEnumerable<Tick> ReflexesTicks => GenerateTicks(Reflexes, _maxPoints);
        public IEnumerable<Tick> SpeedTicks => GenerateTicks(Speed, _maxPoints);
        public IEnumerable<Tick> StrengthTicks => GenerateTicks(Strength, _maxPoints);
        public IEnumerable<Tick> TechniqueTicks => GenerateTicks(Technique, _maxPoints);

        protected IEnumerable<Tick> GenerateTicks(int value, int max)
        {
            for (int i = 0; i < max; i++)
            {
                yield return new Tick { IsFilled = i < value };
            }
        }
        public string BettingPrediction
        {
            get => _bettingPrediction;
            set
            {
                _bettingPrediction = value;
            }
        }

        public int Money => throw new NotImplementedException();

        public object Clone()
        {
            EnemyFighter clone = (EnemyFighter)MemberwiseClone();
            clone._footwear = null;
            clone._gloves = null;
            clone._jacket = null;
            return clone;
        }

        public void SetGloves(Gloves gloves)
        {
            if (_gloves == gloves)
            {
                throw new ArgumentException("Ви вже маєте цей предмет!");
            }
            _gloves = gloves;
        }
        public void SetJacket(Jacket jacket)
        {
            if (_jacket == jacket)
            {
                throw new ArgumentException("Ви вже маєте цей предмет!");
            }
            _jacket = jacket;
        }
        public void SetFootwear(Footwear footwear)
        {
            if (_footwear == footwear)
            {
                throw new ArgumentException("Ви вже маєте цей предмет!");
            }
            _footwear = footwear;
        }

        public void SetName(string name)
        {
            Name = name;
        }
        public void SetStrength(int points)
        {
            Strength = points;
        }
        public void SetReflexes(int points)
        {
            Reflexes = points;
        }
        public void SetSpeed(int points)
        {
            Speed = points;
        }
        public void SetTechnique(int points)
        {
            Technique = points;
        }
        public void SetEndurance(int points)
        {
            Endurance = points;
        }

        public void UpdateMoney(int points)
        {
            throw new NotImplementedException();
        }

        public void UpdatePrediction(EnemyFighter enemy)
        {
            throw new NotImplementedException();
        }

        public void UpdateStrength(int points)
        {
            Strength += points;
        }
        public void UpdateEndurance(int points)
        {
            Endurance += points;
        }
        public void UpdateSpeed(int points)
        {
            Speed += points;
        }
        public void UpdateTechnique(int points)
        {
            Technique += points;
        }
        public void UpdateReflexes(int points)
        {
            Reflexes += points;
        }
    }
}
