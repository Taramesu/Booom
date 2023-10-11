using FsmManager;
using Parameter;
using StateType;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSkeletonIdleState : IState
{

    private SuperSkeletonFsmManager manager;
    private SuperSkeletonParameter parameter;

    public SuperSkeletonIdleState(SuperSkeletonFsmManager manager)
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

        manager.TransitionState(SuperSkeletonST.Run);

    }
}