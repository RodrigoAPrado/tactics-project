using System.Collections.Generic;
using Tactics.Domain.Interface.Unit;
using Tactics.Domain.Unit.Data;
using Tactics.Domain.Unit.Data.Generic;
using Tactics.Domain.Unit.Data.Character;
using Tactics.Domain.Unit.Data.Base;
using Tactics.Domain.Unit.Data.Class;
using Tactics.Domain.Interface.Item.Data;

namespace Tactics.Domain.Factory {
    public static class UnitDataDomainFactory {

        private static Dictionary<UnitClass, IUnitClassData> ClassDataDic { get; set; }
            = new Dictionary<UnitClass, IUnitClassData>();

        public static IUnitData CreateUnitDataByType(
            int armyId,
            ArmyType armyType,
            UnitResource unitResource,
            UnitClass unitClass,
            Affinity affinity,
            IUnitStats gainedStats,
            Dictionary<WeaponType, int> weaponExp,
            int level, int exp
            ) {
            
            var unitClassData = GetUnitClassData(unitClass);

            switch(unitResource) {
                case UnitResource.Generic:
                    return new GenericUnitData(unitClassData, gainedStats, weaponExp,
                    affinity,
                    armyType,
                    armyId,
                    level, exp);
                case UnitResource.Razvan:
                    return new RazvanUnitData(unitClassData, gainedStats, weaponExp,
                    armyType,
                    armyId,
                    level, exp);
            }

            return null;
        }

        private static IUnitClassData GetUnitClassData(UnitClass unitClass) {
            if(!ClassDataDic.ContainsKey(unitClass)) {
                switch(unitClass) {
                    case UnitClass.Fencer:
                        ClassDataDic.Add(UnitClass.Fencer, FencerClassUnitData.Instance);
                    break;
                    case UnitClass.Ranger:
                        ClassDataDic.Add(UnitClass.Ranger, RangerClassUnitData.Instance);
                    break;
                }
            }

            return ClassDataDic[unitClass];
        }
    }
}