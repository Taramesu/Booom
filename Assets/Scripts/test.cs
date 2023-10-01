using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject roomPrefab;

    // Start is called before the first frame update
    void Start()
    {
        RoomGenerator.Instance.roomPrefabName = "Room1";
        RoomGenerator.Instance.roomQuantity = 7;

        RoomGenerator.Instance.generatorPoint = spawnPoint;
        RoomGenerator.Instance.xOffset = 2;
        RoomGenerator.Instance.yOffset = 2;
        RoomGenerator.Instance.roomLayer = LayerMask.GetMask("Room");
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        Debug.Log(PlayerInputData.Instance.moveVal);
#endif
        if(Input.GetKeyDown(KeyCode.J))
        {
            RoomGenerator.Instance.GenerateRooms();
        }
    }
}
