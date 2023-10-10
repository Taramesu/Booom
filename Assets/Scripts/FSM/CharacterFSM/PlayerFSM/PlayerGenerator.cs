using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class PlayerGenerator : Singleton2Manager<PlayerGenerator>
{
    public GameObject PlayerPrefab;
    public Transform playerTransform;
    public Vector3 playerPosition;
    public PlayerFsmManager fsmManager;

    private PlayerParameter archiveData;
    private GameObject player;

    public void GeneratePlayer()
    {
        player = Instantiate(PlayerPrefab, playerPosition, Quaternion.identity);
        playerTransform = player.transform;
        fsmManager = player.GetComponent<PlayerFsmManager>();
        
        InitializeData(fsmManager.parameter);
    }

    public void GetArchiveData(PlayerParameter parameter)
    {
        archiveData = parameter;
    }

    private void InitializeData(PlayerParameter parameter)
    {
        //判断是否使用存档数据
        if (ArchiveSystem.Instance.useArchive)
        {
            fsmManager.parameter = archiveData;      
        }
        else
        {
            DataManager.Instance.LoadAll();
            var data = DataManager.Instance.GetfasdffByID(8);
            parameter.currentHP = data.HP;
            parameter.ATK = data.ATK;
            parameter.speed = data.speed;
            parameter.shootRate = data.shootRate;
        }
    }
}
