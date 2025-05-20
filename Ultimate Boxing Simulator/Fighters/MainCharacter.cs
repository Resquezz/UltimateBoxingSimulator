using System.ComponentModel;
using System.Runtime.CompilerServices;
using Ultimate_Boxing_Simulator.Equipment.Abstract_Products;
using Ultimate_Boxing_Simulator.Fighters.States;
using Ultimate_Boxing_Simulator.Strategies.CoefficientStrategies;

namespace Ultimate_Boxing_Simulator.Fighters
{
    public class MainCharacter : IFighter
    {
        private const int _maxPoints = 30;
        private static MainCharacter _instance = null;
        private string _bettingPrediction;
        private Gloves _gloves = null;
        private Jacket _jacket = null;
        private Footwear _footwear = null;
        private ICharacterState _currentState;
        private ICoefficientStrategy _coefficientStrategy;
        public double BettingCoefficient { get => _coefficientStrategy.CalculateCoefficient(this); set => BettingCoefficient = value; }
        public void SetStrategy(ICoefficientStrategy strategy)
        {
            _coefficientStrategy = strategy;
        }
        public int Money { get; set; }
        private MainCharacter()
        {
            _coefficientStrategy = new BaseCoefficientStrategy();
            _currentState = new ReadyState();
            SetName("*Користувацьке ім\'я*");
            SetStrength(4);
            SetEndurance(4);
            SetReflexes(4);
            SetSpeed(4);
            SetTechnique(4);
            Money = 100;
        }
        public string BettingPrediction
        {
            get => _bettingPrediction;
            set
            {
                _bettingPrediction = value;
            }
        }
        public bool CanFight() => _currentState.CanFight();
        public string Status => _currentState.GetStatus();
        public void SetState(ICharacterState state)
        {
            _currentState = state;
        }
        public void UpdatePrediction(EnemyFighter enemy)
        {
            if (enemy != null)
            {
                BettingPrediction = BettingCoefficient > enemy.BettingCoefficient ? "Перемога" : "Поразка";
            }
            else
            {
                BettingPrediction = "Невідомо";
            }
        }
        public static MainCharacter Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MainCharacter();
                return _instance;
            }
        }
        public string Name { get; private set; }
        public int Endurance { get; protected set; } = 4;
        public int Reflexes { get; private set; } = 4;
        public int Speed { get; private set; } = 4;
        public int Strength { get; private set; } = 4;
        public int Technique { get; private set; } = 4;
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
        public void UpdateMoney(int points)
        {
            Money += points;
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

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
    public class Tick
    {
        public bool IsFilled { get; set; }
    }
}
