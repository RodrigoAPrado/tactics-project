using System.Collections.Generic;
using Tactics.Domain.Unit.Data.Base;
using Tactics.Domain.Interface.Unit;

namespace Tactics.Domain.Unit.Data.Generic {
    public class FencerUnitData : InfantryUnitData {
        public override string Name => "Fencer";
        public override UnitClass UnitClass => UnitClass.Fencer;
        public override IUnitStats BaseStats => FencerBaseStats;
        public override IUnitStats StatGrowhts => FencerStatGrowths;
        public override IUnitStats MaxStats => PhysicalBaseClassMaxStats;
        public override IUnitStats PromotionGains => BaseClassPromotionGains;
        public override UnitClass PromotionClass => UnitClass.Swordmaster;
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
                move:5,
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

        public FencerUnitData(
            int armyId,
            ArmyType armyType,
            Affinity affinity,
            IUnitStats gainedStats,
            IDictionary<WeaponType, int> weaponExp): 
            base(armyId, armyType, affinity, gainedStats, weaponExp){}
    }
} 