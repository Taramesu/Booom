using FsmManager;
using Parameter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateType;

//С��Skeleton����״̬
public class SkeletonIdleState : IState
{

    private SkeletonFsmManager manager;
    private SkeletonParameter parameter;

    public SkeletonIdleState(SkeletonFsmManager manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }

    public void OnEnter()
    {

        if(parameter.animator == null)
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

        manager.TransitionState(SkeletonST.Run);

    }
}