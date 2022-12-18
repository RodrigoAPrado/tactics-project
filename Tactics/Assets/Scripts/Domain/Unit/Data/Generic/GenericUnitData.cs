using System.Collections.Generic;
using Tactics.Domain.Interface.Unit;
using Tactics.Domain.Interface.Item.Data;

namespace Tactics.Domain.Unit.Data.Generic {

    public class GenericUnitData : IUnitData {

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

        public virtual UnitClass UnitClass => ClassData.UnitClass;
        public virtual MoveType MoveType => ClassData.MoveType;
        public virtual UnitClass PromotionClass => ClassData.PromotionClass;

        protected virtual IUnitStats BaseStats => ClassData.BaseStats;
        protected virtual IUnitStats Growths => ClassData.Growths;
        protected IUnitStats MaxStats => ClassData.MaxStats;

        protected virtual IDictionary<WeaponType, int> BaseWeaponExp => ClassData.BaseWeaponExp;
        public virtual string Name => ClassData.UnitClass.ToString();
        public int Level => _level > 20 ? 20 : _level; 
        private int ClassTier => ClassData.ClassTier;
        public int TotalLevel => ((ClassTier - 1) * 20) + Level;
        public bool CanPromote => ClassData.CanPromote;
        
        protected IUnitClassData ClassData { get; private set; }
        protected IUnitStats GainedStats { get; private set; }
        protected Dictionary<WeaponType, int> GainedWeaponExp { get; private set; }
        public Affinity UnitAffinity { get; private set; }
        public ArmyType UnitArmyType { get; private set; }
        public int ArmyId { get; private set; }
        protected int _level { get; private set; }
        public int Exp { get; private set; }

        public GenericUnitData(IUnitClassData classData, IUnitStats gainedStats, Dictionary<WeaponType, int> gainedWeaponExp,
            Affinity affinity, ArmyType armyType, int armyId, int level, int exp) {
            ClassData = classData;
            GainedStats = gainedStats;
            GainedWeaponExp = gainedWeaponExp;
            UnitAffinity = affinity;
            UnitArmyType = armyType;
            ArmyId = armyId;
            _level = level;
            Exp = exp;
        }

        public int GetWeaponExpByType(WeaponType type) {
            return GainedWeaponExp.ContainsKey(type) ? BaseWeaponExp[type] + GainedWeaponExp[type] : BaseWeaponExp[type];
        }
    }
}
