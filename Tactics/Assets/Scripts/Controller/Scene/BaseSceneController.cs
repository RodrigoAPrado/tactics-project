using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tactics.Manager;
using Tactics.Manager.PlayerInput;

namespace Tactics.Controller.Scene {
    
    public abstract class BaseSceneController : MonoBehaviour
    {
        [field:SerializeField] protected InputProcessingController InputController { get; set; }

        protected virtual void Awake() {
            InputController.Init(this);
        }

        public abstract void DoCommand(PlayerInputButton button);
    }
}