using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tactics.Manager;
using Tactics.Manager.PlayerInput;

namespace Tactics.Controller {
    public class InputProcessingController : MonoBehaviour
    {
        [SerializeField]
        private readonly float inputDelayDelta;
        private float InputDelay { get; set; }

        private GameStateManager GameState { get; set; } 

        private void Awake() {
            GameState = GameStateManager.Instance;
        }

        private void Update()
        {
            if(InputDelay > 0) {
                InputDelay -= Time.deltaTime;
            }
        }

        public void ProcessPressInput(PlayerInputButton button) {
            if(InputDelay > 0)
                return;
            InputDelay = inputDelayDelta;
            Debug.Log($"Pressing{button.ToString()}");
        }


        public void ProcessHoldInput(PlayerInputButton button) {
            
        }

    }

    
}
