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
    public class ExecuteUnitMovementGameState : BaseGameState {
        public override UnitModalState ModalState => UnitModalState.DontShow;
        private IUnitDomain Unit { get; set; }
        private List<AvailableTile> Tiles { get; set; }
        private List<ITileDomain> Path { get; set; }
        public ExecuteUnitMovementGameState(GameMapSceneContext context, GameStateManager gameStateManager, IUnitDomain unit, List<AvailableTile> tiles, List<ITileDomain> path) : base(context, gameStateManager)
        {
            Unit = unit;
            Tiles = tiles;
            Path = path;
        }

        public override BaseGameState Init()
        {
            Context.Board.HideSelector();
            Context.Board.ClearHighlights();
            if(Path.Count == 1) {
                GameStateManager.Replace(new UnitMenuGameState(Context, GameStateManager, Unit, Tiles, Path[Path.Count-1]));
            }
            MoveUnit(Path.Count - 2);
            return this;
        }

        private void MoveUnit(int pathTargetIndex) {
            if(pathTargetIndex < 0) {
                GameStateManager.Replace(new UnitMenuGameState(Context, GameStateManager, Unit, Tiles, Path[Path.Count-1]));
                return;
            }
            Context.Camera.MoveCamTo(new Vector2(Path[pathTargetIndex].Position.X, Path[pathTargetIndex].Position.Y));
            Context.Units.MoveUnit(Unit, Path[pathTargetIndex], () => MoveUnit(pathTargetIndex - 1));
        }
    }
}