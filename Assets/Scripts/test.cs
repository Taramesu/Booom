using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class test : MonoBehaviour
{
    public CardPool cardPool;
    // Start is called before the first frame update
    void Start()
    {
        //ArchiveSystem.Instance.LoadArchive();
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
            cardPool.GetCurrentShape("Card_1");
        }
    }
}
