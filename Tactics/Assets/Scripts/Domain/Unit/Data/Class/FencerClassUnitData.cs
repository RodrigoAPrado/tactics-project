using System.Collections.Generic;
using Tactics.Domain.Interface.Unit;
using Tactics.Domain.Unit.Data.Class.Base;
using Tactics.Domain.Unit.Data.Base;
using Tactics.Domain.Interface.Item.Data;

namespace Tactics.Domain.Unit.Data.Class {
    public class FencerClassUnitData :  InfantryClassUnitData {

        private static IUnitClassData _instance;

        public static IUnitClassData Instance {
            get {
                if(_instance == null) {
                    _instance = new FencerClassUnitData();
                }
                return _instance;
            }
        }

        public override int ClassTier => 1;
        public override IUnitStats BaseStats => ClassBaseStats;
        public override IUnitStats Growths => ClassStatGrowths;
        public override IUnitStats MaxStats => PhysicalBaseClassMaxStats;
        public override IUnitStats PromotionGains => BaseClassPromotionGains;
        public override UnitClass UnitClass => UnitClass.Fencer;
        public override UnitClass PromotionClass => UnitClass.Swordmaster;

        private IUnitStats ClassBaseStats { get; } =
            new UnitStats(
                hitPoints:15,
                strength:2,
                magic:0,
                skill:5,
                speed:9,
                luck:0,
                defense:2,
                resistance:0,
                weight:6,
                move:5,
                constitution:6);
        private IUnitStats ClassStatGrowths { get; } =
            new UnitStats(
                hitPoints:40,
                strength:30,
                magic:0,
                skill:45,
                speed:60,
                luck:20,
                defense:20,
                resistance:5,
                weight:0,
                move:0,
                constitution:0);

        protected override IDictionary<WeaponType, int> ClassBaseWeaponExp { get; } = new Dictionary<WeaponType, int>() {
            {WeaponType.Sword, (int) WeaponRank.D}
        };

        private FencerClassUnitData() {
            
        }
    }
}