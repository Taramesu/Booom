using FsmManager;
using Parameter;
using StateType;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSkeletonRunState : IState
{

    private SuperSkeletonFsmManager manager;
    private SuperSkeletonParameter parameter;

    public float nextWaypointDistance = 0.1f;

    public SuperSkeletonRunState(SuperSkeletonFsmManager manager)
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

        parameter.animator.Play("move-front");

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

        if ((parameter.direction == Direction.right || parameter.direction == Direction.left) && Math.Abs(parameter.transform.position.y - parameter.targetPos.y) < 0.2 && Vector3.Distance(parameter.transform.position, parameter.targetPos) < 3)
        {
            manager.TransitionState(SuperSkeletonST.Attack);
        }

        if ((parameter.direction == Direction.front || parameter.direction == Direction.behind) && Math.Abs(parameter.transform.position.x - parameter.targetPos.x) < 0.2 && Vector3.Distance(parameter.transform.position, parameter.targetPos) < 3)
        {
            manager.TransitionState(SuperSkeletonST.Attack);
        }

        ChangeDirection(dir);

        dir *= parameter.speed * Time.deltaTime;

        parameter.transform.Translate(dir);

        if (Vector3.Distance(parameter.transform.position, parameter.path.vectorPath[parameter.currentWaypoint + 1]) < nextWaypointDistance)
        {
            parameter.currentWaypoint++;
            return;
        }

    }

    public void ChangeDirection(Vector3 dir)
    {
        if (Math.Abs(dir.x) > Math.Abs(dir.y))
        {
            if (dir.x < 0)
            {

                parameter.animator.Play("move-left");
                parameter.direction = Direction.left;

            }
            else
            {

                parameter.animator.Play("move-right");
                parameter.direction = Direction.right;

            }
        }
        else
        {
            if (dir.y < 0)
            {

                parameter.animator.Play("move-front");
                parameter.direction = Direction.front;

            }
            else
            {

                parameter.animator.Play("move-behind");
                parameter.direction = Direction.behind;

            }
        }
    }

}
