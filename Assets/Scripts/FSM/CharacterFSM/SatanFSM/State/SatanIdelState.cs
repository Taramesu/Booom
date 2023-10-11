using FsmManager;
using Parameter;
using StateType;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SatanIdleState : IState
{

    private SatanFsmManager manager;
    private SatanParameter parameter;
    private float timer;

    public SatanIdleState(SatanFsmManager manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }

    public void OnEnter()
    {

        timer = 0.5f;

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
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            if(Random.Range(0, 11) < 7)
            {
                manager.TransitionState(SatanST.Shoot);
            }
            else
            {
                manager.TransitionState(SatanST.Run);
            }
            
        }

    }
}