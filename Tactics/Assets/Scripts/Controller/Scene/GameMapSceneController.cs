using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tactics.Manager;
using Tactics.Manager.PlayerInput;
using Tactics.Controller.Board;
using Tactics.Controller.Menu;
using Tactics.Controller;

namespace Tactics.Controller.Scene {

    public class GameMapSceneController : BaseSceneController
    {

        [field:SerializeField] private MapSceneCameraController Camera { get; set; }
        [field:SerializeField] private BaseBoardController Board { get; set; }
        [field:SerializeField] private MenuController Menu { get; set; }

        [field:SerializeField] private UnitModalController UnitModal { get; set; }

        private GameStateManager GameState { get; set; }
        private GameMapSceneContext Context { get; set; }

        protected override void Awake() {
            base.Awake();
            Menu.Init();
            Board.Init();
            UnitModal.Init(Board);
            Camera.Init(Board);

            Context = new GameMapSceneContext(Camera, Board, Menu);
            GameState =  new GameStateManager(Context);
        }

        public override void DoCommand(PlayerInputButton button) {
            GameState.DoCommand(button);
        }
    }

    public class GameMapSceneContext {

        public MapSceneCameraController Camera { get; }
        public BaseBoardController Board { get; }
        public MenuController Menu { get; }

        public GameMapSceneContext(MapSceneCameraController camera, BaseBoardController board, MenuController menu) {
            Camera = camera;
            Board = board;
            Menu = menu;
        }
    }
}