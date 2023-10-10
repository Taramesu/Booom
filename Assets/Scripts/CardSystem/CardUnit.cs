using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardUnit : MonoBehaviour
{
    public bool couldPutDown;


    private void Start()
    {
        couldPutDown = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Block"))
        {
            couldPutDown = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Block"))
        {
            couldPutDown = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Block"))
        {
            couldPutDown = true;
        }
    }
}
