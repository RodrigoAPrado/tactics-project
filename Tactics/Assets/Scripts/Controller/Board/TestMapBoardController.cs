using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tactics.Domain.Map;
using Tactics.Service;
using Tactics.Domain.Interface.Board;
using Tactics.Domain.Interface.Unit;

namespace Tactics.Controller.Board {
    public class TestMapBoardController : BaseBoardController
    {
        public override ITileDomain SelectedTile => Board.CurrentSelectedTile;
        private BoardService Service { get; set; }
        public IBoardDomain Board { get; private set; }

        [field:SerializeField] private TileController TilePrefab { get; set; }

        private List<TileController> TileControllers { get; set; }

        public override void Init() {
            Service = BoardService.Instance;
            Board = Service.GetTestBoard();
            SetupBoard();
        }

        public override IUnitDomain SelectUnit() {
            return SelectedTile.UnitOnTile;
        }

        public override Vector2 GetSize() {
            return new Vector2(Board.Width,Board.Height);
        }

        private void SetupBoard() {
            TileControllers = new List<TileController>();
            for(int x = 0; x < Board.Width; x++) {
                for (int y = 0; y < Board.Height; y++) {
                    var tile = Instantiate(TilePrefab);
                    tile.transform.position = new Vector2(x, y);
                    tile.transform.SetParent(this.transform);
                    tile.Init(Board.BoardRow[y].TileRow[x]);
                    TileControllers.Add(tile);
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

        public override void HighLightTile(AvailableTile tile)
        {
            var tileController = TileControllers.Find(o => o.Id == tile.TileId);
            tileController?.SetState(tile.Interaction);
        }
    }
}
