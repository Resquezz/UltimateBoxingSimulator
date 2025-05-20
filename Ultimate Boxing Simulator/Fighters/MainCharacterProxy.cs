using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Ultimate_Boxing_Simulator.Equipment.Abstract_Products;
using Ultimate_Boxing_Simulator.Fighters.States;
using Ultimate_Boxing_Simulator.Strategies.CoefficientStrategies;

namespace Ultimate_Boxing_Simulator.Fighters
{
    public class MainCharacterProxy : IFighter, INotifyPropertyChanged
    {
        private readonly IFighter _mainCharacter;
        private ObservableCollection<string> _logs;
        public ObservableCollection<string> Logs
        {
            get => _logs;
            private set
            {
                _logs = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public bool CanFight()
        {
            var character = _mainCharacter as MainCharacter;
            bool canFight = character.CanFight();
            if (!canFight)
                _logs.Add($"Не можу битися: {(_mainCharacter as MainCharacter).Status}");
            return canFight;
        }
        public void SetState(ICharacterState state)
        {
            var character = _mainCharacter as MainCharacter;
            character.SetState(state);
        }
        public string Status => (_mainCharacter as MainCharacter).Status;
        public MainCharacterProxy(IFighter realFighter)
        {
            _mainCharacter = realFighter;
            _logs = new ObservableCollection<string>();

            if (_mainCharacter is INotifyPropertyChanged notify)
            {
                notify.PropertyChanged += (s, e) =>
                {
                    OnPropertyChanged(e.PropertyName);
                };
            }
        }

        public string Name => _mainCharacter.Name;
        public int Strength => _mainCharacter.Strength;
        public int Endurance => _mainCharacter.Endurance;
        public int Speed => _mainCharacter.Speed;
        public int Technique => _mainCharacter.Technique;
        public int Reflexes => _mainCharacter.Reflexes;
        public int Money => _mainCharacter.Money;
        public double BettingCoefficient { get => _mainCharacter.BettingCoefficient; set => throw new ArgumentException(); }
        public void SetStrategy(ICoefficientStrategy strategy)
        {
            var character = _mainCharacter as MainCharacter;
            character.SetStrategy(strategy);
        }
        public string BettingPrediction
        {
            get => _mainCharacter.BettingPrediction;
            set => _mainCharacter.BettingPrediction = value;
        }

        public IEnumerable<Tick> StrengthTicks => _mainCharacter.StrengthTicks;
        public IEnumerable<Tick> EnduranceTicks => _mainCharacter.EnduranceTicks;
        public IEnumerable<Tick> SpeedTicks => _mainCharacter.SpeedTicks;
        public IEnumerable<Tick> TechniqueTicks => _mainCharacter.TechniqueTicks;
        public IEnumerable<Tick> ReflexesTicks => _mainCharacter.ReflexesTicks;

        public void UpdateStrength(int points)
        {
            _logs.Add($"Зміна сили: {points}. Нова сила: {_mainCharacter.Strength + points}");
            _mainCharacter.UpdateStrength(points);
            OnPropertyChanged(nameof(Strength));
            OnPropertyChanged(nameof(StrengthTicks));
        }

        public void UpdateEndurance(int points)
        {
            _logs.Add($"Зміна витривалості: {points}. Нова витривалість: {_mainCharacter.Endurance + points}");
            _mainCharacter.UpdateEndurance(points);
            OnPropertyChanged(nameof(Endurance));
            OnPropertyChanged(nameof(EnduranceTicks));
        }

        public void UpdateSpeed(int points)
        {
            _logs.Add($"Зміна швидкості: {points}. Нова швидкість: {_mainCharacter.Speed + points}");
            _mainCharacter.UpdateSpeed(points);
            OnPropertyChanged(nameof(Speed));
            OnPropertyChanged(nameof(SpeedTicks));
        }

        public void UpdateTechnique(int points)
        {
            _logs.Add($"Зміна техніки: {points}. Нова техніка: {_mainCharacter.Technique + points}");
            _mainCharacter.UpdateTechnique(points);
            OnPropertyChanged(nameof(Technique));
            OnPropertyChanged(nameof(TechniqueTicks));
        }

        public void UpdateReflexes(int points)
        {
            _logs.Add($"Зміна рефлексів: {points}. Нові рефлекси: {_mainCharacter.Reflexes + points}");
            _mainCharacter.UpdateReflexes(points);
            OnPropertyChanged(nameof(Reflexes));
            OnPropertyChanged(nameof(ReflexesTicks));
        }

        public void SetFootwear(Footwear footwear)
        {
            _logs.Add($"Куплено нові кросівки. Назва: {footwear.Name}");
            _mainCharacter.SetFootwear(footwear);
        }

        public void SetGloves(Gloves gloves)
        {
            _logs.Add($"Куплено нові рукавиці. Назва: {gloves.Name}");
            _mainCharacter.SetGloves(gloves);
        }

        public void SetJacket(Jacket jacket)
        {
            _logs.Add($"Куплено нову куртку. Назва: {jacket.Name}");
            _mainCharacter.SetJacket(jacket);
        }

        public void UpdateMoney(int points)
        {
            _mainCharacter.UpdateMoney(points);
            OnPropertyChanged(nameof(Money));
        }

        public void UpdatePrediction(EnemyFighter enemy)
        {
            _mainCharacter.UpdatePrediction(enemy);
            OnPropertyChanged(nameof(BettingPrediction));
        }

        public void SetEndurance(int points)
        {
            _mainCharacter.SetEndurance(points);
        }

        public void SetName(string name)
        {
            _mainCharacter.SetName(name);
        }

        public void SetReflexes(int points)
        {
            _mainCharacter.SetReflexes(points);
        }

        public void SetSpeed(int points)
        {
            _mainCharacter.SetSpeed(points);
        }

        public void SetStrength(int points)
        {
            _mainCharacter.SetStrength(points);
        }

        public void SetTechnique(int points)
        {
            _mainCharacter.SetTechnique(points);
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
