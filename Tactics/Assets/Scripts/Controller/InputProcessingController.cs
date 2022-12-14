using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tactics.Manager;
using Tactics.Manager.PlayerInput;
using Tactics.Controller.Scene;

namespace Tactics.Controller {
    public class InputProcessingController : MonoBehaviour
    {
        [field: SerializeField] private float InputDelayDelta { get; set; }
        [field: SerializeField] private float HoldDelayDelta { get; set; }
        private float InputDelay { get; set; }
        private float HoldDelay { get; set; }

        private BaseSceneController SceneController { get; set; }
        private List<PlayerInputButton> ActiveHoldButtons { get; } = new List<PlayerInputButton>();


        private void Update()
        {
            if(InputDelay > 0) {
                InputDelay -= Time.deltaTime;
            }

            if(HoldDelay > 0) {
                HoldDelay -= Time.deltaTime;
            }

            if(ActiveHoldButtons.Count > 0) {
                if(HoldDelay <= 0) {
                    HoldDelay = HoldDelayDelta;
                    var inputToDo = ActiveHoldButtons[0];
                    SceneController.DoCommand(inputToDo);
                    ActiveHoldButtons.RemoveAt(0);
                    ActiveHoldButtons.Add(inputToDo);
                }
            }
        }

        public void Init(BaseSceneController scene) {
            SceneController = scene;
        }

        public void ProcessPressInput(PlayerInputButton button) {
            if(InputDelay > 0)
                return;
            InputDelay = InputDelayDelta;
            SceneController.DoCommand(button);
        }

        public void ProcessDirectionalPressInput(PlayerInputButton button) {
            if(ShouldAcknowledgeDirectionalInput(button)) {
                ProcessPressInput(button);
            }
        }

        public void ProcessHoldInput(PlayerInputButton button) {
            if(!ActiveHoldButtons.Contains(button)) {
                if(ShouldAcknowledgeDirectionalInput(button))
                    ActiveHoldButtons.Add(button);
            }
            else {
                Debug.Log($"Button already being hold called to be hold again {button}.");
            }
        }

        public void ProcessCancelInput(PlayerInputButton button) {
            if(ActiveHoldButtons.Contains(button)) {
                ActiveHoldButtons.Remove(button);
            }
        }

        private bool ShouldAcknowledgeDirectionalInput(PlayerInputButton button) {
            switch(button) {
                case PlayerInputButton.Down:
                    if(ActiveHoldButtons.Contains(PlayerInputButton.Up)) {
                        Debug.Log("Already holding up, cannot press/hold down.");
                        return false;
                    }
                    return true;
                case PlayerInputButton.Left:
                    if(ActiveHoldButtons.Contains(PlayerInputButton.Right)) {
                        Debug.Log("Already holding right, cannot press/hold left.");
                        return false;
                    }
                    return true;
                case PlayerInputButton.Right:
                    if(ActiveHoldButtons.Contains(PlayerInputButton.Left)) {
                        Debug.Log("Already holding left, cannot press/hold right.");
                        return false;
                    }
                    return true;
                case PlayerInputButton.Up:
                    if(ActiveHoldButtons.Contains(PlayerInputButton.Down)) {
                        Debug.Log("Already holding down, cannot press/hold up.");
                        return false;
                    }
                    return true;
                default:
                    Debug.Log($"Given button is not a directional {button}");
                    return false;
            }
        }
    }
}
