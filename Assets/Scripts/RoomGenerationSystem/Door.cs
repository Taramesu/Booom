using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
    public Room targetRoomData;
    public Room currentRoomData;
    public bool isOpen;

    private TimeTools timeTools;
    private new SpriteRenderer renderer;
    private string doorName;
    // Start is called before the first frame update
    void Start()
    {
        timeTools = GetComponent<TimeTools>();
        renderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentRoomData.isCleared)
        {
            isOpen = true;
        }
        DoorControl();
    }

    private void DoorControl()
    {
        if (isOpen)
        {
            //renderer.sprite = AssetDatabase.LoadAssetAtPath<Sprite>(PathAndPrefabManager.Instance.GetDoorSpritePath(doorName + "-open"));
            renderer.sprite = Resources.Load<Sprite>(PathAndPrefabManager.Instance.GetDoorSpritePath(doorName + "-open"));
        }
        else
        {
            //renderer.sprite = AssetDatabase.LoadAssetAtPath<Sprite>(PathAndPrefabManager.Instance.GetDoorSpritePath(doorName + "-close"));
            renderer.sprite = Resources.Load<Sprite>(PathAndPrefabManager.Instance.GetDoorSpritePath(doorName + "-close"));
        }
    }

    public void InitialzeData()
    {
        switch (position)
        {
            case DoorPos.Left:
                doorName = "left";
                break;
            case DoorPos.Right:
                doorName = "right";
                break;
            case DoorPos.Top:
                doorName = "above";
                break;
            case DoorPos.Bottom:
                doorName = "below";
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            if(currentRoomData.isCleared)
            {

                var camera = Camera.main;
                camera.GetComponent<ScreenFader>().StartFade();
                roomEdge.transform.position = targetRoom.transform.position;
                RoomGenerator.Instance.roomEdgePosition = roomEdge.transform.position;
                collision.GetComponent<Transform>().position = target.position + transferOffset;
                collision.GetComponent<PlayerFsmManager>().parameter.currentRoomID = targetRoomData.roomID;

                MonsterGenerator.Instance.EnterRoom(targetRoomData);

                timeTools.PauseGame(0.3f);

            }
            
        }
    }
}
