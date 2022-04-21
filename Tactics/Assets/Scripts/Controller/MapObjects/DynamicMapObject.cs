using System.Collections;
using System.Collections.Generic;
using Tactics.Domain.Map;
using UnityEngine;

namespace Tactics.Controller.MapObjects {
    
    public abstract class DynamicMapObject<T> : MapObject<T>
        where T : MapData
    { 
        public virtual void Move(GridPoint nextPosition) {
            objectData.Move(nextPosition);
        }
    }
}


        