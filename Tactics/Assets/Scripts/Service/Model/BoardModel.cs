using System.Collections.Generic;
using Tactics.Domain.Interface.Board;
using Tactics.Domain.Board;
using Tactics.Domain.Board.Tile;
using Tactics.Domain.Factory;

namespace Tactics.Service.Model {
    public class BoardModel {

        public List<TileRowSetModel> tileSet { get; set; }

        public IBoardDomain ToDomain() {
            return new BoardDomain(GetTileMatrix());
        }

        private List<ITileRowDomain> GetTileMatrix() {
            var tileMatrix = new List<ITileRowDomain>();
            var y = 0;
            foreach(var tile in tileSet) {
                tileMatrix.Add(tile.ToDomain(y));
                y++;
            }

            return tileMatrix;
        }

    }

    public class TileRowSetModel {

        public List<TileModel> tileRowSet { get; set; }

        public ITileRowDomain ToDomain(int y) {
            return new TileRowDomain(GetTileRow(y));
        }

        private List<ITileDomain> GetTileRow(int y) {
            var row = new List<ITileDomain>();
            var x = 0;
            foreach(var tile in tileRowSet) {
                row.Add(tile.ToDomain(x, y));
                x++;
            }

            return row;
        }
    }
 
    public class TileModel {

        public TileType tileType { get; set; }
        public bool lordSpawn { get; set; }
        public bool playerSpawn { get; set; }
        public bool disabled { get; set; }

        public ITileDomain ToDomain(int x, int y) {

            if(disabled)
                return new TileDomain(new TilePosition(x, y), TileDataDomainFactory.CreateTileByType(TileType.Disabled), TilePreparation.None);
            return new TileDomain(new TilePosition(x, y), TileDataDomainFactory.CreateTileByType(tileType), GetTilePreparation());
        }

        private TilePreparation GetTilePreparation() {
            if(lordSpawn)
                return TilePreparation.Fixed;

            if(playerSpawn)
                return TilePreparation.Available;

            return TilePreparation.None;
        }
    }
}