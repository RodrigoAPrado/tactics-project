using Tactics.Manager.GameState;
using Tactics.Manager.PlayerInput;
using Tactics.Controller.Scene;

namespace Tactics.Manager {
    public class GameStateManager {

        private BaseGameState CurrentState { get; set; }

        private GameMapSceneContext Context { get; set; }

        public GameStateManager(GameMapSceneContext context) {
            Context = context;
            CurrentState = new DefaultMapGameState(Context);
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
            }
        }
    }
}