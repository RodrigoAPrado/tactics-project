using System.Collections.Generic;
using Tactics.Domain.Interface.Unit;
using Tactics.Domain.Unit.Data.Class.Base;
using Tactics.Domain.Unit.Data.Base;
using Tactics.Domain.Interface.Item.Data;

namespace Tactics.Domain.Unit.Data.Class {
    public sealed class RangerClassUnitData :  InfantryClassUnitData {

        private static IUnitClassData _instance;

        public static IUnitClassData Instance {
            get {
                if(_instance == null) {
                    _instance = new RangerClassUnitData();
                }
                return _instance;
            }
        }

        public override int ClassTier => 1;
        public override IUnitStats BaseStats => ClassBaseStats;
        public override IUnitStats Growths => ClassStatGrowths;
        public override IUnitStats MaxStats => PhysicalBaseClassMaxStats;
        public override IUnitStats PromotionGains => BaseClassPromotionGains;
        public override UnitClass UnitClass => UnitClass.Ranger;
        public override UnitClass PromotionClass => UnitClass.Hero;

        private IUnitStats ClassBaseStats { get; } =
            new UnitStats(
                hitPoints:15,
                strength:4,
                magic:0,
                skill:6,
                speed:7,
                luck:0,
                defense:4,
                resistance:0,
                weight:7,
                move:5,
                constitution:7);
        private IUnitStats ClassStatGrowths { get; } =
            new UnitStats(
                hitPoints:50,
                strength:35,
                magic:0,
                skill:45,
                speed:45,
                luck:10,
                defense:25,
                resistance:10,
                weight:0,
                move:0,
                constitution:0);

        protected override IDictionary<WeaponType, int> ClassBaseWeaponExp { get; } = new Dictionary<WeaponType, int>() {
            {WeaponType.Sword, (int) WeaponRank.E},
            {WeaponType.Bow, (int) WeaponRank.E}
        };

        private RangerClassUnitData() {
            
        }
    }
}