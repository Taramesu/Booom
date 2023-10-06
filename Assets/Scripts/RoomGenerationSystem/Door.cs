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
    public Vector3 transferOffset;
    public Transform targetRoom;
    public Transform roomEdge;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            var camera = Camera.main;
            camera.GetComponent<ScreenFader>().StartFade();
            roomEdge.transform.position = targetRoom.transform.position;
            RoomGenerator.Instance.roomEdgePosition = roomEdge.transform.position;
            collision.GetComponent<Transform>().position = target.position + transferOffset;

            TimeTools.Instance.PauseGame(0.3f);

#if UNITY_EDITOR
            //Debug.Log("player enter");
#endif
        }
    }
}
