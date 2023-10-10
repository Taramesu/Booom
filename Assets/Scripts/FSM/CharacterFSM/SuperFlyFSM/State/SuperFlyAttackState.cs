using FsmManager;
using Parameter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperFlyAttackState : IState
{

    private SuperFlyFsmManager manager;
    private SuperFlyParameter parameter;

    public SuperFlyAttackState(SuperFlyFsmManager manager)
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
