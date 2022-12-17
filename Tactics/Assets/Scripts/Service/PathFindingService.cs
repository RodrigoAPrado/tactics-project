using System;
using System.Linq;
using System.Collections.Generic;
using Tactics.Domain.Interface.Board;
using Tactics.Domain.Interface.Unit;

namespace Tactics.Service {
    public class PathFindingService {
        
        private static PathFindingService _instance;
        public static PathFindingService Instance {
            get {
                if(_instance == null) {
                    _instance = new PathFindingService();
                }
                return _instance;
            }
        }

        private PathFindingService() {

        }

        public List<AvailableTile> GetSelectableTiles(IUnitDomain unit, IBoardDomain board) {
            var availableTiles = new List<AvailableTile>();
            var tile = unit.TileBelowUnit;
            
            availableTiles.Add(new AvailableTile(tile.Id, TileMoveInteraction.CanStay, tile.Position, unit.Move, 0, null));

            for(int i = 0; i < availableTiles.Count; i++) {
                if(availableTiles[i].Obsolete)
                    continue;
                var remainingMove = availableTiles[i].RemainingMove;
                foreach(var adjacentTile in FindAdjacentTiles(availableTiles[i], board)) {
                    if(adjacentTile == null)
                        continue;

                    var tileAlreadyAdded = availableTiles.Find(o => o.TileId == adjacentTile.Id);

                    if(tileAlreadyAdded != null) {
                        if(tileAlreadyAdded.RemainingMove + tileAlreadyAdded.MovementCost < remainingMove) {
                            tileAlreadyAdded.SetObsolete();
                        }
                        else {
                            continue;
                        }
                    }


                    var interactionResult = adjacentTile.GetTileUnitInteraction(unit, remainingMove);

                    if(interactionResult.Interaction != TileMoveInteraction.Blocked) {
                        availableTiles.Add(new AvailableTile(adjacentTile.Id, interactionResult.Interaction, adjacentTile.Position, remainingMove - interactionResult.MoveCost, interactionResult.MoveCost, availableTiles[i]));
                    }
                }
            }
            return availableTiles.Where(o => !o.Obsolete).ToList();
        }

        private ITileDomain[] FindAdjacentTiles(AvailableTile tile, IBoardDomain board) {
            var leftTile = board.GetTileOnPosition(tile.Position.X-1, tile.Position.Y);
            var upTile = board.GetTileOnPosition(tile.Position.X, tile.Position.Y+1);
            var rightTile = board.GetTileOnPosition(tile.Position.X+1, tile.Position.Y);
            var downTile = board.GetTileOnPosition(tile.Position.X, tile.Position.Y-1);

            ITileDomain[] adjacentTiles = {leftTile, upTile, rightTile, downTile};
            return adjacentTiles;
        }
    }

    public class AvailableTile {
        public bool CanStay => Interaction == TileMoveInteraction.CanStay;
        public AvailableTile PreviousTile { get; private set; }
        public Guid TileId { get; private set; }
        public TileMoveInteraction Interaction { get; private set; }
        public ITilePosition Position { get; private set; }
        public int RemainingMove { get; private set; }
        public int MovementCost { get; private set; }
        public bool Obsolete { get; private set; }

        public AvailableTile(Guid tileId, TileMoveInteraction interaction, ITilePosition position, int remainingMove, int movementCost, AvailableTile previousTile) {
            TileId = tileId;
            Interaction = interaction;
            Position = position;
            RemainingMove = remainingMove;
            MovementCost = movementCost;
            Obsolete = false;
            PreviousTile = previousTile;
        }

        public void SetObsolete() {
            Obsolete = true;
        }
    }
}