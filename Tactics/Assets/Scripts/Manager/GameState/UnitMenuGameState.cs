using System;
using System.Linq;
using System.Collections.Generic;
using Tactics.Controller.Scene;
using Tactics.Domain.Interface.Board;
using UnityEngine;
using Tactics.Domain.Interface.Unit;
using Tactics.Service;

namespace Tactics.Manager.GameState {
    public class UnitMenuGameState : BaseGameState {
        private IUnitDomain Unit { get; set; }
        private List<AvailableTile> Tiles { get; set; }
        private ITileDomain InitialTile { get; set; }

        public UnitMenuGameState(GameMapSceneContext context, GameStateManager gameStateManager, IUnitDomain unit, List<AvailableTile> tiles, ITileDomain initialTile) : base(context, gameStateManager)
        {
            Unit = unit;
            Tiles = tiles;
            InitialTile = initialTile;
        }

        public override BaseGameState Init()
        {
            Context.UnitMenu.Show();
            return this;
        }

        public override void OnAccept()
        {
            switch(Context.UnitMenu.GetCurrentMenuOption()) {
                case Controller.Menu.MenuOption.Wait:
                    Unit.FinishTurn();
                    Context.UnitMenu.Hide();
                    GameStateManager.Replace(new DefaultMapGameState(Context, GameStateManager));
                break;
            }
        }

        public override void OnDirectionalDown()
        {
            Context.UnitMenu.NavigateDown();
        }
        public override void OnDirectionalUp()
        {
            Context.UnitMenu.NavigateUp();
        }

        public override void OnBack()
        {
            CloseMenu();
        }

        private void CloseMenu() {
            Context.UnitMenu.Hide();
            Context.Units.MoveUnit(Unit, InitialTile, () => {}, true);
            Context.Board.MoveSelectorTo(InitialTile);
            Context.Camera.MoveCamTo(new Vector2(Unit.TileBelowUnit.Position.X, Unit.TileBelowUnit.Position.Y));
            GameStateManager.Replace(new DefaultMapGameState(Context, GameStateManager));
        }
    }
}