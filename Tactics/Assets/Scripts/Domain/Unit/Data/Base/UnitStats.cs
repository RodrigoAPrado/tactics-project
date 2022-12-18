using System.Collections.Generic;
using Tactics.Domain.Interface.Unit;

namespace Tactics.Domain.Unit.Data.Base {
    public class UnitStats : IUnitStats {
        public int HitPoints { get; }
        public int Strength { get; }
        public int Magic { get; }
        public int Skill { get; }
        public int Speed { get; }
        public int Luck { get; }
        public int Defense { get; }
        public int Resistance { get; }
        public int Weight { get; }
        public int Move { get; }
        public int Constitution { get; }

        public UnitStats(int hitPoints, int strength, int magic,
        int skill, int speed, int luck, int defense, int resistance,
        int weight, int move, int constitution) {
            HitPoints = hitPoints;
            Strength = strength;
            Magic = magic;
            Skill = skill;
            Speed = speed;
            Luck = luck;
            Defense = defense;
            Resistance = resistance;
            Weight = weight;
            Move = move;
            Constitution = constitution;
        }

        public static UnitStats GetEmpty() {
            return new UnitStats(0,0,0,0,0,0,0,0,0,0,0);
        }
    }
}