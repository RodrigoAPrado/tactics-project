using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tactics.Manager;
using Tactics.Manager.PlayerInput;

namespace Tactics.Controller.Scene {
    
    public class GameMapSceneController : BaseSceneController
    {

        [field:SerializeField] private MapSceneCameraController Camera { get; set; }
        [field:SerializeField] private GridSelectorController Selector { get; set; }

        private GameStateManager GameState { get; set; }
        private GameMapSceneContext Context { get; set; }

        protected override void Awake() {
            base.Awake();
            Context = new GameMapSceneContext(Selector, Camera);
            GameState =  new GameStateManager(Context);
        }

        public override void DoCommand(PlayerInputButton button) {
            GameState.DoCommand(button);
        }
    }

    public class GameMapSceneContext {

        public GridSelectorController Selector { get; }
        public MapSceneCameraController Camera { get ;}

        public GameMapSceneContext(GridSelectorController selector, MapSceneCameraController camera) {
            Selector = selector;
            Camera = camera;
        }
    }
}