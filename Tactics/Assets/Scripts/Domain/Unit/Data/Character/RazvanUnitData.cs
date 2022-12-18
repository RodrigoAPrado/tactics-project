using System.Collections.Generic;
using Tactics.Domain.Interface.Unit;
using Tactics.Domain.Unit.Data.Generic;
using Tactics.Domain.Unit.Data.Class;
using Tactics.Domain.Unit.Data.Base;

namespace Tactics.Domain.Unit.Data.Character {
    public class RazvanUnitData : GenericUnitData {

        protected override IDictionary<WeaponType, int> BaseWeaponExp { get; } = new Dictionary<WeaponType, int>() {
            {WeaponType.Sword, (int) WeaponRank.D},
            {WeaponType.Bow, (int) WeaponRank.E}
        };

        public override string Name => "Razvan";
        private static Affinity CharacterAffinity => Affinity.Earth;
        private static int BaseLevel => 5;

        protected override IUnitStats BaseStats { get; } =
            new UnitStats(
                hitPoints:23,
                strength:9,
                magic:2,
                skill:9,
                speed:11,
                luck:5,
                defense:6,
                resistance:5,
                weight:7,
                move:5,
                constitution:7);

                
        protected override IUnitStats Growths { get; } =
            new UnitStats(
                hitPoints:90,
                strength:50,
                magic:10,
                skill:65,
                speed:55,
                luck:25,
                defense:35,
                resistance:20,
                weight:0,
                move:0,
                constitution:0);

        public static RazvanUnitData GetBaseCharacter(ArmyType armyType, int armyId) {
            return new RazvanUnitData(
                RangerClassUnitData.Instance,
                UnitStats.GetEmpty(),
                new Dictionary<WeaponType, int>(),
                armyType,
                armyId,
                BaseLevel,
                0);
        }

        public RazvanUnitData(IUnitClassData classData, IUnitStats gainedStats, Dictionary<WeaponType, int> gainedWeaponExp, ArmyType armyType, 
        int armyId, int level, int exp) : base(classData, gainedStats, gainedWeaponExp,
            CharacterAffinity, armyType, armyId, level, exp) {
                
        }
    }
} 