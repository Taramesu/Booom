using FsmManager;
using Parameter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//С��Skeleton����״̬
public class SkeletonAttackState : IState
{

    private SkeletonFsmManager manager;
    private SkeletonParameter parameter;

    public SkeletonAttackState(SkeletonFsmManager manager)
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