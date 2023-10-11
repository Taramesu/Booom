using FsmManager;
using Parameter;
using StateType;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatanIdleState : IState
{

    private SatanFsmManager manager;
    private SatanParameter parameter;

    public SatanIdleState(SatanFsmManager manager)
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

        parameter.animator.Play("Idle");


    }

    public void OnExit()
    {

    }

    public void OnUpdate()
    {

        manager.TransitionState(SatanST.Run);

    }
}