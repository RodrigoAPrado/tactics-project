using System;
using Tactics.Controller.Scene;
using Tactics.Domain.Map;
using UnityEngine;
using Tactics.Domain.Interface.Unit;
using Tactics.Service;

namespace Tactics.Manager.GameState {
    public class PrepareAvailableMoveTilesGameState : BaseGameState {
        private IUnitDomain Unit { get; set; }
        private PathFindingService Service { get; set; }
        public PrepareAvailableMoveTilesGameState(GameMapSceneContext context, GameStateManager gameStateManager, IUnitDomain unit) : base(context, gameStateManager)
        {
            Unit = unit;
            Service = PathFindingService.Instance;
        }

        public override BaseGameState Init()
        {
            var availableTiles = Service.GetSelectableTiles(Unit, Context.Board.Board);
            foreach(var tile in availableTiles) {
                Context.Board.HighLightTile(tile);
            }

            GameStateManager.Replace(new SelectUnitMovementGameState(Context, GameStateManager, Unit, availableTiles));
            
            return this;
        }

    }
}