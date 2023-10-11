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

    private float timer = 0.5f;

    public TumourIdleState(TumourFsmManager manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }

    public void OnEnter()
    {

        if (parameter.animator == null)
        {

            Debug.LogError("Miss animator");

        }

        parameter.animator.Play("Idel");

    }

    public void OnExit()
    {

    }

    public void OnUpdate()
    {

        if (parameter.currentHP < 1)
        {
            manager.OnDie();
        }

        if (timer < 0)
        {
            manager.TransitionState(TumourST.Run);
        }

        timer -= Time.deltaTime;

    }

}
