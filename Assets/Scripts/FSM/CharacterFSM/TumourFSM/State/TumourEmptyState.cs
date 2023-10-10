using FsmManager;
using Parameter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ð¡¹ÖTumour¿Õ×´Ì¬
public class TumourEmptyState : IState
{

    private TumourFsmManager manager;
    private TumourParameter parameter;

    public TumourEmptyState(TumourFsmManager manager)
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
