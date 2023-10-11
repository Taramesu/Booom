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
    private GameObject thornPrefab;

    private float timer;
    private float timer2;
    private float timer3;
    private Vector3 target;

    public SuperSkeletonAttackState(SuperSkeletonFsmManager manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }

    public void OnEnter()
    {

        timer = 0.4f;
        timer2 = 0.3f;
        timer3 = 2f;
        target = parameter.transform.position;

        thornPrefab = PathAndPrefabManager.Instance.GetBulletPrefab("GroundThorn");

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
        timer -= Time.deltaTime;
        timer2 -= Time.deltaTime;
        timer3 -= Time.deltaTime;

        if (timer3 < 0)
        {
            manager.TransitionState(SuperSkeletonST.Idle);
        }

        GameObject player = GameObject.Find("Player(Clone)");

        if (Vector3.Distance(player.transform.position, parameter.transform.position) < 1.2)
        {
            player.GetComponent<PlayerFsmManager>().GetDamage(parameter.ATK);
            manager.TransitionState(SuperSkeletonST.Idle);
        }

        if (timer < 0)
        {
            parameter.transform.Translate((target - parameter.transform.position).normalized * parameter.speedMulti * Time.deltaTime);

            if (timer2 < 0)
            {
                GameObject.Instantiate(thornPrefab, parameter.transform.position, Quaternion.identity);
                timer2 = 0.3f;
            }

            return;

        }

    }
}
