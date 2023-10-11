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

    private float timer;

    public SuperSkeletonIdleState(SuperSkeletonFsmManager manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }

    public void OnEnter()
    {
        timer = 0.2f;

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
        timer -= Time.deltaTime;

        if(timer < 0)
        {
            manager.TransitionState(SuperSkeletonST.Run);
        }

    }
}