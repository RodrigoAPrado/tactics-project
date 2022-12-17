using System.Collections.Generic;
using Tactics.Domain.Unit.Data.Base;
using Tactics.Domain.Interface.Unit;

namespace Tactics.Domain.Unit.Data.Character {
    public class RazvanUnitData : InfantryUnitData {
        public override string Name => "Razvan";
        public override UnitClass UnitClass => BaseClass.UnitClass;
        public override IUnitStats BaseStats => RazvanBaseStats;
        public override IUnitStats StatGrowhts => RazvanStatGrowths;
        public override IUnitStats MaxStats => BaseClass.MaxStats;
        public override IUnitStats PromotionGains => BaseClass.PromotionGains;
        public override UnitClass PromotionClass => BaseClass.PromotionClass;
        public override IList<WeaponType> AvailableWeapons => BaseClass.AvailableWeapons;

        private BaseUnitData BaseClass { get; set; }

        private static IUnitStats RazvanBaseStats { get; } =
            new UnitStats(
                hitPoints:20,
                strength:7,
                magic:0,
                skill:7,
                speed:8,
                luck:2,
                defense:5,
                resistance:2,
                weight:8,
                move:5,
                constitution:8);
        private static IUnitStats RazvanStatGrowths { get; } =
            new UnitStats(
                hitPoints:75,
                strength:55,
                magic:10,
                skill:60,
                speed:55,
                luck:30,
                defense:40,
                resistance:30,
                weight:0,
                move:0,
                constitution:0);

        public RazvanUnitData(
            int armyId,
            ArmyType armyType,
            Affinity affinity,
            IUnitStats gainedStats,
            IDictionary<WeaponType, int> weaponExp, BaseUnitData baseClass):
            base(armyId, armyType, affinity, gainedStats, weaponExp){
                BaseClass = baseClass;
            }
    }
} 