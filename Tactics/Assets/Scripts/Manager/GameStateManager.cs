using System;
using System.Collections;
using System.Collections.Generic;
using Tactics.Manager.GameState;
using Tactics.Manager.PlayerInput;
using Tactics.Controller.Scene;

namespace Tactics.Manager {
    public class GameStateManager {

        private Stack<BaseGameState> StateStack { get; set; }


        private BaseGameState CurrentState => StateStack.Peek();

        private GameMapSceneContext Context { get; set; }

        public GameStateManager(GameMapSceneContext context) {
            Context = context;
            StateStack = new Stack<BaseGameState>();
            StateStack.Push(new DefaultMapGameState(Context));
            CurrentState.Init();
        }

        public void DoCommand(PlayerInputButton button) {
            switch(button) {
                case PlayerInputButton.Down:
                    CurrentState.OnDirectionalDown();
                break;
                case PlayerInputButton.Left:
                    CurrentState.OnDirectionalLeft();
                break;
                case PlayerInputButton.Right:
                    CurrentState.OnDirectionalRight();
                break;
                case PlayerInputButton.Up:
                    CurrentState.OnDirectionalUp();
                break;
                case PlayerInputButton.Accept:
                    CurrentState.OnAccept();
                break;
                case PlayerInputButton.Back:
                    CurrentState.OnBack();
                break;
                case PlayerInputButton.EnemyToggle:
                    CurrentState.OnEnemyToggle();
                break;
                case PlayerInputButton.Help:
                    CurrentState.OnHelp();
                break;
                case PlayerInputButton.BackInTime:
                    CurrentState.OnBackInTime();
                break;
                case PlayerInputButton.NextAlly:
                    CurrentState.OnNextAlly();
                break;
                case PlayerInputButton.MapMenu:
                    CurrentState.OnMapMenu();
                break;
                case PlayerInputButton.PreviousAlly:
                    CurrentState.OnPreviousAlly();
                break;
                case PlayerInputButton.ZoomToggle:
                    CurrentState.OnZoomToggle();
                break;
                case PlayerInputButton.GameMenu:
                    CurrentState.OnMapMenu();
                break;
            }
        }
    }
}