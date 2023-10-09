using FsmManager;
using Parameter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ð¡¹ÖFly¿Õ×´Ì¬
public class FlyEmptyState : IState
{

    private FlyFsmManager manager;
    private FlyParameter parameter;

    public FlyEmptyState(FlyFsmManager manager)
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