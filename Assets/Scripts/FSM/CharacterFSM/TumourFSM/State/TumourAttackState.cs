using FsmManager;
using Parameter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//С��Tumour����״̬
public class TumourAttackState : IState
{

    private TumourFsmManager manager;
    private TumourParameter parameter;

    public TumourAttackState(TumourFsmManager manager)
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