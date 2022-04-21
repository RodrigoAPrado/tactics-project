using System.Collections;
using System.Collections.Generic;
using Tactics.Domain.Map;
using UnityEngine;

namespace Tactics.Controller.MapObjects {
    
    public abstract class MapObject<T> : MonoBehaviour
        where T : MapData
    { 
        [SerializeField]
        protected T objectData;

        public T ObjectData => objectData;
    }
}
