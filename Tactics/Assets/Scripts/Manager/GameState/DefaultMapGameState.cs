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
            return this;
        }

        public override void OnAccept()
        {
            var selectedUnit = Context.Board.SelectUnit();
            if(selectedUnit == null) {
                GameStateManager.Push(new MenuGameState(Context, GameStateManager).Init());
            } else {
                switch(selectedUnit.ArmyType) {
                    case ArmyType.Player:
                        if(selectedUnit.CurrentState == UnitState.Ready)
                            GameStateManager.Push(new PrepareUnitMovementGameState(Context, GameStateManager, selectedUnit));
                        else
                            GameStateManager.Push(new MenuGameState(Context, GameStateManager).Init());
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