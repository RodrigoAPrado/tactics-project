using System;
using Tactics.Controller.Scene;
using Tactics.Domain.Map;
using UnityEngine;

namespace Tactics.Manager.GameState {
    public class MenuGameState : BaseGameState {
        public MenuGameState(GameMapSceneContext context, GameStateManager gameStateManager) : base(context, gameStateManager)
        {

        }

        public override BaseGameState Init()
        {
            Context.Stage.HideSelector();
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
            Context.Stage.ShowSelector();
            Context.Menu.Hide();
            GameStateManager.Pop();
        }

    }
}