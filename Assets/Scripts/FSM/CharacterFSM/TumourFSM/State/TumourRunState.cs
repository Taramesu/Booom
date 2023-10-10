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

    private float timer;

    public float nextWaypointDistance = 0.1f;

    public TumourRunState(TumourFsmManager manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }

    public void OnEnter()
    {
        timer = 0.65f;

        parameter.targetPos = GameObject.Find("Player(Clone)").GetComponent<Transform>().position;


        if (parameter.animator == null)
        {

            Debug.LogError("Miss animator");

        }

        if(Vector3.Distance(parameter.targetPos,parameter.transform.position) < 3)
        {
            if((parameter.path.vectorPath[parameter.currentWaypoint + 1] - parameter.transform.position).normalized.x<0)
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
            if ((parameter.path.vectorPath[parameter.currentWaypoint + 1] - parameter.transform.position).normalized.x < 0)
            {
                parameter.animator.Play("move-left");
            }
            else
            {
                parameter.animator.Play("move-right");
            }
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
            manager.TransitionState(TumourST.Idle);
        }

        parameter.targetPos = GameObject.Find("Player(Clone)").GetComponent<Transform>().position;

        if (Vector3.Distance(parameter.transform.position, parameter.targetPos) < 1.5)
        {

            manager.TransitionState(TumourST.Boom);

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

        dir *= parameter.speed * Time.deltaTime;

        parameter.transform.Translate(dir);

        if (Vector3.Distance(parameter.transform.position, parameter.path.vectorPath[parameter.currentWaypoint + 1]) < nextWaypointDistance)
        {

            parameter.currentWaypoint++;
            return;

        }

    }
}
