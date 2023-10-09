using FsmManager;
using Parameter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSkeletonRunState : IState
{

    private SuperSkeletonFsmManager manager;
    private SuperSkeletonParameter parameter;

    public SuperSkeletonRunState(SuperSkeletonFsmManager manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }

    public void OnEnter()
    {

    }

    public void OnExit()
    {

    }

    public void OnUpdate()
    {

    }
}
