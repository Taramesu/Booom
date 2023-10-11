using FsmManager;
using Parameter;
using StateType;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatanAttackState : IState
{

    private SatanFsmManager manager;
    private SatanParameter parameter;

    private float timer;
    private Vector3 target;

    public SatanAttackState(SatanFsmManager manager)
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

        parameter.animator.Play("move");

        if (parameter.direction == Direction.right)
        {
            target.x += 4;
        }
        else if (parameter.direction == Direction.left)
        {
            target.x -= 4;
        }
        else if (parameter.direction == Direction.front)
        {
            target.y -= 4;
        }
        else
        {
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
            manager.TransitionState(SatanST.Idle);
        }

        if (timer < 0)
        {
            parameter.transform.Translate((target - parameter.transform.position).normalized * parameter.speedMulti * Time.deltaTime);

            return;
        }

        timer -= Time.deltaTime;
    }
}
