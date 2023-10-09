using FsmManager;
using Parameter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ð¡¹ÖFlyÒÆ¶¯×´Ì¬
public class FlyRunState : IState
{

    private FlyFsmManager manager;
    private FlyParameter parameter;

    public FlyRunState(FlyFsmManager manager)
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