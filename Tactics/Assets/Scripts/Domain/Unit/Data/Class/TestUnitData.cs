using System.Collections.Generic;
using Tactics.Domain.Interface.Unit;
using Tactics.Domain.Unit.Data.Class.Base;
using Tactics.Domain.Unit.Data.Base;

namespace Tactics.Domain.Unit.Data.Class {
    public class TestClassUnitData :  InfantryClassUnitData {
        public override int ClassTier => 1;
        public override IUnitStats BaseStats { get; }
        public override IUnitStats Growths { get; }
        public override IUnitStats MaxStats { get; }
        public override IUnitStats PromotionGains { get; }
        public override UnitClass UnitClass { get; }
        public override UnitClass PromotionClass { get; }

        protected override IDictionary<WeaponType, int> ClassBaseWeaponExp { get; } = new Dictionary<WeaponType, int>() {
            {WeaponType.Sword, (int) WeaponRank.E},
            {WeaponType.Bow, (int) WeaponRank.E}
        };

        public TestClassUnitData(IUnitStats baseStats, IUnitStats growths, IUnitStats maxStats, IUnitStats promotionGains, UnitClass unitClass, 
            UnitClass promotionClass, IDictionary<WeaponType, int> classBaseWeaponExp) {
            BaseStats = baseStats;
            Growths = growths;
            MaxStats = maxStats;
            PromotionGains = promotionGains;
            UnitClass = unitClass;
            PromotionClass = promotionClass;
            ClassBaseWeaponExp = classBaseWeaponExp;
        }
    }
}