using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Tactics.Manager.PlayerInput;

namespace Tactics.Controller {
    
    [RequireComponent(typeof(InputProcessingController))]
    [RequireComponent(typeof(PlayerInput))]
    public class InputReadingController : MonoBehaviour
    {
        private PlayerInput PlayerInput { get; set; } 
        private InputProcessingController Processor { get; set; }

        private void Awake() {
            PlayerInput = gameObject.GetComponent<PlayerInput>(); 
            Processor = gameObject.GetComponent<InputProcessingController>(); 
        }

        public void DetectController() {
            Debug.Log(PlayerInput.currentControlScheme);
        }

        #region DPad    
        public void Down(InputAction.CallbackContext context) {
            if(context.started)
                Processor.ProcessPressInput(PlayerInputButton.Down);
            if(context.performed)
                Debug.Log("[InputController.Down] Hold!");
            if(context.canceled)    
                Debug.Log("[InputController.Down] Canceled!");

        }

        public void Left(InputAction.CallbackContext context) {
            if(context.started)
                Processor.ProcessPressInput(PlayerInputButton.Left);
            if(context.performed)
                Debug.Log("[InputController.Left] Hold!");
            if(context.canceled)
                Debug.Log("[InputController.Left] Canceled!");
        }
        public void Right(InputAction.CallbackContext context) {
            if(context.started)
                Processor.ProcessPressInput(PlayerInputButton.Right);
            if(context.performed)
                Debug.Log("[InputController.Right] Hold!");
            if(context.canceled)
                Debug.Log("[InputController.Right] Canceled!");
        }
        public void Up(InputAction.CallbackContext context) {
            if(context.started)
                Processor.ProcessPressInput(PlayerInputButton.Up);
            if(context.performed)
                Debug.Log("[InputController.Up] Hold!");
            if(context.canceled)
                Debug.Log("[InputController.Up] Canceled!");
        }
        #endregion

        #region FaceButtons
        //A - X
        public void Accept(InputAction.CallbackContext context) {
            if(context.performed)
                Processor.ProcessPressInput(PlayerInputButton.Accept);
        }

        //B - Circle
        public void Back(InputAction.CallbackContext context) {    
            if(context.performed)
                Processor.ProcessPressInput(PlayerInputButton.Back);
        }

        //X - Square
        public void EnemyToggle(InputAction.CallbackContext context) {
            if(context.performed)
                Processor.ProcessPressInput(PlayerInputButton.EnemyToggle);
        }

        //Y - Triangle
        public void Help(InputAction.CallbackContext context) {
            if(context.performed)
                Processor.ProcessPressInput(PlayerInputButton.Help);
        }
        #endregion

        #region BackButtons
        
        //LT - L2
        public void BackInTime(InputAction.CallbackContext context) {
            if(context.performed)
                Processor.ProcessPressInput(PlayerInputButton.BackInTime);
        }

        //RB - R1
        public void NextAlly(InputAction.CallbackContext context) {
            if(context.performed)
                Processor.ProcessPressInput(PlayerInputButton.NextAlly);
        }

        //LB - L1
        public void PreviousAlly(InputAction.CallbackContext context) {
            if(context.performed)
                Processor.ProcessPressInput(PlayerInputButton.PreviousAlly);
        }

        //RT - R2
        public void ZoomToggle(InputAction.CallbackContext context) {
            if(context.performed)
                Processor.ProcessPressInput(PlayerInputButton.ZoomToggle);
        }

        #endregion

        #region CenterButtons
        public void GameMenu(InputAction.CallbackContext context) {
            if(context.performed)
                Processor.ProcessPressInput(PlayerInputButton.GameMenu);
        }
        public void MapMenu(InputAction.CallbackContext context) {
            if(context.performed)
                Processor.ProcessPressInput(PlayerInputButton.MapMenu);
        }
        #endregion

    }
}