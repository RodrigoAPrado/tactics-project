using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tactics.Domain.Map;

namespace Tactics.Controller.Stage {
    public abstract class BaseStageController : MonoBehaviour
    {
        [field:SerializeField] protected GridSelectorController Selector { get; set; }

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
    }
}
