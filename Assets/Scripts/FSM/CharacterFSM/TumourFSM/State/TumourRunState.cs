using FsmManager;
using Parameter;
using StateType;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ð¡¹ÖTumourÒÆ¶¯×´Ì¬
public class TumourRunState : IState
{

    private TumourFsmManager manager;
    private TumourParameter parameter;

    public float nextWaypointDistance = 0.1f;

    public TumourRunState(TumourFsmManager manager)
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

    }

    public void OnExit()
    {



    }

    public void OnUpdate()
    {

        parameter.targetPos = GameObject.Find("Player(Clone)").GetComponent<Transform>().position;

        if(parameter.currentHP < 1)
        {
            manager.OnDie();
        }

        if (Vector3.Distance(parameter.transform.position, parameter.targetPos) < 1.5)
        {

            manager.OnDie();

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

        if (Vector3.Distance(parameter.targetPos, parameter.transform.position) < 3)
        {
            if (dir.x < 0)
            {
                parameter.animator.Play("random-left");
            }
            else
            {
                parameter.animator.Play("random-right");
            }
        }
        else
        {
            if (dir.x < 0)
            {
                parameter.animator.Play("move-left");
            }
            else
            {
                parameter.animator.Play("move-right");
            }
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
