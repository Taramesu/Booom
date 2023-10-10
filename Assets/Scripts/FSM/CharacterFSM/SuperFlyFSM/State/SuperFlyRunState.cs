using FsmManager;
using Parameter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperFlyRunState : IState
{

    private SuperFlyFsmManager manager;
    private SuperFlyParameter parameter;

    public SuperFlyRunState(SuperFlyFsmManager manager)
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
