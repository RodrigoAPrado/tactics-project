using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    PlayerInput playerInput;

    private void Awake() {
        playerInput = this.gameObject.GetComponent<PlayerInput>();    
    }

    public void DetectController() {
        Debug.Log(playerInput.currentControlScheme);
    }

    #region DPad    
    public void Down(InputAction.CallbackContext context) {
        if(context.started)
            Debug.Log("[InputController.Down] Press!");
        if(context.performed)
            Debug.Log("[InputController.Down] Hold!");
        if(context.canceled)
            Debug.Log("[InputController.Down] Canceled!");
    }

    public void Left(InputAction.CallbackContext context) {
        if(context.started)
            Debug.Log("[InputController.Left] Press!");
        if(context.performed)
            Debug.Log("[InputController.Left] Hold!");
        if(context.canceled)
            Debug.Log("[InputController.Left] Canceled!");
    }
    public void Right(InputAction.CallbackContext context) {
        if(context.started)
            Debug.Log("[InputController.Right] Press!");
        if(context.performed)
            Debug.Log("[InputController.Right] Hold!");
        if(context.canceled)
            Debug.Log("[InputController.Right] Canceled!");
    }
    public void Up(InputAction.CallbackContext context) {
        if(context.started)
            Debug.Log("[InputController.Up] Press!");
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
            Debug.Log("[InputController.Accept]");
    }

    //B - Circle
    public void Back(InputAction.CallbackContext context) {    
        if(context.performed)
            Debug.Log("[InputController.Back]");
    }

    //X - Square
    public void EnemyToggle(InputAction.CallbackContext context) {
        if(context.performed)
            Debug.Log("[InputController.EnemyToggle]");
    }

    //Y - Triangle
    public void Help(InputAction.CallbackContext context) {
        if(context.performed)
            Debug.Log("[InputController.Help]");
    }
    #endregion

    #region BackButtons
    
    //LT - L2
    public void BackInTime(InputAction.CallbackContext context) {
        if(context.performed)
            Debug.Log("[InputController.BackInTime]");
    }

    //RB - R1
    public void NextAlly(InputAction.CallbackContext context) {
        if(context.performed)
            Debug.Log("[InputController.NextAlly]");
    }

    //LB - L1
    public void PreviousAlly(InputAction.CallbackContext context) {
        if(context.performed)
            Debug.Log("[InputController.PreviousAlly]");
    }

    //RT - R2
    public void ZoomToggle(InputAction.CallbackContext context) {
        if(context.performed)
            Debug.Log("[InputController.ZoomToggle]");
    }

    #endregion

    #region CenterButtons
    public void GameMenu(InputAction.CallbackContext context) {
        if(context.performed)
            Debug.Log("[InputController.GameMenu]");
    }
    public void MapMenu(InputAction.CallbackContext context) {
        if(context.performed)
            Debug.Log("[InputController.MapMenu]");
    }
    #endregion

}
