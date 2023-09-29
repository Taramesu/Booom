using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class RoomGenerator : Singleton2Manager<RoomGenerator>
{
    enum Direction { up, down, left, right }
    private Direction direction;

    //以下参数需要初始化
    #region Room_Infomation
    public string roomPrefabName;
    public int roomQuantity;
    #endregion

    #region Room_Position
    public Transform generatorPoint;
    public float xOffset;
    public float yOffset;
    public LayerMask roomLayer;
    #endregion

    private List<Room> rooms = new List<Room>();

    /// <summary>
    /// 房间生成API
    /// </summary>
    public void GenerateRooms()
    {
        for(int i = 0; i < roomQuantity; i++)
        {
            rooms.Add(Instantiate(GetRoomPrefab(roomPrefabName), generatorPoint.position, Quaternion.identity).GetComponent<Room>());
            ChangePointPos();
        }

        rooms[0].GetComponent<SpriteRenderer>().color = Color.green;
        rooms[roomQuantity-1].GetComponent<SpriteRenderer>().color = Color.red;

        foreach(var room in rooms)
        {
            room.UpdateRoom(rooms.IndexOf(room));
        }
    }

    void ChangePointPos()
    {
        do
        {
            direction = (Direction)Random.Range(0, 4);

            switch (direction) 
            {
                case Direction.up:
                    generatorPoint.position += new Vector3(0, yOffset, 0);
                    break;
                case Direction.down:
                    generatorPoint.position += new Vector3(0, -yOffset, 0);
                    break;
                case Direction.left:
                    generatorPoint.position += new Vector3(-xOffset, 0, 0);
                    break;
                case Direction.right:
                    generatorPoint.position += new Vector3(xOffset, 0, 0);
                    break;
            }
        }
        while (Physics2D.OverlapCircle(generatorPoint.position, 0.2f, roomLayer));
    }

    GameObject GetRoomPrefab(string roomPrefabName)
    {
        var path = "Assets/Prefabs/Rooms/" + roomPrefabName + ".prefab";
        try
        {
            var roomPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            return roomPrefab;
        }
        catch(System.Exception e)
        {
#if UNITY_EDITOR
            Debug.LogError($"Failed to Load room prefab at {path}. \n{e}");
#endif
            return default;
        }
    }
}
