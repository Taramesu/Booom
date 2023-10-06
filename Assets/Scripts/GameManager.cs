using UnityEngine;
using System.Collections;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        ArchiveSystem.Instance.LoadArchive();
        InitializeRoomData();
        InitializePlayerData();
        InitializeCameraData();
    }

    private void InitializeRoomData()
    {
        //�趨����
        RoomGenerator.Instance.roomPrefabName = "Room1";
        RoomGenerator.Instance.roomQuantity = 7;
        RoomGenerator.Instance.doorPrefabs = PathAndPrefabManager.Instance.GetDoorPrefab("door");
        RoomGenerator.Instance.roomEdgePrefab = PathAndPrefabManager.Instance.GetRoomEdgePrefab("RoomEdge");
        RoomGenerator.Instance.useArchive = ArchiveSystem.Instance.useArchive;

        RoomGenerator.Instance.generatorPoint = PathAndPrefabManager.Instance.GetRoomSpawnPointPrefab("spawnPoint").transform;
        RoomGenerator.Instance.xOffset = 40;
        RoomGenerator.Instance.yOffset = 20;
        RoomGenerator.Instance.roomLayer = LayerMask.GetMask("Room");
        //��ʼ����
        RoomGenerator.Instance.GenerateRooms();
    }

    private void InitializeCameraData()
    {
        var virtualCamera = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        var confiner = virtualCamera.GetComponent<CinemachineConfiner2D>();
        //���þ�ͷ�ƶ���Χ
        confiner.m_BoundingShape2D = RoomGenerator.Instance.roomEdgePrefab.GetComponent<PolygonCollider2D>();
        //���þ�ͷ�������
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