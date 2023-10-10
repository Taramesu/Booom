using UnityEngine;
using System.Collections;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        // ArchiveSystem.Instance.LoadArchive();
        InitializeRoomData();
        InitializePlayerData();
        InitializeCameraData();
    }

    private void InitializeRoomData()
    {
        //设定数据
        var generator = RoomGenerator.Instance;
        generator.roomPrefabName = "Room1";
        generator.beginRoomPrefabName = "BeginRoom";
        generator.monsterRoomPrefabName = "MonsterRoom";
        generator.bossRoomPrefabName = "BossRoom";

        generator.roomQuantity = 7;
        generator.doorPrefabs = PathAndPrefabManager.Instance.GetDoorPrefab("door");
        generator.roomEdgePrefab = PathAndPrefabManager.Instance.GetRoomEdgePrefab("RoomEdge");
        generator.useArchive = ArchiveSystem.Instance.useArchive;

        generator.generatorPoint = PathAndPrefabManager.Instance.GetRoomSpawnPointPrefab("spawnPoint").transform;
        generator.xOffset = 40;
        generator.yOffset = 20;
        generator.roomLayer = LayerMask.GetMask("Room");
        //开始生成
        generator.GenerateRooms();
    }

    private void InitializeCameraData()
    {
        var virtualCamera = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        var confiner = virtualCamera.GetComponent<CinemachineConfiner2D>();
        //设置镜头移动范围
        confiner.m_BoundingShape2D = RoomGenerator.Instance.roomEdgePrefab.GetComponent<PolygonCollider2D>();
        //设置镜头跟随对象
        virtualCamera.Follow = PlayerGenerator.Instance.playerTransform;
    }

    private void InitializePlayerData()
    {
        if(ArchiveSystem.Instance.useArchive)
        {
            PlayerGenerator.Instance.playerPosition = PlayerDataManager.Instance.playerPosition;
        }
        else
        {
            PlayerGenerator.Instance.playerPosition = new Vector3(0, 0, 0);
        }
        PlayerGenerator.Instance.PlayerPrefab = PathAndPrefabManager.Instance.GetPlayerPrefab("Player");
        PlayerGenerator.Instance.GeneratePlayer();
    }

    
}