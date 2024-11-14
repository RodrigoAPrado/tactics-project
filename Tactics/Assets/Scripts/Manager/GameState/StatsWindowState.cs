using Tactics.Controller.Scene;

namespace Tactics.Manager.GameState
{
    public class StatsWindowState : BaseGameState 
    {
        public StatsWindowState(GameMapSceneContext context, GameStateManager gameStateManager) : base(context, gameStateManager)
        {

        }

        public override BaseGameState Init()
        {
            Context.StatsWindow.Show(Context.Board.SelectedUnit);
            return this;
        }

        public override void OnBack()
        {
            Context.StatsWindow.Hide();
            GameStateManager.Pop();
        }

        public override void OnHelp()
        {
            Context.StatsWindow.Hide();
            GameStateManager.Pop();
        }
    }
}