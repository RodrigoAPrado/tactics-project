using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tactics.Domain.Map;
using Tactics.Service;
using Tactics.Domain.Interface.Board;

namespace Tactics.Controller.Board {
    public class TestMapBoardController : BaseBoardController
    {
        public override ITileDomain SelectedTile => Board.CurrentSelectedTile;
        private BoardService Service { get; set; }
        private IBoardDomain Board { get; set; }

        [field:SerializeField] private TileController TilePrefab { get; set; }

        public override void Init() {
            Service = BoardService.Instance;
            Board = Service.GetTestBoard();
            SetupBoard();
        }

        public override UnitData SelectUnit() {
            return null;
        }

        public override Vector2 GetSize() {
            return new Vector2(Board.Width,Board.Height);
        }

        private void SetupBoard() {
            for(int x = 0; x < Board.Width; x++) {
                for (int y = 0; y < Board.Height; y++) {
                    var tile = Instantiate(TilePrefab);
                    tile.transform.position = new Vector2(x, y);
                    tile.transform.SetParent(this.transform);
                    tile.Init(Board.BoardRow[y].TileRow[x]);
                }
            }
        }

        
        public override void MoveSelectorDown() {
            if(Board.MoveCursorPosition(0, -1))
                Selector.MoveTo(Board.CursorXPosition, Board.CursorYPosition);
        }

        public override void MoveSelectorLeft() {
            if(Board.MoveCursorPosition(-1, 0))
                Selector.MoveTo(Board.CursorXPosition, Board.CursorYPosition);
        }

        public override void MoveSelectorRight() {
            if(Board.MoveCursorPosition(1, 0))
                Selector.MoveTo(Board.CursorXPosition, Board.CursorYPosition);
        }

        public override void MoveSelectorUp() {
            if(Board.MoveCursorPosition(0, 1))
                Selector.MoveTo(Board.CursorXPosition, Board.CursorYPosition);
        }
    }
}
