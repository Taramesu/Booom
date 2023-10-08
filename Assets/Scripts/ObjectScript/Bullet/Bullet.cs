using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public enum Diraction
    {
        Up, Down, Left, Right
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
            if (collision.CompareTag("Enemy"))
            {
                //���ö�������ֵ�۳�����

                gameObject.SetActive(false);
            }
        }
        else if (shooter == "Enemy")
        {
            if (collision.CompareTag("Player"))
            {
                //���ö�������ֵ�۳�����

                gameObject.SetActive(false);
            }
        }
            
        if(collision.CompareTag("Block"))
        {
            gameObject.SetActive(false);
        }

        if (collision.CompareTag("Wall"))
        {
#if UNITY_EDITOR
            Debug.Log("touch Wall");
#endif
            gameObject.SetActive(false);
        }
    }
}
