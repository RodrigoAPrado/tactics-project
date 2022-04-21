using Tactics.Manager.GameState;
using Tactics.Manager.PlayerInput;

namespace Tactics.Manager {
    public class GameStateManager {

        public static GameStateManager Instance {
            get {
                if(instance == null) {
                    instance = new GameStateManager();
                }
                return instance;
            }
        }

        private static GameStateManager instance;

        private BaseGameState CurrentState { get; set;}

        private GameStateManager() {

        }

        public void DoCommand(PlayerInputButton button) {
            switch(button) {
                
            }    
        }
    }
}