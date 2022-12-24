using System;
using System.Collections.Generic;
using Tactics.Domain.Interface.Board;
using Tactics.Domain.Interface.Unit;

namespace Tactics.Domain.Board {

    public class BoardDomain : IBoardDomain
    {
        public int Width => _boardRow[0].TileRow.Count;
        public int Height => _boardRow.Count;
        public IList<ITileRowDomain> BoardRow => _boardRow.AsReadOnly();
        private List<ITileRowDomain> _boardRow { get; set; }
        public ITileDomain CurrentSelectedTile => _boardRow[CursorYPosition].TileRow[CursorXPosition];
        public int CursorXPosition { get; private set; }
        public int CursorYPosition { get; private set; }
        public IUnitDomain SelectedUnit { get; private set; }
        public bool CanUnitAttack { 
            get {
                //var range = SelectedUnit.AttackRange;
                var leftTile = GetTileOnPosition(SelectedUnit.TileBelowUnit.Position.X-1, SelectedUnit.TileBelowUnit.Position.Y);
                var rightTile = GetTileOnPosition(SelectedUnit.TileBelowUnit.Position.X+1, SelectedUnit.TileBelowUnit.Position.Y);
                var upTile = GetTileOnPosition(SelectedUnit.TileBelowUnit.Position.X, SelectedUnit.TileBelowUnit.Position.Y+1);
                var downTile = GetTileOnPosition(SelectedUnit.TileBelowUnit.Position.X, SelectedUnit.TileBelowUnit.Position.Y-1);
                if(leftTile != null && !leftTile.Empty && leftTile.UnitOnTile.ArmyType == ArmyType.Enemy)
                    return true;
                if(rightTile != null && !rightTile.Empty && rightTile.UnitOnTile.ArmyType == ArmyType.Enemy)
                    return true;
                if(upTile != null && !upTile.Empty && upTile.UnitOnTile.ArmyType == ArmyType.Enemy)
                    return true;
                if(downTile != null && !downTile.Empty && downTile.UnitOnTile.ArmyType == ArmyType.Enemy)
                    return true;
                return false;
            }
        }

        public bool CanUnitTrade { 
            get {
                return false;
            }
        }
        
        public bool CanUnitUseItems { 
            get {
                return false;
            }
        }
        
        public bool CanUnitUseShove { 
            get {
                return false;
            }
        }

        public BoardDomain(List<ITileRowDomain> boardRow) {
            _boardRow = boardRow;
            ValidateBoard();
        }

        public void Init() {
            //TODO
        }

        private void ValidateBoard() {
            var hasLord = false;
            foreach(var row in _boardRow) {
                foreach(var tile in row.TileRow) {
                    if(tile.TilePreparation == TilePreparation.Fixed) {
                        hasLord = true;
                        break;
                    }
                }
                if(hasLord)
                    break;
            }

            if(!hasLord)
                throw new System.Exception("Board must have a lord spawn!");
        }

        public bool MoveCursorPosition(int x, int y) {
            var targetY = CursorYPosition + y;
            var targetX = CursorXPosition + x;
            
            if(targetY < 0 || targetY >= _boardRow.Count)
                return false;

            var row = _boardRow[targetY];
            
            if(targetX < 0 || targetX >= row.TileRow.Count)
                return false;

            var tile = row.TileRow[targetX];
            
            if(tile.Data.Disabled)
                return false;

            CursorYPosition = targetY;
            CursorXPosition = targetX;
            return true;
        }

        public bool MoveCursorToSpecificPosition(ITileDomain tile) {
            CursorYPosition = tile.Position.Y;
            CursorXPosition = tile.Position.X;
            return true;
        }

        public ITileDomain GetTileOnPosition(int x, int y) {

            if(y < 0 || y >= _boardRow.Count)
                return null;
            var row = _boardRow[y];
            if(x < 0 || x >= row.TileRow.Count)
                return null;

            var tile = row.TileRow[x];

            if(tile.Data.Disabled)
                return null;

            return tile;
        }
        
        public ITileDomain GetTileById(Guid id) {
            ITileDomain resultTile = null;
            foreach(var row in _boardRow) {
                foreach(var tile in row.TileRow) {
                    if(tile.Id == id) {
                        resultTile = tile;
                        break;
                    }
                }
                if(resultTile != null)
                    break;
            }
            return resultTile;
        }

        public void SelectUnit(IUnitDomain unit) {
            SelectedUnit = unit;
        }
        public void UnselectUnit() {
            SelectedUnit = null;
        }
    }

    public class TileRowDomain : ITileRowDomain {

        public IList<ITileDomain> TileRow => _tileRow.AsReadOnly();
        private List<ITileDomain> _tileRow { get; set; }

        public TileRowDomain(List<ITileDomain> tileRow) {
            _tileRow = tileRow;
        }
    }

    public class TileDomain : ITileDomain {
        public Guid Id { get;private set; }
        public bool Empty => UnitOnTile == null;
        public ITilePosition Position { get; private set; }
        public TilePreparation TilePreparation { get; private set; }
        public IUnitDomain UnitOnTile { get; private set; }
        public ITileDataDomain Data { get; private set; }

        public TileDomain(ITilePosition position, ITileDataDomain data, TilePreparation tilePreparation) {
            Id = Guid.NewGuid();
            Position = position;
            Data = data;
            TilePreparation = tilePreparation;
        }

        public void AddUnitOnTile(IUnitDomain unit) {
            UnitOnTile = unit;
        }
        public void RemoveUnitFromTile() {
            UnitOnTile = null;
        }

        public ITileMoveInteractionResult GetTileUnitInteraction(IUnitDomain unit, int remainingMove) {
            if(Data.Disabled)
                return TileMoveInteractionResult.GetBlockedTile();

            var moveCost = CanUnitWalkTile(unit, remainingMove);

            if(moveCost <= 0)
                return TileMoveInteractionResult.GetBlockedTile();

            if(!Empty) {
                if(unit.ArmyType != UnitOnTile.ArmyType)
                    return TileMoveInteractionResult.GetBlockedTile();
                return new TileMoveInteractionResult(TileMoveInteraction.OnlyWalkable, moveCost);
            }

            if (Data.UnitsCanStay)
                return new TileMoveInteractionResult(TileMoveInteraction.CanStay, moveCost);

            return new TileMoveInteractionResult(TileMoveInteraction.OnlyWalkable, moveCost);
        }

        private int CanUnitWalkTile(IUnitDomain unit, int remainingMove) {
            var moveCost = Data.CheckMoveCostByMoveType(unit.GetMovementType());
            if(moveCost <= remainingMove )
                return moveCost;
            return 0;
        }
    }

    public class TilePosition : ITilePosition {
        public int X { get; private set; }
        public int Y { get; private set; }

        public TilePosition(int x, int y) {
            X = x;
            Y = y;
        }
    }

    

    public class TileMoveInteractionResult : ITileMoveInteractionResult {
        public TileMoveInteraction Interaction { get; }
        public int MoveCost { get; }

        public TileMoveInteractionResult(TileMoveInteraction interaction, int moveCost) {
            Interaction = interaction;
            MoveCost = moveCost;
        }

        public static ITileMoveInteractionResult GetBlockedTile() {
            return new TileMoveInteractionResult(TileMoveInteraction.Blocked, 0);
        }
    }
}