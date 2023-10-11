using FsmManager;
using Parameter;
using StateType;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatanRunState : IState
{

    private SatanFsmManager manager;
    private SatanParameter parameter;

    public float nextWaypointDistance = 0.1f;

    public SatanRunState(SatanFsmManager manager)
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

        parameter.animator.Play("move");

        parameter.direction = Direction.front;
    }

    public void OnExit()
    {

    }

    public void OnUpdate()
    {

        parameter.targetPos = GameObject.Find("Player(Clone)").GetComponent<Transform>().position;

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

        if (Math.Abs(parameter.transform.position.y - parameter.targetPos.y) < 0.2 && Vector3.Distance(parameter.transform.position, parameter.targetPos) < 3)
        {
            manager.TransitionState(SatanST.Attack);
        }

        if (Math.Abs(parameter.transform.position.x - parameter.targetPos.x) < 0.2 && Vector3.Distance(parameter.transform.position, parameter.targetPos) < 3)
        {
            manager.TransitionState(SatanST.Attack);
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
