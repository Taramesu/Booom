using FsmManager;
using Parameter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Ð¡¹ÖSkeletonÒÆ¶¯×´Ì¬
public class SkeletonRunState : IState
{

    private SkeletonFsmManager manager;
    private SkeletonParameter parameter;

    public SkeletonRunState(SkeletonFsmManager manager)
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