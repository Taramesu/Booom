using FsmManager;
using Parameter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ð¡¹ÖFly¹¥»÷×´Ì¬
public class FlyAttackState : IState
{

    private FlyFsmManager manager;
    private FlyParameter parameter;

    public FlyAttackState(FlyFsmManager manager)
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