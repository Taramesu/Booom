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
    public GameObject doorPrefabs;
    #endregion

    #region Room_Position
    public Transform generatorPoint;
    public float xOffset;
    public float yOffset;
    public LayerMask roomLayer;
    private int xRoomIndex;
    private int yRoomIndex;
    #endregion

    //private List<Room> rooms = new List<Room>();
    private List<List<Room>> roomsMap = new List<List<Room>>();

    /// <summary>
    /// 房间生成API
    /// </summary>
    public void GenerateRooms()
    {
        //for(int i = 0; i < roomQuantity; i++)
        //{
        //    rooms.Add(Instantiate(GetRoomPrefab(roomPrefabName), generatorPoint.position, Quaternion.identity).GetComponent<Room>());
        //    ChangePointPos();
        //}

        //rooms[0].GetComponent<SpriteRenderer>().color = Color.green;
        //rooms[roomQuantity-1].GetComponent<SpriteRenderer>().color = Color.red;

        //foreach(var room in rooms)
        //{
        //    room.UpdateRoom(rooms.IndexOf(room));
        //}

        //初始化地图网格
        for(int i = 0; i < 2*roomQuantity+2; i++)
        {
            List<Room> rooms = new List<Room>(2*roomQuantity+2);
            for(int j = 0; j < 2 * roomQuantity + 2; j++)
            {
                rooms.Add(null);
            }
            roomsMap.Add(rooms);
        }

        xRoomIndex = roomQuantity + 2;
        yRoomIndex = roomQuantity + 2;

        //生成地图房间数据
        for(int i = 0; i < roomQuantity; i++)
        {
            var room = Instantiate(GetRoomPrefab(roomPrefabName), generatorPoint.position, Quaternion.identity).GetComponent<Room>();
            roomsMap[yRoomIndex][xRoomIndex] = room;
            ChangePointPosAndIndex();
        }

        //生成房间通道
        for(int i = 1; i < 2*roomQuantity+1; i++)
        {
            for(int j = 1; j < 2*roomQuantity+1; j++)
            {
                var currentRoom = roomsMap[i][j];
                if (roomsMap[i][j] != null)
                {
                    if (roomsMap[i - 1][j] != null)
                    {
                        var door = Instantiate(doorPrefabs, currentRoom.bottomDoorPoint.position, Quaternion.identity).GetComponent<Door>();
                        door.nextRoomType = roomsMap[i - 1][j].type;
                        door.position = DoorPos.Bottom;
                        door.target = roomsMap[i - 1][j].topDoorPoint;
                    }
                    if (roomsMap[i + 1][j] != null)
                    {
                        var door = Instantiate(doorPrefabs, currentRoom.topDoorPoint.position, Quaternion.identity).GetComponent<Door>();
                        door.nextRoomType = roomsMap[i + 1][j].type;
                        door.position = DoorPos.Top;
                        door.target = roomsMap[i + 1][j].bottomDoorPoint;
                    }
                    if (roomsMap[i][j - 1] != null)
                    {
                        var door = Instantiate(doorPrefabs, currentRoom.rightDoorPoint.position, Quaternion.identity).GetComponent<Door>();
                        door.nextRoomType = roomsMap[i][j - 1].type;
                        door.position = DoorPos.Right;
                        door.target = roomsMap[i][j - 1].leftDoorPoint;
                    }
                    if (roomsMap[i ][j + 1] != null)
                    {
                        var door = Instantiate(doorPrefabs, currentRoom.leftDoorPoint.position, Quaternion.identity).GetComponent<Door>();
                        door.nextRoomType = roomsMap[i][j + 1].type;
                        door.position = DoorPos.Left;
                        door.target = roomsMap[i][j + 1].rightDoorPoint;
                    }
                }
            }
        }
    }

    void ChangePointPosAndIndex()
    {
        do
        {
            direction = (Direction)Random.Range(0, 4);

            switch (direction) 
            {
                case Direction.up:
                    generatorPoint.position += new Vector3(0, yOffset, 0);
                    yRoomIndex++;
                    break;
                case Direction.down:
                    generatorPoint.position += new Vector3(0, -yOffset, 0);
                    yRoomIndex--;
                    break;
                case Direction.left:
                    generatorPoint.position += new Vector3(-xOffset, 0, 0);
                    xRoomIndex--;
                    break;
                case Direction.right:
                    generatorPoint.position += new Vector3(xOffset, 0, 0);
                    xRoomIndex++;
                    break;
            }
        }
        while (roomsMap[yRoomIndex][xRoomIndex] != null);
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
