using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tactics.Manager;
using Tactics.Manager.PlayerInput;
using Tactics.Controller.Stage;
using Tactics.Controller.Menu;

namespace Tactics.Controller.Scene {

    public class GameMapSceneController : BaseSceneController
    {

        [field:SerializeField] private MapSceneCameraController Camera { get; set; }
        [field:SerializeField] private BaseStageController Stage { get; set; }
        [field:SerializeField] private MenuController Menu { get; set; }

        private GameStateManager GameState { get; set; }
        private GameMapSceneContext Context { get; set; }

        protected override void Awake() {
            base.Awake();
            Menu.Init();
            Stage.Init();
            Camera.Init(Stage);

            Context = new GameMapSceneContext(Camera, Stage, Menu);
            GameState =  new GameStateManager(Context);
        }

        public override void DoCommand(PlayerInputButton button) {
            GameState.DoCommand(button);
        }
    }

    public class GameMapSceneContext {

        public MapSceneCameraController Camera { get; }
        public BaseStageController Stage { get; }
        public MenuController Menu { get; }

        public GameMapSceneContext(MapSceneCameraController camera, BaseStageController stage, MenuController menu) {
            Camera = camera;
            Stage = stage;
            Menu = menu;
        }
    }
}