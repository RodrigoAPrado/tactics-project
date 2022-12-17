using System.Collections.Generic;
using Tactics.Domain.Interface.Unit;

namespace Tactics.Domain.Unit.Data.Base {
    public abstract class InfantryUnitData : BaseUnitData {
        public override MoveType MoveType => MoveType.Infantry;

        protected InfantryUnitData(
            int armyId,
            ArmyType armyType,
            Affinity affinity,
            IUnitStats gainedStats,
            IDictionary<WeaponType, int> weaponExp): 
            base(armyId, armyType, affinity, gainedStats, weaponExp){}
    }
}