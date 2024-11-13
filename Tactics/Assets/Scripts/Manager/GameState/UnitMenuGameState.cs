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
    public class UnitMenuGameState : BaseGameState {
        public override UnitModalState ModalState => UnitModalState.DontShow;
        private IUnitDomain Unit { get; set; }
        private ITileDomain InitialTile { get; set; }
        //private Dictionary<int, ActionTile> Tiles { get; set; }

        public UnitMenuGameState(GameMapSceneContext context, GameStateManager gameStateManager, IUnitDomain unit, /*Dictionary<int, ActionTile> tiles,*/ ITileDomain initialTile) : base(context, gameStateManager)
        {
            Unit = unit;
            InitialTile = initialTile;
            //Tiles = tiles;
        }

        public override BaseGameState Init()
        {
            SetupOptions();
            Context.UnitMenu.Show();
            Context.UnitMenu.GoToFirstAvailableOption();
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

        private void SetupOptions() {
            if(Context.Board.Board.CanUnitAttack)
                Context.UnitMenu.EnableOption(Controller.Menu.MenuOption.Attack);
            else
                Context.UnitMenu.DisableOption(Controller.Menu.MenuOption.Attack);
            if(Context.Board.Board.CanUnitTrade)
                Context.UnitMenu.EnableOption(Controller.Menu.MenuOption.Trade);
            else
                Context.UnitMenu.DisableOption(Controller.Menu.MenuOption.Trade);
            if(Context.Board.Board.CanUnitUseItems)
                Context.UnitMenu.EnableOption(Controller.Menu.MenuOption.Items);
            else
                Context.UnitMenu.DisableOption(Controller.Menu.MenuOption.Items);
            if(Context.Board.Board.CanUnitUseShove)
                Context.UnitMenu.EnableOption(Controller.Menu.MenuOption.Shove);
            else
                Context.UnitMenu.DisableOption(Controller.Menu.MenuOption.Shove);
        }
    }
}