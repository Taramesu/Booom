using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerDataManager : Singleton2Manager<PlayerDataManager>
{
    [SerializeField] public string playerName;
    [SerializeField] public int playerLevel;
    [SerializeField] public float playerCurrentEXP;
    [SerializeField] public Vector2 playerPosition;
    [SerializeField] public float playerCurrentHP;
    [Serializable] class SaveData //需要存档的数据
    {
        public string playerName;

        public int playerLevel;

        public float playerCurrentEXP;

        public Vector2 playerPosition;

        public float playerCurrentHP;
    }

    const string PLAYER_DATA_FILE_NAME = "PlayerData.sav";

    /// <summary>
    /// 外部调用存档读档API
    /// </summary>
    #region API_S&L_DELETE
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

    #endregion

    #region JSON_S&L_DELETE

    void SaveByJson()
    {
        SaveSystem.Instance.SaveByJson(PLAYER_DATA_FILE_NAME, SavingData());
    }

    void LoadFromJson()
    {
        var saveData =  SaveSystem.Instance.LoadFromJson<SaveData>(PLAYER_DATA_FILE_NAME);
        LoadData(saveData);
    }

    void DeleteSaveFile()
    {
        SaveSystem.Instance.DeleteSaveFile(PLAYER_DATA_FILE_NAME);
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
        return saveData;
    }

    void LoadData(SaveData saveData)
    {
        playerName = saveData.playerName;
        playerLevel = saveData.playerLevel;
        playerCurrentEXP = saveData.playerCurrentEXP;
        playerPosition = saveData.playerPosition;
        playerCurrentHP = saveData.playerCurrentHP;
    }
    #endregion
}
