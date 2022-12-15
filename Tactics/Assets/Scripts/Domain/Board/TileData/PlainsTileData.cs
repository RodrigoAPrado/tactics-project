using Tactics.Domain.Board;
using Tactics.Domain.Interface.Board;

namespace Tactics.Domain.Board.Tile {
    public class PlainsTileData : BaseTileDataDomain {
        public override TileType Type => TileType.Plains;
    }
}