using System.Collections.Generic;
using Tactics.Domain.Unit.Data.Base;
using Tactics.Domain.Interface.Unit;

namespace Tactics.Domain.Unit.Data.Generic {
    public class TestUnitData : BaseUnitData {
        public override string Name => "Test";
        public override MoveType MoveType => MoveType.Almighty;
        public override UnitClass UnitClass => UnitClass.Test;
        protected override IUnitStats BaseStats => FencerBaseStats;
        protected override IUnitStats StatGrowhts => FencerStatGrowths;
        protected override IUnitStats MaxStats => PhysicalBaseClassMaxStats;
        protected override IUnitStats PromotionGains => BaseClassPromotionGains;
        public override UnitClass PromotionClass => UnitClass.None;
        public override IList<WeaponType> AvailableWeapons => FencerWeapons;
        private static IUnitStats FencerBaseStats { get; } =
            new UnitStats(
                hitPoints:15,
                strength:3,
                magic:0,
                skill:6,
                speed:7,
                luck:0,
                defense:2,
                resistance:0,
                weight:7,
                move:20,
                constitution:7);
        private static IUnitStats FencerStatGrowths { get; } =
            new UnitStats(
                hitPoints:50,
                strength:40,
                magic:5,
                skill:45,
                speed:50,
                luck:20,
                defense:20,
                resistance:10,
                weight:0,
                move:0,
                constitution:0);
        private static IList<WeaponType> FencerWeapons { get; } = new List<WeaponType>{
            WeaponType.Sword
        };

        public TestUnitData(
            int armyId,
            ArmyType armyType,
            Affinity affinity,
            IUnitStats gainedStats,
            IDictionary<WeaponType, int> weaponExp): 
            base(armyId, armyType, affinity, gainedStats, weaponExp){}
    }
} 