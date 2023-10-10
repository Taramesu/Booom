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
            cardPool.GetCurrentShape("Card_1");
        }

        if(Input.GetKeyDown(KeyCode.F))
        {

            playerFsmManager = PlayerGenerator.Instance.fsmManager;
            if (playerFsmManager == null)
            {
#if UNITY_EDITOR
                Debug.Log("fsm is null");
#endif
            }

            var room = playerFsmManager.GetCurrentRoom();
            if(room != null) 
            {
#if UNITY_EDITOR
                Debug.Log($"find current room {room.roomID}");
#endif
            }
        }
    }
}
