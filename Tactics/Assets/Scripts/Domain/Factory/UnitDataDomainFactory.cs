using System.Collections.Generic;
using Tactics.Domain.Interface.Unit;
using Tactics.Domain.Unit.Data;
using Tactics.Domain.Unit.Data.Generic;
using Tactics.Domain.Unit.Data.Character;
using Tactics.Domain.Unit.Data.Base;

namespace Tactics.Domain.Factory {
    public static class UnitDataDomainFactory {
        public static IUnitData CreateUnitDataByType(
            int armyId,
            ArmyType armyType,
            UnitResource unitResource,
            UnitClass unitClass,
            Affinity affinity,
            IUnitStats gainedStats,
            IDictionary<WeaponType, int> weaponExp
            ) {
            if(unitResource == UnitResource.Generic) {
                return CreateBaseUnitData(armyId, armyType, affinity, gainedStats, weaponExp, unitClass);
            }
            else{
                switch(unitResource){
                    case UnitResource.Razvan:
                    return CreateRazvanUnitData(armyId, armyType, affinity, gainedStats, weaponExp, unitClass);
                }
            }
            return null;
        }

        private static BaseUnitData CreateBaseUnitData(int armyId, ArmyType armyType, Affinity affinity, IUnitStats gainedStats,
            IDictionary<WeaponType, int> weaponExp, UnitClass unitClass) {
                switch(unitClass) {
                    case UnitClass.Fencer:
                        return CreateFencerUnitData(armyId, armyType, affinity, gainedStats, weaponExp);
                    case UnitClass.Ranger:
                        return CreateRangerUnitData(armyId, armyType, affinity, gainedStats, weaponExp);
                    case UnitClass.Test:
                        return CreateTestUnitData(armyId, armyType, affinity, gainedStats, weaponExp);
                }
                return null;
        }

        private static BaseUnitData CreateFencerUnitData(int armyId, ArmyType armyType, Affinity affinity, IUnitStats gainedStats,
            IDictionary<WeaponType, int> weaponExp) {
            return new FencerUnitData(armyId, armyType, affinity, gainedStats, weaponExp);
        }
        private static BaseUnitData CreateTestUnitData(int armyId, ArmyType armyType, Affinity affinity, IUnitStats gainedStats,
            IDictionary<WeaponType, int> weaponExp) {
            return new TestUnitData(armyId, armyType, affinity, gainedStats, weaponExp);
        }
        private static BaseUnitData CreateRangerUnitData(int armyId, ArmyType armyType, Affinity affinity, IUnitStats gainedStats,
            IDictionary<WeaponType, int> weaponExp) {
            return new RangerUnitData(armyId, armyType, affinity, gainedStats, weaponExp);
        }
        private static IUnitData CreateRazvanUnitData(int armyId, ArmyType armyType, Affinity affinity, IUnitStats gainedStats,
            IDictionary<WeaponType, int> weaponExp, UnitClass unitClass) {

            var baseUnitData = CreateBaseUnitData(armyId, armyType, affinity, gainedStats, weaponExp, unitClass);
            
            return new RazvanUnitData(armyId, armyType, affinity, gainedStats, weaponExp, baseUnitData);
        }
    }
}