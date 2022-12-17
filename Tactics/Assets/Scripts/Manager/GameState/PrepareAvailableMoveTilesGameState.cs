using System;
using System.Collections.Generic;
using Tactics.Controller.Scene;
using Tactics.Domain.Map;
using UnityEngine;
using Tactics.Domain.Interface.Unit;
using Tactics.Service;

namespace Tactics.Manager.GameState {
    public class PrepareAvailableMoveTilesGameState : BaseGameState {
        private IUnitDomain Unit { get; set; }
        private PathFindingService Service { get; set; }
        private List<AvailableTile> AvailableTiles { get; set; }
        public PrepareAvailableMoveTilesGameState(GameMapSceneContext context, GameStateManager gameStateManager, IUnitDomain unit, List<AvailableTile> availableTiles = null) : base(context, gameStateManager)
        {
            Unit = unit;
            Service = PathFindingService.Instance;
            AvailableTiles = availableTiles;
        }

        public override BaseGameState Init()
        {
            if(AvailableTiles == null)
                AvailableTiles = Service.GetSelectableTiles(Unit, Context.Board.Board);

            foreach(var tile in AvailableTiles) {
                Context.Board.HighLightTile(tile);
            }

            GameStateManager.Replace(new SelectUnitMovementGameState(Context, GameStateManager, Unit, AvailableTiles));
            
            return this;
        }

    }
}