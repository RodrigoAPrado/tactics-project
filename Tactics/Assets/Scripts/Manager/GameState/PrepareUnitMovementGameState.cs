using System;
using Tactics.Controller.Scene;
using Tactics.Domain.Map;
using UnityEngine;
using Tactics.Domain.Interface.Unit;
using Tactics.Service;

namespace Tactics.Manager.GameState {
    public class PrepareUnitMovementGameState : BaseGameState {
        private IUnitDomain Unit { get; set; }
        private PathFindingService Service { get; set; }
        public PrepareUnitMovementGameState(GameMapSceneContext context, GameStateManager gameStateManager, IUnitDomain unit) : base(context, gameStateManager)
        {
            Unit = unit;
            Service = PathFindingService.Instance;
        }

        public override BaseGameState Init()
        {
            return this;
        }

    }
}