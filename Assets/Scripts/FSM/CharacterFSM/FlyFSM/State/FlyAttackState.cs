using FsmManager;
using Parameter;
using StateType;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

//С��Fly����״̬
public class FlyAttackState : IState
{

    private FlyFsmManager manager;
    private FlyParameter parameter;

    private Transform leftSpawn;
    private Transform rightSpawn;

    private GameObject bulletPrefab;

    private float timer;
    private Boolean isMultipleAtk;
    private int count;

    public FlyAttackState(FlyFsmManager manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }

    public void OnEnter()
    {

        if(UnityEngine.Random.Range(-3,7) < 0)
        {
            isMultipleAtk = true;
            count = UnityEngine.Random.Range(1, 3);
        }
        else
        {
            isMultipleAtk = false;
        }

        leftSpawn = parameter.transform.Find("LeftSpawn").GetComponent<Transform>();
        rightSpawn = parameter.transform.Find("RightSpawn").GetComponent<Transform>();
        bulletPrefab = PathAndPrefabManager.Instance.GetBulletPrefab("EnemyBullet");
        timer = 0.65f;

        if (parameter.animator == null)
        {
            Debug.LogError("Miss animator");
        }

        parameter.targetPos = GameObject.Find("Player(Clone)").GetComponent<Transform>().position;


        if (parameter.targetPos.x < parameter.transform.position.x)
        {

            parameter.animator.Play("atk-left");

        }
        else
        {

            parameter.animator.Play("atk-right");

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

            Bullet bullet;

            if (isMultipleAtk)
            {

                if (parameter.targetPos.x < parameter.transform.position.x)
                {

                    bullet = UnityEngine.Object.Instantiate(bulletPrefab, leftSpawn.position, Quaternion.identity).GetComponent<Bullet>();
                    BulletDataInitailize(bullet, Bullet.Diraction.Left);

                }
                else
                {

                    bullet = UnityEngine.Object.Instantiate(bulletPrefab, rightSpawn.position, Quaternion.identity).GetComponent<Bullet>();
                    BulletDataInitailize(bullet, Bullet.Diraction.Right);

                }

                count--;
                timer += 0.15f;
                
                if(count == 0)
                {
                    isMultipleAtk = false;
                }

            }
            else
            {

                if (parameter.targetPos.x < parameter.transform.position.x)
                {

                    bullet = UnityEngine.Object.Instantiate(bulletPrefab, leftSpawn.position, Quaternion.identity).GetComponent<Bullet>();
                    BulletDataInitailize(bullet, Bullet.Diraction.Left);

                }
                else
                {

                    bullet = UnityEngine.Object.Instantiate(bulletPrefab, rightSpawn.position, Quaternion.identity).GetComponent<Bullet>();
                    BulletDataInitailize(bullet, Bullet.Diraction.Right);

                }

                manager.TransitionState(FlyST.Idle);

            }

        }

    }

    private void BulletDataInitailize(Bullet bullet, Bullet.Diraction dir)
    {
        bullet.damage = parameter.ATK;
        bullet.shooter = "Enemy";
        bullet.shootDir = dir;
        bullet.speed = 7;
    }

}