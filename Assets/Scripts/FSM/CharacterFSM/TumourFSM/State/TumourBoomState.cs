using FsmManager;
using Parameter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ð¡¹ÖTumour¹¥»÷×´Ì¬
public class TumourBoomState : IState
{

    private TumourFsmManager manager;
    private TumourParameter parameter;

    private float timer;

    public TumourBoomState(TumourFsmManager manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }

    public void OnEnter()
    {
        timer = 0.7f;
        parameter.targetPos = GameObject.Find("Player(Clone)").GetComponent<Transform>().position;

        if (parameter.animator == null)
        {
            Debug.LogError("Miss animator");
        }

        if(parameter.transform.position.x < parameter.targetPos.x)
        {

            Debug.Log("boom right");

            parameter.animator.Play("boom-left");
        }
        else
        {
            parameter.animator.Play("boom-left");
        }
       

    }

    public void OnExit()
    {



    }

    public void OnUpdate()
    {
        timer -= Time.deltaTime;

        if(timer < 0)
        {
            parameter.targetPos = GameObject.Find("Player(Clone)").GetComponent<Transform>().position;

            if(Vector3.Distance(parameter.targetPos,parameter.transform.position) < 1.3)
            {
                //GameObject.Find("Player(Clone)")
            }

            manager.OnDestroy();
        }

    }
}