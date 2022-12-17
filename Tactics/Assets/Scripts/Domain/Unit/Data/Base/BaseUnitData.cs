using System.Collections.Generic;
using Tactics.Domain.Interface.Unit;

namespace Tactics.Domain.Unit.Data.Base {
    public abstract class BaseUnitData : IUnitData {
        public int ArmyId { get; protected set; }
        public ArmyType ArmyType { get; protected set; }
        public Affinity Affinity { get; protected set; }
        public IUnitStats GainedStats { get; protected set; }
        public IDictionary<WeaponType, int> WeaponExp { get; protected set; }
        public int HitPoints => BaseStats.HitPoints + GainedStats.HitPoints >
            MaxStats.HitPoints ?
            MaxStats.HitPoints :
            BaseStats.HitPoints + GainedStats.HitPoints;
        public int Strength => BaseStats.Strength + GainedStats.Strength >
            MaxStats.Strength ?
            MaxStats.Strength :
            BaseStats.Strength + GainedStats.Strength;
        public int Magic => BaseStats.Magic + GainedStats.Magic >
            MaxStats.Magic ?
            MaxStats.Magic :
            BaseStats.Magic + GainedStats.Magic;
        public int Skill => BaseStats.Skill + GainedStats.Skill >
            MaxStats.Skill ?
            MaxStats.Skill :
            BaseStats.Skill + GainedStats.Skill;
        public int Speed => BaseStats.Speed + GainedStats.Speed >
            MaxStats.Speed ?
            MaxStats.Speed :
            BaseStats.Speed + GainedStats.Speed;
        public int Luck => BaseStats.Luck + GainedStats.Luck >
            MaxStats.Luck ?
            MaxStats.Luck :
            BaseStats.Luck + GainedStats.Luck;
        public int Defense => BaseStats.Defense + GainedStats.Defense >
            MaxStats.Defense ?
            MaxStats.Defense :
            BaseStats.Defense + GainedStats.Defense;
        public int Resistance => BaseStats.Resistance + GainedStats.Resistance >
            MaxStats.Resistance ?
            MaxStats.Resistance :
            BaseStats.Resistance + GainedStats.Resistance;
        public int Weight => BaseStats.Weight + GainedStats.Weight >
            MaxStats.Weight ?
            MaxStats.Weight :
            BaseStats.Weight + GainedStats.Weight;
        public int Move => BaseStats.Move + GainedStats.Move >
            MaxStats.Move ?
            MaxStats.Move :
            BaseStats.Move + GainedStats.Move;
        public int Constitution => BaseStats.Constitution + GainedStats.Constitution >
            MaxStats.Constitution ?
            MaxStats.Constitution :
            BaseStats.Constitution + GainedStats.Constitution;

        public abstract string Name { get; }
        public abstract UnitClass UnitClass { get; }
        public abstract MoveType MoveType { get; }
        public abstract UnitClass PromotionClass { get; }
        public abstract IList<WeaponType> AvailableWeapons { get; }

        protected abstract IUnitStats BaseStats { get; }
        protected abstract IUnitStats StatGrowhts { get; }
        protected abstract IUnitStats MaxStats { get; }
        protected abstract IUnitStats PromotionGains { get; }

        protected static IUnitStats BaseClassPromotionGains { get; } =
            new UnitStats(
                hitPoints:0,
                strength:0,
                magic:0,
                skill:0,
                speed:0,
                luck:0,
                defense:0,
                resistance:0,
                weight:0,
                move:0,
                constitution:0);
                
        protected static IUnitStats PhysicalBaseClassMaxStats { get; } =
            new UnitStats(
                hitPoints:40,
                strength:20,
                magic:10,
                skill:20,
                speed:20,
                luck:30,
                defense:20,
                resistance:15,
                weight:20,
                move:20,
                constitution:20);

        protected BaseUnitData(
            int armyId,
            ArmyType armyType,
            Affinity affinity,
            IUnitStats gainedStats,
            IDictionary<WeaponType, int> weaponExp) {
            ArmyId = armyId;
            ArmyType = armyType;
            Affinity = affinity;
            GainedStats = gainedStats;
            WeaponExp = weaponExp;
        }
    }

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
    }
}