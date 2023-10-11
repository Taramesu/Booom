using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundThorn : MonoBehaviour
{
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {

        timer = 5;

    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;
        
        if (timer < 0)
        {

                GameObject.Destroy(gameObject);

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        collision.GetComponent<PlayerFsmManager>().GetDamage(1);

    }

}
