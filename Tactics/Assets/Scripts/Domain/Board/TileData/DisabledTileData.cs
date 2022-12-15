using Tactics.Domain.Board;
using Tactics.Domain.Interface.Board;
using Tactics.Domain.Interface.Unit;

namespace Tactics.Domain.Board.Tile {
    public class DisabledTileData : BaseTileDataDomain {
        public override bool Disabled => true;
        public override TileType Type => TileType.Disabled;

        public override int CheckMoveCostByMoveType(MoveType moveType) {
            return -1;
        }

        public override void ApplyEffectsOnUnit(IUnitDomain unit) {
            //Do Nothing
        }
    }
}