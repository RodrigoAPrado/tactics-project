using System;
using Tactics.Controller.Scene;
using Tactics.Controller;
using Tactics.Domain.Map;
using UnityEngine;

namespace Tactics.Manager.GameState {
    public class MenuGameState : BaseGameState {
        public override UnitModalState ModalState => UnitModalState.DontShow;
        public MenuGameState(GameMapSceneContext context, GameStateManager gameStateManager) : base(context, gameStateManager)
        {

        }

        public override BaseGameState Init()
        {
            Context.Board.HideSelector();
            Context.Menu.Show();
            return this;
        }

        public override void OnDirectionalDown()
        {
            Context.Menu.NavigateDown();
        }
        public override void OnDirectionalUp()
        {
            Context.Menu.NavigateUp();
        }

        public override void OnBack()
        {
            CloseMenu();
        }

        private void CloseMenu() {
            Context.Board.ShowSelector();
            Context.Menu.Hide();
            GameStateManager.Pop();
        }

    }
}