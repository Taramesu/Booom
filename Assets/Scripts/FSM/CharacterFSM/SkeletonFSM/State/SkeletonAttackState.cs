using FsmManager;
using Parameter;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using StateType;

//Ð¡¹ÖSkeleton¹¥»÷×´Ì¬
public class SkeletonAttackState : IState
{

    private SkeletonFsmManager manager;
    private SkeletonParameter parameter;

    private float timer;
    private Vector3 target;

    public SkeletonAttackState(SkeletonFsmManager manager)
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

        if(parameter.direction == Direction.right)
        {
            parameter.animator.Play("rush_right");
            target.x += 4;
        }
        else if(parameter.direction == Direction.left)
        {
            parameter.animator.Play("rush_left");
            target.x -= 4;
        }
        else if(parameter.direction == Direction.front)
        {
            parameter.animator.Play("rush_front");
            target.y -= 4;
        }
        else
        {
            parameter.animator.Play("rush_behind");
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
            manager.TransitionState(SkeletonST.Idle);
        }

        if (timer<0)
        {
            parameter.transform.Translate((target - parameter.transform.position).normalized * parameter.speedMulti * Time.deltaTime);

            return;
        }

        timer -= Time.deltaTime;

    }
}