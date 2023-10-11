using FsmManager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public enum Diraction
    {
        Up, Down, Left, Right,UpLeft,DownLeft,UpRight,DownRight
    }
    public Diraction shootDir;
    public float speed;
    public float damage;
    public string shooter;

    private Vector2 dir;


    // Start is called before the first frame update
    void Start()
    {
        InitializeData();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
    }

    private void InitializeData()
    {
        switch (shootDir)
        {
            case Diraction.Up: dir = new Vector2(0, 1); break;
            case Diraction.Down: dir = new Vector2(0, -1); break;
            case Diraction.Left: dir = new Vector2(-1, 0); break;
            case Diraction.Right: dir = new Vector2(1, 0); break;
            case Diraction.UpLeft: dir = new Vector2(-0.707f, 0.707f); break;
            case Diraction.DownLeft: dir = new Vector2(-0.707f, -0.707f); break;
            case Diraction.UpRight: dir = new Vector2(0.707f, 0.707f); break;
            case Diraction.DownRight: dir = new Vector2(0.707f, -0.707f); break;
        }
    }

    private void UpdatePosition()
    {

        gameObject.transform.Translate(dir*speed*Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (shooter == "Player")
        {
            Debug.Log(collision.name);

            if (collision.CompareTag("Enemy"))
            {

                //调用对象生命值扣除函数
                if(collision.name == "Skeleton(Clone)")
                {
                    collision.GetComponent<SkeletonFsmManager>().GetDamage(damage);
                }
                else if(collision.name == "Fly(Clone)")
                {
                    collision.GetComponent<FlyFsmManager>().GetDamage(damage);
                }
                else if (collision.name == "Tumour(Clone)")
                {
                    collision.GetComponent<TumourFsmManager>().GetDamage(damage);
                }
                if (collision.name == "SuperSkeleton(Clone)")
                {
                    collision.GetComponent<SuperSkeletonFsmManager>().GetDamage(damage);
                }
                else if (collision.name == "SuperFly(Clone)")
                {
                    collision.GetComponent<SuperFlyFsmManager>().GetDamage(damage);
                }
                else if (collision.name == "satan(Clone)")
                {
                    collision.GetComponent<SatanFsmManager>().GetDamage(damage);
                }

                gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
        else if (shooter == "Enemy")
        {
            if (collision.CompareTag("Player"))
            {
                //调用对象生命值扣除函数
                collision.GetComponent<PlayerFsmManager>().GetDamage(damage);
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
            
        /*if(collision.CompareTag("Block"))
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }*/

        if (collision.CompareTag("Wall"))
        {
#if UNITY_EDITOR
            Debug.Log("touch Wall");
#endif
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
