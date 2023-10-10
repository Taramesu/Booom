using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerDataManager : Singleton2Manager<PlayerDataManager>
{
    public string playerName;
    public int playerLevel;
    public float playerCurrentEXP;
    public Vector2 playerPosition;
    public float playerCurrentHP;
    public float playerCurrentMaxHP;
    public List<Vector3> roomPositionList;
    public List<Vector2> roomsMapIndex;
    public float currentSpeed;
    public Vector2 roomEdgePosition;
    public int currentRoomID;
    public bool isFirstGame;
    public int playrLevel;
    [Serializable]
    class SaveData //��Ҫ�浵������
    {
        public string playerName;

        public int playerLevel;

        public float playerCurrentEXP;

        public Vector2 playerPosition;

        public float playerCurrentHP;

        public float playerCurrentMaxHP;

        public float currentSpeed;

        public List<Vector3> roomPositionList = new List<Vector3>();

        public List<Vector2> roomsMapIndex = new List<Vector2>();

        public Vector2 roomEdgePosition;

        public int currentRoomID;

        public bool isFirstGame;

        public int playrLevel;
    }

    const string PLAYER_DATA_FILE_NAME = "PlayerData.sav";

    /// <summary>
    /// �ⲿ���ô浵����API
    /// </summary>
    #region API_S&L_DELETE_CHECK
    public void Save()
    {
        SaveByJson();
    }

    public void Load()
    {
        LoadFromJson();
    }

    public void Delete()
    {
        DeleteSaveFile();
    }

    public bool Check()
    {
        return CheckSaveFile();
    }

    #endregion

    #region JSON_S&L_DELETE_CHECK

    void SaveByJson()
    {
        SaveSystem.Instance.SaveByJson(PLAYER_DATA_FILE_NAME, SavingData());
    }

    void LoadFromJson()
    {
        var saveData = SaveSystem.Instance.LoadFromJson<SaveData>(PLAYER_DATA_FILE_NAME);
        LoadData(saveData);
    }

    void DeleteSaveFile()
    {
        SaveSystem.Instance.DeleteSaveFile(PLAYER_DATA_FILE_NAME);
    }

    bool CheckSaveFile()
    {
        return SaveSystem.Instance.CheckSaveFile(PLAYER_DATA_FILE_NAME);
    }

    #endregion

    #region Help Function
    SaveData SavingData()
    {
        var saveData = new SaveData();
        saveData.playerName = playerName;
        saveData.playerLevel = playerLevel;
        saveData.playerCurrentEXP = playerCurrentEXP;
        saveData.playerPosition = playerPosition;
        saveData.playerCurrentHP = playerCurrentHP;
        saveData.playerCurrentMaxHP = playerCurrentMaxHP;
        saveData.roomPositionList = roomPositionList;
        saveData.roomsMapIndex = roomsMapIndex;
        saveData.currentSpeed = currentSpeed;
        saveData.roomEdgePosition = roomEdgePosition;
        saveData.currentRoomID = currentRoomID;
        saveData.isFirstGame = isFirstGame;
        saveData.playerLevel = playerLevel;
        return saveData;
    }

    void LoadData(SaveData saveData)
    {
        playerName = saveData.playerName;
        playerLevel = saveData.playerLevel;
        playerCurrentEXP = saveData.playerCurrentEXP;
        playerPosition = saveData.playerPosition;
        playerCurrentHP = saveData.playerCurrentHP;
        playerCurrentMaxHP = saveData.playerCurrentMaxHP;
        roomPositionList = saveData.roomPositionList;
        roomsMapIndex = saveData.roomsMapIndex;
        currentSpeed = saveData.currentSpeed;
        roomEdgePosition = saveData.roomEdgePosition;
        currentRoomID = saveData.currentRoomID;
        isFirstGame = saveData.isFirstGame;
        playerLevel = saveData.playerLevel;
    }
    #endregion
}
