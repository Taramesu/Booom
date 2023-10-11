using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class test : MonoBehaviour
{
    public CardPool cardPool;
    public PlayerFsmManager playerFsmManager;
    // Start is called before the first frame update
    void Start()
    {
        //ArchiveSystem.Instance.LoadArchive();
        
        //playerFsmManager.parameter.currentRoomID = 0;

        
    }

    // Update is called once per frame
    void Update()
    {

        //if(Input.GetKeyDown(KeyCode.J))
        //{
        //    ArchiveSystem.Instance.AutoSave();
        //}

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            cardPool = GameObject.Find("CardBag(Clone)").transform.Find("CardPool").GetComponent<CardPool>();
            cardPool.GetCurrentShape("Card_1");
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            CardManager.Instance.InstantiateCardBag();
        }
    }
}
