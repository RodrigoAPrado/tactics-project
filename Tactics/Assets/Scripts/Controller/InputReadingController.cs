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
                Processor.ProcessDirectionalPressInput(PlayerInputButton.Down);
            if(context.performed)
                Processor.ProcessHoldInput(PlayerInputButton.Down);
            if(context.canceled)
                Processor.ProcessCancelInput(PlayerInputButton.Down);

        }

        public void Left(InputAction.CallbackContext context) {
            if(context.started)
                Processor.ProcessDirectionalPressInput(PlayerInputButton.Left);
            if(context.performed)
                Processor.ProcessHoldInput(PlayerInputButton.Left);
            if(context.canceled)
                Processor.ProcessCancelInput(PlayerInputButton.Left);
        }
        public void Right(InputAction.CallbackContext context) {
            if(context.started)
                Processor.ProcessDirectionalPressInput(PlayerInputButton.Right);
            if(context.performed)
                Processor.ProcessHoldInput(PlayerInputButton.Right);
            if(context.canceled)
                Processor.ProcessCancelInput(PlayerInputButton.Right);
        }
        public void Up(InputAction.CallbackContext context) {
            if(context.started)
                Processor.ProcessDirectionalPressInput(PlayerInputButton.Up);
            if(context.performed)
                Processor.ProcessHoldInput(PlayerInputButton.Up);
            if(context.canceled)
                Processor.ProcessCancelInput(PlayerInputButton.Up);
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