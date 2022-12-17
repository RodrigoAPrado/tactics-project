using System;
using System.Linq;
using System.Collections.Generic;
using Tactics.Controller.Scene;
using Tactics.Domain.Map;
using UnityEngine;
using Tactics.Domain.Interface.Unit;
using Tactics.Service;

namespace Tactics.Manager.GameState {
    public class SelectUnitMovementGameState : DefaultMapGameState {
        private IUnitDomain Unit { get; set; }
        private List<AvailableTile> Tiles { get; set; }
        public SelectUnitMovementGameState(GameMapSceneContext context, GameStateManager gameStateManager, IUnitDomain unit, List<AvailableTile> tiles) : base(context, gameStateManager)
        {
            Unit = unit;
            Tiles = tiles;
        }

        public override BaseGameState Init()
        {
            return this;
        }

        
        public override void OnAccept() {
            var targetTile = Tiles.Find(o => o.TileId == Context.Board.SelectedTile.Id);
            if(targetTile != null) {
                GameStateManager.Replace(new BuildUnitMovementGameState(Context, GameStateManager, Unit, Tiles, targetTile));
            }
        }
    }
}