using System;
using System.Collections;
using System.Collections.Generic;
using Tactics.Manager.GameState;
using Tactics.Manager.PlayerInput;
using Tactics.Controller;
using Tactics.Controller.Scene;

namespace Tactics.Manager {
    public class GameStateManager {


        public UnitModalState ModalState => CurrentState == null ? UnitModalState.Show : CurrentState.ModalState;
        private Stack<BaseGameState> StateStack { get; set; }


        private BaseGameState CurrentState => StateStack.Count > 0 ? StateStack.Peek() : null;

        private GameMapSceneContext Context { get; set; }

        private event Action OnStateChange;

        public GameStateManager(GameMapSceneContext context) {
            Context = context;
            StateStack = new Stack<BaseGameState>();
            StateStack.Push(new DefaultMapGameState(Context, this));
        }

        public void Pop() {
            StateStack.Pop();
            OnStateChange?.Invoke();
        }

        public void Push(BaseGameState state) {
            StateStack.Push(state);
            CurrentState.Init();
            OnStateChange?.Invoke();
        }

        public void Replace(BaseGameState state) {
            var currentState = StateStack.Peek();
            if(currentState != null) {
                Pop();
                Push(state);
            }
            OnStateChange?.Invoke();
        }

        public void SubscribeToStateChange(Action action) {
            OnStateChange+= action;
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