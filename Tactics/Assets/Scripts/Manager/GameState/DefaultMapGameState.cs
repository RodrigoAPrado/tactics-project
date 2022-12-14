using System;
using Tactics.Controller.Scene;
using Tactics.Domain.Map;
using UnityEngine;

namespace Tactics.Manager.GameState {
    public class DefaultMapGameState : BaseGameState {
        
        public DefaultMapGameState(GameMapSceneContext context) : base(context)
        {

        }

        public override void Init()
        {
            //TODO: Verificar se precisa de inicialização.
        }

        public override void OnAccept()
        {
            var selectedUnit = Context.Stage.SelectUnit();
            if(selectedUnit == null) {

            } else {
                switch(selectedUnit.ArmyType) {
                    case UnitArmyType.Player:
                        //TODO: Avançar para estado de unidade jogável selecionada;
                    break;
                    case UnitArmyType.Enemy:
                        //TODO: Ativar zona de avanço do inimigo;
                    break;
                    case UnitArmyType.Ally:
                        //TODO: Mesma coisa que selecionar bloco vazio;
                    break;
                    case UnitArmyType.Other:
                        //TODO: kMesma coisa que selecionar bloco vazio;
                    break;
                }
            }
        }

        public override void OnDirectionalDown() {
            Context.Stage.MoveSelectorDown();
            Context.Camera.MoveCamTo(Context.Stage.SelectorPosition());
        }
        
        public override void OnDirectionalLeft() {
            Context.Stage.MoveSelectorLeft();
            Context.Camera.MoveCamTo(Context.Stage.SelectorPosition());
        }

        public override void OnDirectionalRight() {
            Context.Stage.MoveSelectorRight();
            Context.Camera.MoveCamTo(Context.Stage.SelectorPosition());
        }

        public override void OnDirectionalUp() {
            Context.Stage.MoveSelectorUp();
            Context.Camera.MoveCamTo(Context.Stage.SelectorPosition());
        }
    }
}