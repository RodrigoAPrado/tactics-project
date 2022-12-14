using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tactics.Manager;
using Tactics.Manager.PlayerInput;
using Tactics.Controller.Stage;

namespace Tactics.Controller.Scene {

    public class GameMapSceneController : BaseSceneController
    {

        [field:SerializeField] private MapSceneCameraController Camera { get; set; }
        [field:SerializeField] private BaseStageController Stage { get; set; }

        private GameStateManager GameState { get; set; }
        private GameMapSceneContext Context { get; set; }

        protected override void Awake() {
            base.Awake();
            Stage.Init();
            Camera.Init(Stage);

            Context = new GameMapSceneContext(Camera, Stage);
            GameState =  new GameStateManager(Context);
        }

        public override void DoCommand(PlayerInputButton button) {
            GameState.DoCommand(button);
        }
    }

    public class GameMapSceneContext {

        public MapSceneCameraController Camera { get; }
        public BaseStageController Stage { get; }

        public GameMapSceneContext(MapSceneCameraController camera, BaseStageController stage) {
            Camera = camera;
            Stage = stage;
        }
    }
}