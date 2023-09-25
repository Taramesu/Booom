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
        inputActions.KeyBoard.DropBoom.started += OnDropBoom;
    }

    private void OnDisable()
    {
        inputActions.KeyBoard.DropBoom.started -= OnDropBoom;
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
        //if (currentMoveInput != Vector2.zero) 
        //{
        //    Debug.Log(currentMoveInput);
        //}
    }

    private void GetAttackInput()
    {
        var currentAttackInput = inputActions.KeyBoard.AttackControl.ReadValue<Vector2>();
        //if (currentAttackInput != Vector2.zero)
        //{
        //    Debug.Log(currentAttackInput);
        //}
    }

    public void OnDropBoom(InputAction.CallbackContext value)
    {
        //Debug.Log(inputActions.KeyBoard.DropBoom.IsPressed());
        Debug.Log(value.action.name + (" was triggered"));
    }


}
