using FsmManager;
using Parameter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//С��Tumour�ƶ�״̬
public class TumourRunState : IState
{

    private TumourFsmManager manager;
    private TumourParameter parameter;

    public TumourRunState(TumourFsmManager manager)
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
