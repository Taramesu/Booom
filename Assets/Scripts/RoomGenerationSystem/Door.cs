using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorPos
{
    Left, Right, Top, Bottom
}

public class Door : MonoBehaviour
{
    public RoomType nextRoomType;
    public DoorPos position;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
