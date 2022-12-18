using System.Collections.Generic;
using Tactics.Domain.Interface.Unit;
using Tactics.Domain.Unit.Data.Base;
using Tactics.Domain.Interface.Item.Data;

namespace Tactics.Domain.Unit.Data.Class.Base {
    public abstract class BaseClassUnitData : IUnitClassData {

        public virtual int MaxLevel => 20;
        public abstract int ClassTier { get; }
        public abstract IUnitStats BaseStats { get; }
        public abstract IUnitStats Growths { get; }
        public abstract IUnitStats MaxStats { get; }
        public abstract IUnitStats PromotionGains { get; }
        public abstract MoveType MoveType { get; }
        public abstract UnitClass UnitClass { get; }
        public abstract UnitClass PromotionClass { get; }
        public bool CanPromote => PromotionClass != UnitClass.None;
        public IDictionary<WeaponType, int> BaseWeaponExp { get; } = new Dictionary<WeaponType, int>() {
            {WeaponType.Sword, 0},
            {WeaponType.Axe, 0},
            {WeaponType.Lance, 0},
            {WeaponType.Knife, 0},
            {WeaponType.Bow, 0},
            {WeaponType.Fire, 0},
            {WeaponType.Thunder, 0},
            {WeaponType.Wind, 0},
            {WeaponType.Light, 0},
            {WeaponType.Dark, 0},
            {WeaponType.Staves, 0},
            {WeaponType.Dragon, 0},
            {WeaponType.Monster, 0},
        };

        protected abstract IDictionary<WeaponType, int> ClassBaseWeaponExp { get; }

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

        protected BaseClassUnitData() {
            AddBaseClassWeaponExp();
        }

        protected void AddBaseClassWeaponExp() {
            foreach(var weaponExp in ClassBaseWeaponExp) {
                BaseWeaponExp[weaponExp.Key] = weaponExp.Value;
            }
        }
    }
}
