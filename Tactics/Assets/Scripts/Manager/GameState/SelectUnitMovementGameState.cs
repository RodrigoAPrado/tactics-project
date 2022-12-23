using System;
using System.Linq;
using System.Collections.Generic;
using Tactics.Controller;
using Tactics.Controller.Scene;
using Tactics.Domain.Map;
using UnityEngine;
using Tactics.Domain.Interface.Unit;
using Tactics.Service;

namespace Tactics.Manager.GameState {
    public class SelectUnitMovementGameState : DefaultMapGameState {
        public override UnitModalState ModalState => UnitModalState.OnlyNotSelected;
        private IUnitDomain Unit { get; set; }
        private List<AvailableTile> Tiles { get; set; }
        public SelectUnitMovementGameState(GameMapSceneContext context, GameStateManager gameStateManager, IUnitDomain unit, List<AvailableTile> tiles) : base(context, gameStateManager)
        {
            Unit = unit;
            Tiles = tiles;
        }

        public override BaseGameState Init()
        {
            Context.Board.ShowSelector();
            return this;
        }

        
        public override void OnAccept() {
            var targetTile = Tiles.Find(o => o.TileId == Context.Board.SelectedTile.Id);
            if(targetTile != null) {
                if(targetTile.CanStay)
                   GameStateManager.Replace(new BuildUnitMovementGameState(Context, GameStateManager, Unit, Tiles, targetTile));
            }
        }

        public override void OnBack()
        {   
            Context.Board.MoveSelectorTo(Unit.TileBelowUnit);
            Context.Camera.MoveCamTo(new Vector2(Unit.TileBelowUnit.Position.X, Unit.TileBelowUnit.Position.Y));
            GameStateManager.Replace(new DefaultMapGameState(Context, GameStateManager));
        }
    }
}