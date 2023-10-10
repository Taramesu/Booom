using FsmManager;
using Parameter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperFlyEmptyState : IState
{

    private SuperFlyFsmManager manager;
    private SuperFlyParameter parameter;

    public SuperFlyEmptyState(SuperFlyFsmManager manager)
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
