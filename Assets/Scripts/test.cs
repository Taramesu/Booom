using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerDataManager.Instance.playerName = "Issa";
        PlayerDataManager.Instance.playerLevel = 1;
        PlayerDataManager.Instance.playerPosition = new Vector2 (2.3f, 4.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            PlayerDataManager.Instance.Save();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayerDataManager.Instance.Load();
            Debug.Log("Name:"+PlayerDataManager.Instance.playerName);
            Debug.Log("Level:"+PlayerDataManager.Instance.playerLevel);        
        }
        if(Input.GetKeyDown(KeyCode.Delete))
        {
            PlayerDataManager.Instance.Delete();
        }
    }
}
