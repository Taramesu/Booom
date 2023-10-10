using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ArchiveSystem : Singleton2Manager<ArchiveSystem>
{
    public bool useArchive;

    /// <summary>
    /// 自动存档
    /// </summary>
    public void AutoSave()
    {
        SaveData();
        PlayerDataManager.Instance.Save();
    }

    /// <summary>
    /// 继续游戏读取存档
    /// </summary>
    public void LoadArchive()
    {
        PlayerDataManager.Instance.Load();
        LoadData();
        useArchive = true;
        PlayerDataManager.Instance.isFirstGame = false;
    }

    /// <summary>
    /// 新游戏建立新存档
    /// </summary>
    public void NewArchive()
    {
        useArchive = false;
        PlayerDataManager.Instance.isFirstGame = true;
    }

    /// <summary>
    /// 继续游戏检测是否存在存档
    /// </summary>
    /// <returns></returns>
    public bool IsArchiveExist()
    {
        return PlayerDataManager.Instance.Check();
    }

    private void SaveData()
    {
        var manage = PlayerDataManager.Instance;
        manage.roomPositionList = RoomGenerator.Instance.roomPositionList;
        manage.roomsMapIndex = RoomGenerator.Instance.roomsMapIndex;
        manage.roomEdgePosition = RoomGenerator.Instance.roomEdgePosition;
        
        var parameter = PlayerGenerator.Instance.fsmManager.parameter;
        manage.playerCurrentHP = parameter.currentHP;
        manage.playerCurrentMaxHP = parameter.currentMaxHP;
        manage.playerLevel = parameter.level;
        manage.playerPosition = parameter.transform.position;
        manage.currentSpeed = parameter.speed;
        manage.currentRoomID = parameter.currentRoomID;
    }

    private void LoadData()
    {
        var manage = PlayerDataManager.Instance;
        RoomGenerator.Instance.roomPositionList = manage.roomPositionList;
        RoomGenerator.Instance.roomsMapIndex = manage.roomsMapIndex;
        RoomGenerator.Instance.roomEdgePosition = manage.roomEdgePosition;

        var parameter = new PlayerParameter();
        parameter.currentHP = manage.playerCurrentHP;
        parameter.currentMaxHP = manage.playerCurrentMaxHP;
        parameter.level = manage.playerLevel;
        parameter.currentPosition = manage.playerPosition;
        parameter.speed = manage.currentSpeed;
        parameter.currentRoomID = manage.currentRoomID;
        PlayerGenerator.Instance.GetArchiveData(parameter);
    }
}
