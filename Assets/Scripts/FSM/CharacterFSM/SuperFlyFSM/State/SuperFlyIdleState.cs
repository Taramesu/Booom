using FsmManager;
using Parameter;
using StateType;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperFlyIdleState : IState
{

    private SuperFlyFsmManager manager;
    private SuperFlyParameter parameter;

    public SuperFlyIdleState(SuperFlyFsmManager manager)
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

        manager.TransitionState(SuperFlyST.Run);

    }
}
