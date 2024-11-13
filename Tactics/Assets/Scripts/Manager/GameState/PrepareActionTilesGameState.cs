using System;
using System.Linq;
using System.Collections.Generic;
using Tactics.Controller;
using Tactics.Controller.Scene;
using Tactics.Domain.Interface.Board;
using UnityEngine;
using Tactics.Domain.Interface.Unit;
using Tactics.Service;

namespace Tactics.Manager.GameState {
    public class PrepareActionTilesGameState : BaseGameState {
        public override UnitModalState ModalState => UnitModalState.DontShow;
        private IUnitDomain Unit { get; set; }
        private PathFindingService Service { get; set; }
        private ITileDomain InitialTile { get; set; }
        public PrepareActionTilesGameState(GameMapSceneContext context, GameStateManager gameStateManager, IUnitDomain unit, ITileDomain initialTile) : base(context, gameStateManager)
        {
            Unit = unit;
            InitialTile = initialTile;
            Service = PathFindingService.Instance;
        }

        public override BaseGameState Init()
        {
            //var actionTiles = Service.GetActionTiles(Unit, Context.Board.Board);
            GameStateManager.Replace(new UnitMenuGameState(Context, GameStateManager, Unit, /*actionTiles,*/ InitialTile));
            return this;
        }
    }
}