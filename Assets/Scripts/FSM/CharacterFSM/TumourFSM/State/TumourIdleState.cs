using FsmManager;
using Parameter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ð¡¹ÖTumour´ý»ú×´Ì¬
public class TumourIdleState : IState
{

    private TumourFsmManager manager;
    private TumourParameter parameter;

    public TumourIdleState(TumourFsmManager manager)
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
