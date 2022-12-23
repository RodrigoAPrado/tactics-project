using System;
using Tactics.Controller.Scene;
using Tactics.Domain.Map;
using Tactics.Domain.Interface.Unit;
using UnityEngine;

namespace Tactics.Manager.GameState {
    public class DefaultMapGameState : BaseGameState {
        
        public DefaultMapGameState(GameMapSceneContext context, GameStateManager gameStateManager) : base(context, gameStateManager)
        {

        }

        public override BaseGameState Init()
        {
            Context.Board.UnselectUnit();
            Context.Board.ClearHighlights();
            Context.Board.ShowSelector();
            return this;
        }

        public override void OnAccept()
        {
            var selectedUnit = Context.Board.UnitOnSelectedTile();
            if(selectedUnit == null) {
                GameStateManager.Push(new MenuGameState(Context, GameStateManager));
            } else {
                switch(selectedUnit.ArmyType) {
                    case ArmyType.Player:
                        if(selectedUnit.CurrentState == UnitState.Ready)
                            GameStateManager.Replace(new PrepareAvailableMoveTilesGameState(Context, GameStateManager, selectedUnit));
                        else
                            GameStateManager.Push(new MenuGameState(Context, GameStateManager));
                    break;
                    case ArmyType.Enemy:
                        //TODO: Ativar zona de avanço do inimigo;
                    break;
                    case ArmyType.Ally:
                        //TODO: Mesma coisa que selecionar bloco vazio;
                    break;
                    case ArmyType.Other:
                        //TODO: kMesma coisa que selecionar bloco vazio;
                    break;
                }
            }
        }

        public override void OnMapMenu()
        {
            GameStateManager.Push(new MenuGameState(Context, GameStateManager).Init());
        }

        public override void OnDirectionalDown() {
            Context.Board.MoveSelectorDown();
            Context.Camera.MoveCamTo(Context.Board.SelectorPosition());
        }

        public override void OnDirectionalLeft() {
            Context.Board.MoveSelectorLeft();
            Context.Camera.MoveCamTo(Context.Board.SelectorPosition());
        }

        public override void OnDirectionalRight() {
            Context.Board.MoveSelectorRight();
            Context.Camera.MoveCamTo(Context.Board.SelectorPosition());
        }

        public override void OnDirectionalUp() {
            Context.Board.MoveSelectorUp();
            Context.Camera.MoveCamTo(Context.Board.SelectorPosition());
        }
    }
}