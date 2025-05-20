using System.ComponentModel;
using Ultimate_Boxing_Simulator.Equipment.Abstract_Products;

namespace Ultimate_Boxing_Simulator.Fighters
{
    public interface IFighter
    {
        int Endurance { get; }
        IEnumerable<Tick> EnduranceTicks { get; }
        string Name { get; }
        int Reflexes { get; }
        IEnumerable<Tick> ReflexesTicks { get; }
        int Speed { get; }
        IEnumerable<Tick> SpeedTicks { get; }
        int Strength { get; }
        IEnumerable<Tick> StrengthTicks { get; }
        int Technique { get; }
        IEnumerable<Tick> TechniqueTicks { get; }

        void SetEndurance(int points);
        void SetName(string name);
        void SetReflexes(int points);
        void SetSpeed(int points);
        void SetStrength(int points);
        void SetTechnique(int points);
        void UpdateEndurance(int points);
        void UpdateReflexes(int points);
        void UpdateSpeed(int points);
        void UpdateStrength(int points);
        void UpdateTechnique(int points);
        object Clone();
        void SetFootwear(Footwear footwear);
        void SetJacket(Jacket jacket);
        void SetGloves(Gloves gloves);
        void UpdateMoney(int points);
        void UpdatePrediction(EnemyFighter enemy);
        string BettingPrediction { get; set; }
        int Money { get; }
        double BettingCoefficient { get; protected set; }
    }
}