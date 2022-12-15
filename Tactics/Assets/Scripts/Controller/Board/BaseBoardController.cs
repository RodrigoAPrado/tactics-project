using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tactics.Domain.Map;
using Tactics.Domain.Interface.Board;


namespace Tactics.Controller.Board {
    public abstract class BaseBoardController : MonoBehaviour
    {
        [field:SerializeField] protected GridSelectorController Selector { get; set; }

        public virtual ITileDomain SelectedTile => null;

        public abstract void Init();

        public abstract Vector2 GetSize();

        public abstract UnitData SelectUnit();

        public virtual void MoveSelectorDown() {
            if(Selector.SelectorPosition.y <=0 )
                return;
            Selector.Move(0, -1);
        }

        public virtual void MoveSelectorLeft() {
            if(Selector.SelectorPosition.x <=0 )
                return;
            Selector.Move(-1, 0);
        }

        public virtual void MoveSelectorRight() {
            if(Selector.SelectorPosition.x >= GetSize().x-1)
                return;
            Selector.Move(1, 0);
        }

        public virtual void MoveSelectorUp() {
            if(Selector.SelectorPosition.y >= GetSize().y-1)
                return;
            Selector.Move(0, 1);
        }

        public virtual Vector2 SelectorPosition() {
            return Selector.SelectorPosition;
        }

        public void HideSelector() {
            Selector.Hide();
        }

        public void ShowSelector() {
            Selector.Show();
        }

        public void SubscribeToSelector(Action action) {
            Selector.SubscribeToMovement(action);
        }
    }
}
