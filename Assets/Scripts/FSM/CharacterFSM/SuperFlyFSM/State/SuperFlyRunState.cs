using FsmManager;
using Parameter;
using StateType;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperFlyRunState : IState
{

    private SuperFlyFsmManager manager;
    private SuperFlyParameter parameter;
    private float nextWaypointDistance = 0.1f;
    private float timer;
    private float shootTimer;

    public SuperFlyRunState(SuperFlyFsmManager manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }

    public void OnEnter()
    {

        timer = 0;
        shootTimer = 1;

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
        shootTimer -= Time.deltaTime;

        if (Math.Abs(parameter.transform.position.y - GameObject.Find("Player(Clone)").GetComponent<Transform>().position.y) <= 0.2 && shootTimer < 0)
        {
            manager.TransitionState(SuperFlyST.Attack);
        }



        if (Vector3.Distance(parameter.transform.position, GameObject.Find("Player(Clone)").GetComponent<Transform>().position) < 4.5)
        {

            if (timer < 0)
            {

                parameter.targetPos = parameter.transform.position;
                parameter.targetPos.x += UnityEngine.Random.Range(-4, 4);
                parameter.targetPos.y += UnityEngine.Random.Range(-4, 4);

                timer = 2f;

            }

        }
        else
        {

            parameter.targetPos = GameObject.Find("Player(Clone)").GetComponent<Transform>().position;

        }

        parameter.seeker.StartPath(parameter.transform.position, parameter.targetPos);

        if (parameter.path == null)
        {
            return;
        }

        if (parameter.currentWaypoint >= parameter.path.vectorPath.Count)
        {
            return;
        }

        Vector3 dir = (parameter.path.vectorPath[parameter.currentWaypoint + 1] - parameter.transform.position).normalized;



        if (dir.x < 0)
        {
            parameter.animator.Play("move-left");
        }
        else
        {
            parameter.animator.Play("move-right");
        }

        dir *= parameter.speed * Time.deltaTime;

        parameter.transform.Translate(dir);

        if (Vector3.Distance(parameter.transform.position, parameter.path.vectorPath[parameter.currentWaypoint + 1]) < nextWaypointDistance)
        {
            parameter.currentWaypoint++;
            return;
        }

    }
}
