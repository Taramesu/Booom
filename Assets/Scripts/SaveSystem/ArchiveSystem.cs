using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchiveSystem : Singleton2Manager<ArchiveSystem>
{
    public bool useArchive;

    /// <summary>
    /// �Զ��浵
    /// </summary>
    public void AutoSave()
    {
        SaveData();
        PlayerDataManager.Instance.Save();
    }

    /// <summary>
    /// ������Ϸ��ȡ�浵
    /// </summary>
    public void LoadArchive()
    {
        PlayerDataManager.Instance.Load();
        LoadData();
        useArchive = true; 
    }

    /// <summary>
    /// ����Ϸ�����´浵
    /// </summary>
    public void NewArchive()
    {
        useArchive = false;
    }

    /// <summary>
    /// ������Ϸ����Ƿ���ڴ浵
    /// </summary>
    /// <returns></returns>
    public bool isArchiveExist()
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
        manage.playerPosition = parameter.transform.position;
        manage.currentSpeed = parameter.speed;
    }

    private void LoadData()
    {
        var manage = PlayerDataManager.Instance;
        RoomGenerator.Instance.roomPositionList = manage.roomPositionList;
        RoomGenerator.Instance.roomsMapIndex = manage.roomsMapIndex;
        RoomGenerator.Instance.roomEdgePosition = manage.roomEdgePosition;

        var parameter = new PlayerParameter();
        parameter.currentHP = manage.playerCurrentHP;
        parameter.currentPosition = manage.playerPosition;
        parameter.speed = manage.currentSpeed;
        PlayerGenerator.Instance.GetArchiveData(parameter);
    }
}
