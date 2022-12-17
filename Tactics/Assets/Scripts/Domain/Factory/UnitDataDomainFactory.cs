using System.Collections.Generic;
using Tactics.Domain.Interface.Unit;
using Tactics.Domain.Unit.Data;
using Tactics.Domain.Unit.Data.Generic;

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
                switch(unitClass) {
                    case UnitClass.Fencer:
                        return CreateFencerUnitData(armyId, armyType, affinity, gainedStats, weaponExp);
                    case UnitClass.Test:
                        return CreateTestUnitData(armyId, armyType, affinity, gainedStats, weaponExp);
                }
            }
            return null;
        }

        private static IUnitData CreateFencerUnitData(int armyId, ArmyType armyType, Affinity affinity, IUnitStats gainedStats,
            IDictionary<WeaponType, int> weaponExp) {
            return new FencerUnitData(armyId, armyType, affinity, gainedStats, weaponExp);
        }
        private static IUnitData CreateTestUnitData(int armyId, ArmyType armyType, Affinity affinity, IUnitStats gainedStats,
            IDictionary<WeaponType, int> weaponExp) {
            return new TestUnitData(armyId, armyType, affinity, gainedStats, weaponExp);
        }
    }
}