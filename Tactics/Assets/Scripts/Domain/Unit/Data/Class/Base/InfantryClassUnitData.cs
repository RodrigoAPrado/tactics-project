using Tactics.Domain.Interface.Unit;

namespace Tactics.Domain.Unit.Data.Class.Base {

    public abstract class InfantryClassUnitData : BaseClassUnitData {
        public override MoveType MoveType => MoveType.Infantry;
    }
}
