using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class RoomGenerator : Singleton2Manager<RoomGenerator>
{
    enum Direction { up, down, left, right }
    private Direction direction;

    //���²�����Ҫ��ʼ��
    #region Room_Infomation
    public string roomPrefabName;
    public string beginRoomPrefabName;
    public string monsterRoomPrefabName;
    public string bossRoomPrefabName;
    public int roomQuantity;
    public GameObject doorPrefabs;
    public GameObject roomEdgePrefab;

    public bool useArchive;
    public List<Vector3> roomPositionList = new List<Vector3>();
    public List<Vector2> roomsMapIndex = new List<Vector2>();
    public Vector2 roomEdgePosition;
    #endregion

    #region Room_Position
    public Transform generatorPoint;
    public float xOffset;
    public float yOffset;
    public LayerMask roomLayer;
    private int xRoomIndex;
    private int yRoomIndex;
    #endregion

    private List<List<Room>> roomsMap = new List<List<Room>>();

    /// <summary>
    /// ��������API
    /// </summary>
    public void GenerateRooms()
    {
        if(useArchive)
        {
            roomEdgePrefab.transform.position = roomEdgePosition;
            Debug.Log(roomEdgePosition);
        }
        else
        {
            roomEdgePrefab.transform.position = new Vector3(0, 0, 0);
        }
        

        generatorPoint.position = new Vector2(0, 0);

        //��ʼ����ͼ����
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

        //���ɵ�ͼ��������
        for(int i = 0; i < roomQuantity; i++)
        {
            GameObject roomPrefab;
            if(i == 0)
            {
                roomPrefab = GetRoomPrefab(beginRoomPrefabName);
            }
            else if(i == roomQuantity-1)
            {
                roomPrefab = GetRoomPrefab(bossRoomPrefabName);
            }
            else
            {
                roomPrefab = GetRoomPrefab(monsterRoomPrefabName);
            }
            var room = Instantiate(roomPrefab, generatorPoint.position, Quaternion.identity).GetComponent<Room>();
            roomsMap[yRoomIndex][xRoomIndex] = room;

            if(useArchive)
            {
                generatorPoint.position = roomPositionList[i];
                xRoomIndex = (int)roomsMapIndex[i].x;
                yRoomIndex = (int)roomsMapIndex[i].y;
            }
            else
            ChangePointPosAndIndex();
        }

        //���ɷ���ͨ��
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
                        door.transferOffset = new Vector3(0, -1.5f, 0);
                        door.targetRoom = roomsMap[i - 1][j].transform;
                        door.roomEdge = roomEdgePrefab.transform;
                        door.InitialzeData();
                    }
                    if (roomsMap[i + 1][j] != null)
                    {
                        var door = Instantiate(doorPrefabs, currentRoom.topDoorPoint.position, Quaternion.identity).GetComponent<Door>();
                        door.nextRoomType = roomsMap[i + 1][j].type;
                        door.position = DoorPos.Top;
                        door.target = roomsMap[i + 1][j].bottomDoorPoint;
                        door.transferOffset = new Vector3(0, 1.5f, 0);
                        door.targetRoom = roomsMap[i + 1][j].transform;
                        door.roomEdge = roomEdgePrefab.transform;
                        door.InitialzeData();
                    }
                    if (roomsMap[i][j - 1] != null)
                    {
                        var door = Instantiate(doorPrefabs, currentRoom.leftDoorPoint.position, Quaternion.identity).GetComponent<Door>();
                        door.nextRoomType = roomsMap[i][j - 1].type;
                        door.position = DoorPos.Left;
                        door.target = roomsMap[i][j - 1].rightDoorPoint;
                        door.transferOffset = new Vector3(-1.5f, 0, 0);
                        door.targetRoom = roomsMap[i][j - 1].transform;
                        door.roomEdge = roomEdgePrefab.transform;
                        door.InitialzeData();
                    }
                    if (roomsMap[i ][j + 1] != null)
                    {
                        var door = Instantiate(doorPrefabs, currentRoom.rightDoorPoint.position, Quaternion.identity).GetComponent<Door>();
                        door.nextRoomType = roomsMap[i][j + 1].type;
                        door.position = DoorPos.Right;
                        door.target = roomsMap[i][j + 1].leftDoorPoint;
                        door.transferOffset = new Vector3(1.5f, 0, 0);
                        door.targetRoom = roomsMap[i][j + 1].transform;
                        door.roomEdge = roomEdgePrefab.transform;
                        door.InitialzeData();
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
        roomPositionList.Add(generatorPoint.position);
        roomsMapIndex.Add(new Vector2(xRoomIndex, yRoomIndex));
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
