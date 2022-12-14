using System;
using Tactics.Controller.Scene;

namespace Tactics.Manager.GameState {
    public class DefaultMapGameState : BaseGameState {
        
        public DefaultMapGameState(GameMapSceneContext context) : base(context)
        {

        }

        public override void OnDirectionalDown() {
            Context.Selector.Move(0, -1);
            Context.Camera.MoveCamTo(Context.Selector.SelectorPosition);
        }
        
        public override void OnDirectionalLeft() {
            Context.Selector.Move(-1, 0);
            Context.Camera.MoveCamTo(Context.Selector.SelectorPosition);
        }

        public override void OnDirectionalRight() {
            Context.Selector.Move(1, 0);
            Context.Camera.MoveCamTo(Context.Selector.SelectorPosition);
        }

        public override void OnDirectionalUp() {
            Context.Selector.Move(0, 1);
            Context.Camera.MoveCamTo(Context.Selector.SelectorPosition);
        }
    }
}