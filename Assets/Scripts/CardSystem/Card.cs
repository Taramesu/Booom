
using UnityEngine;

public class Card : MonoBehaviour
{
    public bool isEffective;
    public int ID;
    public SpriteRenderer[] spriteRendererList;

    private CardUnit[] blockList;
    private CardPool pool;

    private void Start()
    {
        blockList = gameObject.GetComponentsInChildren<CardUnit>();
        spriteRendererList = gameObject.GetComponentsInChildren<SpriteRenderer>();
        pool = GameObject.Find("CardPool").GetComponent<CardPool>();
        isEffective = true;
    }

    private void Update()
    {
        if (isEffective)
        Check();
    }

    private void Check()
    {
        foreach (CardUnit block in blockList)
        {
            if(!block.couldPutDown)
            {
                pool.currentShapeCoubeBePutDown = false;
                break;
            }
            else
            {
                pool.currentShapeCoubeBePutDown = true;
            }
        }
    }
}
