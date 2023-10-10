using FsmManager;
using Parameter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateType;

//Ð¡¹ÖFly¿Õ×´Ì¬
public class FlyIdleState : IState
{

    private FlyFsmManager manager;
    private FlyParameter parameter;

    public FlyIdleState(FlyFsmManager manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }

    public void OnEnter()
    {

        if (parameter.animator == null)
        {
            Debug.LogError("Miss animator");
        }

        parameter.animator.Play("Idel");

    }

    public void OnExit()
    {

    }

    public void OnUpdate()
    {
        
        manager.TransitionState(FlyST.Run);

    }
}