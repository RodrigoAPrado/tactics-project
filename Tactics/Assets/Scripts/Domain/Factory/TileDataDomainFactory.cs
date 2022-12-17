using Tactics.Domain.Interface.Board;
using Tactics.Domain.Board.Tile;

namespace Tactics.Domain.Factory {
    public static class TileDataDomainFactory {
        public static ITileDataDomain CreateTileByType(TileType tileType) {
            switch(tileType) {
                case TileType.Disabled:
                    return CreateDisabledTileData();
                case TileType.Plains:
                default:
                    return CreatePlainsTileData();
            }
        }

        private static ITileDataDomain CreatePlainsTileData() {
            return new PlainsTileData();
        }

        private static ITileDataDomain CreateDisabledTileData() {
            return new DisabledTileData();
        }
    }
}