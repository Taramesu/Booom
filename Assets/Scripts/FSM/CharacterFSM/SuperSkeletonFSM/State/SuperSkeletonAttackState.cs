using FsmManager;
using Parameter;
using StateType;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSkeletonAttackState : IState
{

    private SuperSkeletonFsmManager manager;
    private SuperSkeletonParameter parameter;

    private float timer;
    private Vector3 target;

    public SuperSkeletonAttackState(SuperSkeletonFsmManager manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }

    public void OnEnter()
    {

        timer = 0.4f;
        target = parameter.transform.position;

        if (parameter.animator == null)
        {
            Debug.LogError("Miss animator");
        }

        if (parameter.direction == Direction.right)
        {
            parameter.animator.Play("rush-right");
            target.x += 4;
        }
        else if (parameter.direction == Direction.left)
        {
            parameter.animator.Play("rush-left");
            target.x -= 4;
        }
        else if (parameter.direction == Direction.front)
        {
            parameter.animator.Play("rush-front");
            target.y -= 4;
        }
        else
        {
            parameter.animator.Play("rush-behind");
            target.y += 4;
        }

    }

    public void OnExit()
    {

    }

    public void OnUpdate()
    {

        if (Vector3.Distance(target, parameter.transform.position) < 0.2)
        {
            manager.TransitionState(SuperSkeletonST.Idle);
        }

        if (timer < 0)
        {
            parameter.transform.Translate((target - parameter.transform.position).normalized * parameter.speedMulti * Time.deltaTime);

            return;
        }

        timer -= Time.deltaTime;

    }
}
