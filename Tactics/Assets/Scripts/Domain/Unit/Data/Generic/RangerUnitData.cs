using System.Collections.Generic;
using Tactics.Domain.Unit.Data.Base;
using Tactics.Domain.Interface.Unit;

namespace Tactics.Domain.Unit.Data.Generic {
    public class RangerUnitData : InfantryUnitData {
        public override string Name => "Ranger";
        public override UnitClass UnitClass => UnitClass.Ranger;
        public override IUnitStats BaseStats => RangerBaseStats;
        public override IUnitStats StatGrowhts => RangerStatGrowths;
        public override IUnitStats MaxStats => PhysicalBaseClassMaxStats;
        public override IUnitStats PromotionGains => BaseClassPromotionGains;
        public override UnitClass PromotionClass => UnitClass.Hero;
        public override IList<WeaponType> AvailableWeapons => RangerWeapons;
        private static IUnitStats RangerBaseStats { get; } =
            new UnitStats(
                hitPoints:16,
                strength:4,
                magic:0,
                skill:7,
                speed:7,
                luck:3,
                defense:3,
                resistance:1,
                weight:8,
                move:5,
                constitution:8);
        private static IUnitStats RangerStatGrowths { get; } =
            new UnitStats(
                hitPoints:55,
                strength:45,
                magic:0,
                skill:45,
                speed:45,
                luck:25,
                defense:20,
                resistance:15,
                weight:0,
                move:0,
                constitution:0);
        private static IList<WeaponType> RangerWeapons { get; } = new List<WeaponType>{
            WeaponType.Sword,
            WeaponType.Bow
        };

        public RangerUnitData(
            int armyId,
            ArmyType armyType,
            Affinity affinity,
            IUnitStats gainedStats,
            IDictionary<WeaponType, int> weaponExp): 
            base(armyId, armyType, affinity, gainedStats, weaponExp){}
    }
} 