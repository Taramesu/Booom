using FsmManager;
using Parameter;
using StateType;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatanShootState : IState
{

    private SatanFsmManager manager;
    private SatanParameter parameter;

    private GameObject bulletPrefab;

    private Transform topSpawn;
    private Transform bottomSpawn;
    private Transform leftSpawn;
    private Transform rightSpawn;
    private Transform topLeftSpawn;
    private Transform bottomRightSpawn;
    private Transform leftBottomSpawn;
    private Transform rightTopSpawn;

    private float timer;

    public SatanShootState(SatanFsmManager manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }

    public void OnEnter()
    {

        leftSpawn = parameter.transform.Find("LeftSpawn").GetComponent<Transform>();
        rightSpawn = parameter.transform.Find("RightSpawn").GetComponent<Transform>();
        topSpawn = parameter.transform.Find("TopSpawn").GetComponent<Transform>();
        bottomSpawn = parameter.transform.Find("BottomSpawn").GetComponent<Transform>();
        leftBottomSpawn = parameter.transform.Find("LeftBottomSpawn").GetComponent<Transform>();
        rightTopSpawn = parameter.transform.Find("RightTopSpawn").GetComponent<Transform>();
        topLeftSpawn = parameter.transform.Find("TopLeftSpawn").GetComponent<Transform>();
        bottomRightSpawn = parameter.transform.Find("BottomRightSpawn").GetComponent<Transform>();
        bulletPrefab = PathAndPrefabManager.Instance.GetBulletPrefab("EnemyBullet");
        timer = 0.65f;

        if (parameter.animator == null)
        {

            Debug.LogError("Miss animator");

        }

        parameter.animator.Play("atk");


    }

    public void OnExit()
    {

    }

    public void OnUpdate()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            Bullet bullet;

            bullet = Object.Instantiate(bulletPrefab, rightSpawn.position, Quaternion.identity).GetComponent<Bullet>();
            BulletDataInitailize(bullet, Bullet.Diraction.Right);
            bullet = Object.Instantiate(bulletPrefab, leftSpawn.position, Quaternion.identity).GetComponent<Bullet>();
            BulletDataInitailize(bullet, Bullet.Diraction.Left);
            bullet = Object.Instantiate(bulletPrefab, topSpawn.position, Quaternion.identity).GetComponent<Bullet>();
            BulletDataInitailize(bullet, Bullet.Diraction.Up);
            bullet = Object.Instantiate(bulletPrefab, bottomSpawn.position, Quaternion.identity).GetComponent<Bullet>();
            BulletDataInitailize(bullet, Bullet.Diraction.Down);
            bullet = Object.Instantiate(bulletPrefab, rightTopSpawn.position, Quaternion.identity).GetComponent<Bullet>();
            BulletDataInitailize(bullet, Bullet.Diraction.UpRight);
            bullet = Object.Instantiate(bulletPrefab, leftBottomSpawn.position, Quaternion.identity).GetComponent<Bullet>();
            BulletDataInitailize(bullet, Bullet.Diraction.DownLeft);
            bullet = Object.Instantiate(bulletPrefab, topLeftSpawn.position, Quaternion.identity).GetComponent<Bullet>();
            BulletDataInitailize(bullet, Bullet.Diraction.UpLeft);
            bullet = Object.Instantiate(bulletPrefab, bottomRightSpawn.position, Quaternion.identity).GetComponent<Bullet>();
            BulletDataInitailize(bullet, Bullet.Diraction.DownRight);

            manager.TransitionState(SatanST.Idle);
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
