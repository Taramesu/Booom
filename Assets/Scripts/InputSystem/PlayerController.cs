using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInputActions inputActions;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        inputActions.KeyBoard.Enable();
        var mapPC = inputActions.KeyBoard;
        mapPC.DropBoom.started += OnDropBoomStarted;
        mapPC.OpenBag.started += OnOpenBagStarted;
        mapPC.SelectItems.started += OnSelectItemsStarted;
        mapPC.UseItems.started += OnUseitemsStarted;
        mapPC.PauseGame.started += OnPauseGameStarted;

        mapPC.DropBoom.canceled += OnDropBoomCanceled;
        mapPC.OpenBag.canceled += OnOpenBagCanceled;
        mapPC.SelectItems.canceled += OnSelectItemsCanceled;
        mapPC.UseItems.canceled += OnUseitemsCanceled;
        mapPC.PauseGame.canceled += OnPauseGameCanceled;
    }

    private void OnDisable()
    {
        var mapPC = inputActions.KeyBoard;
        mapPC.DropBoom.started -= OnDropBoomStarted;
        mapPC.OpenBag.started -= OnOpenBagStarted;
        mapPC.SelectItems.started -= OnSelectItemsStarted;
        mapPC.UseItems.started -= OnUseitemsStarted;
        mapPC.PauseGame.started -= OnPauseGameStarted;

        mapPC.DropBoom.canceled -= OnDropBoomCanceled;
        mapPC.OpenBag.canceled -= OnOpenBagCanceled;
        mapPC.SelectItems.canceled -= OnSelectItemsCanceled;
        mapPC.UseItems.canceled -= OnUseitemsCanceled;
        mapPC.PauseGame.canceled -= OnPauseGameCanceled;
        inputActions.KeyBoard.Disable();
    }

    private void Update()
    {
        GetMoveInput();
        GetAttackInput();
    }
    
    private void GetMoveInput()
    {
        var currentMoveInput = inputActions.KeyBoard.MoveControl.ReadValue<Vector2>();
        PlayerInputData.Instance.moveVal = currentMoveInput;
    }

    private void GetAttackInput()
    {
        var currentAttackInput = inputActions.KeyBoard.AttackControl.ReadValue<Vector2>();

        if(currentAttackInput.x>0.5f)
        {
            PlayerInputData.Instance.attackVal = new Vector2(1, 0);
        }
        else if(currentAttackInput.x < -0.5f)
        {
            PlayerInputData.Instance.attackVal = new Vector2(-1, 0);
        }
        else
        {
            PlayerInputData.Instance.attackVal = currentAttackInput;
        }

        if (currentAttackInput.y > 0.5f)
        {
            PlayerInputData.Instance.attackVal = new Vector2(0,1);
        }
        else if (currentAttackInput.y < -0.5f)
        {
            PlayerInputData.Instance.attackVal = new Vector2(0,-1);
        }
        else
        {
            PlayerInputData.Instance.attackVal = currentAttackInput;
        }

    }

    #region CallbackFunction
    public void OnDropBoomStarted(InputAction.CallbackContext value)
    {
        //Debug.Log(value.action.name + (" was triggered"));
        PlayerInputData.Instance.dropBoomVal = true;
        //Debug.Log(PlayerInputData.Instance.dropBoomVal);
    }

    public void OnDropBoomCanceled(InputAction.CallbackContext value)
    {
        //Debug.Log(value.action.name + (" was finished"));
        PlayerInputData.Instance.dropBoomVal = false;
        //Debug.Log(PlayerInputData.Instance.dropBoomVal);
    }

    public void OnOpenBagStarted(InputAction.CallbackContext value)
    {
        //Debug.Log(value.action.name + (" was triggered"));
        PlayerInputData.Instance.openBagVal = true;
    }

    public void OnOpenBagCanceled(InputAction.CallbackContext value)
    {
        PlayerInputData.Instance.openBagVal = false;
    }

    public void OnSelectItemsStarted(InputAction.CallbackContext value)
    {
        //Debug.Log(value.action.name + (" was triggered"));
        string selectedKey = value.control.displayName;
        PlayerInputData.Instance.selectItemsVal = int.Parse(selectedKey);
        Debug.Log(PlayerInputData.Instance.selectItemsVal);
    }

    public void OnSelectItemsCanceled(InputAction.CallbackContext value)
    {
        PlayerInputData.Instance.selectItemsVal = 0;
        Debug.Log(PlayerInputData.Instance.selectItemsVal);
    }

    public void OnUseitemsStarted(InputAction.CallbackContext value)
    {
        //Debug.Log(value.action.name + (" was triggered"));
        PlayerInputData.Instance.useItemsVal = true;
    }

    public void OnUseitemsCanceled(InputAction.CallbackContext value)
    {
        PlayerInputData.Instance.useItemsVal = false;
    }

    public void OnPauseGameStarted(InputAction.CallbackContext value)
    {
        //Debug.Log(value.action.name + (" was triggered"));
        PlayerInputData.Instance.pauseGameVal = true;
    }

    public void OnPauseGameCanceled(InputAction.CallbackContext value)
    {
        PlayerInputData.Instance.pauseGameVal = false;
    }

    #endregion
}


