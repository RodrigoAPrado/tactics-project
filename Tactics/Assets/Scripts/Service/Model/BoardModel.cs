using System.Collections.Generic;
using Tactics.Domain.Interface.Board;
using Tactics.Domain.Board;
using Tactics.Domain.Board.Tile;

namespace Tactics.Service.Model {
    public class BoardModel {

        public List<TileRowSetModel> tileSet { get; set; }

        public IBoardDomain ToDomain() {
            return new BoardDomain(GetTileMatrix());
        }

        private List<ITileRowDomain> GetTileMatrix() {
            var tileMatrix = new List<ITileRowDomain>();
            
            foreach(var tile in tileSet) {
                tileMatrix.Add(tile.ToDomain());
            }

            return tileMatrix;
        }

    }

    public class TileRowSetModel {

        public List<TileModel> tileRowSet { get; set; }

        public ITileRowDomain ToDomain() {
            return new TileRowDomain(GetTileRow());
        }

        private List<ITileDomain> GetTileRow() {
            var row = new List<ITileDomain>();
            foreach(var tile in tileRowSet) {
                row.Add(tile.ToDomain());
            }

            return row;
        }
    }
 
    public class TileModel {

        public TileType tileType { get; set; }
        public bool lordSpawn { get; set; }
        public bool playerSpawn { get; set; }
        public bool disabled { get; set; }

        public ITileDomain ToDomain() {

            if(disabled)
                return new TileDomain(TileDataDomainFactory.CreateTileByType(TileType.Disabled), TilePreparation.None);
            return new TileDomain(TileDataDomainFactory.CreateTileByType(tileType), GetTilePreparation());
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