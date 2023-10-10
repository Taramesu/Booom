using FsmManager;
using Parameter;
using StateType;
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

        Debug.Log("enter Idel");

        if (parameter.animator == null)
        {

            Debug.LogError("Miss animator");

        }

        parameter.animator.Play("Idel");

    }

    public void OnExit()
    {

        Debug.Log("exit Idel");

    }

    public void OnUpdate()
    {

        manager.TransitionState(TumourST.Run);

    }

}
