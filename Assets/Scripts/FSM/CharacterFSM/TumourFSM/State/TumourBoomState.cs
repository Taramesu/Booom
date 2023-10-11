using FsmManager;
using Parameter;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
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

        if (parameter.animator == null)
        {
            Debug.LogError("Miss animator");
        }

        parameter.animator.Play("boom-left");

    }

    public void OnExit()
    {



    }

    public void OnUpdate()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            GameObject player = GameObject.Find("Player(Clone)");

            Debug.Log(Vector3.Distance(player.GetComponent<Transform>().position, parameter.transform.position));

            if (Vector3.Distance(player.GetComponent<Transform>().position, parameter.transform.position) < 1.9)
            {
                
                {
                    Debug.Log("player != null");
                    player.GetComponent<PlayerFsmManager>().GetDamage(parameter.criticalMulti);

                }

            }

            manager.OnDestroy();

        }

    }
}