using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tactics.Manager;
using Tactics.Manager.PlayerInput;
using Tactics.Controller.Board;
using Tactics.Controller.Menu;
using Tactics.Controller.Unit;
using Tactics.Controller;

namespace Tactics.Controller.Scene {

    public class GameMapSceneController : BaseSceneController
    {

        [field:SerializeField] private MapSceneCameraController Camera { get; set; }
        [field:SerializeField] private TestMapBoardController Board { get; set; }
        [field:SerializeField] private TestMapUnitManageController Units { get; set; }
        [field:SerializeField] private MenuController Menu { get; set; }
        [field:SerializeField] private MenuController UnitMenu { get; set; }
        [field:SerializeField] private UnitModalController UnitModal { get; set; }
        [field:SerializeField] private StatsWindowController StatsWindow { get; set; }

        private GameStateManager GameState { get; set; }
        private GameMapSceneContext Context { get; set; }

        protected override void Awake() {
            base.Awake();
            Menu.Init();
            UnitMenu.Init();
            Board.Init();
            Units.Init(Board.Board);
            Camera.Init(Board);
            StatsWindow.Init();
            Context = new GameMapSceneContext(Camera, Board, Menu, UnitMenu, Units, StatsWindow);
            GameState =  new GameStateManager(Context);
            UnitModal.Init(Board, GameState);
        }

        public override void DoCommand(PlayerInputButton button) {
            GameState.DoCommand(button);
        }
    }

    public class GameMapSceneContext {

        public MapSceneCameraController Camera { get; }
        public TestMapBoardController Board { get; }
        public TestMapUnitManageController Units { get; }
        public MenuController Menu { get; }
        public MenuController UnitMenu { get; }
        
        public StatsWindowController StatsWindow { get; }

        public GameMapSceneContext(MapSceneCameraController camera, TestMapBoardController board, MenuController menu, MenuController unitMenu, 
            TestMapUnitManageController units, StatsWindowController statsWindow) {
            Camera = camera;
            Board = board;
            Menu = menu;
            Units = units;
            UnitMenu = unitMenu;
            StatsWindow = statsWindow;
        }
    }
}