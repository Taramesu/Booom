using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class test : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        //ArchiveSystem.Instance.LoadArchive();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        //Debug.Log(PlayerInputData.Instance.moveVal);
#endif
        if(Input.GetKeyDown(KeyCode.J))
        {
            ArchiveSystem.Instance.AutoSave();
        }
    }
}
