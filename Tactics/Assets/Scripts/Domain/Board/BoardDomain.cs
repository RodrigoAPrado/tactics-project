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
    }

    public class TileRowDomain : ITileRowDomain {

        public IList<ITileDomain> TileRow => _tileRow.AsReadOnly();
        private List<ITileDomain> _tileRow { get; set; }

        public TileRowDomain(List<ITileDomain> tileRow) {
            _tileRow = tileRow;
        }
    }

    public class TileDomain : ITileDomain {
        public TilePreparation TilePreparation { get; private set; }
        public IUnitDomain UnitOnTile { get; private set; }
        public ITileDataDomain Data { get; private set; }

        public TileDomain(ITileDataDomain data, TilePreparation tilePreparation) {
            Data = data;
            TilePreparation = tilePreparation;
        }
    }
}