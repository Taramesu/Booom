using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : Singleton2Manager<SaveSystem>
{
    #region PlayerPrefs

    public void SaveByPlayerPrefs(string key, object data)
    {
        var json = JsonUtility.ToJson(data);

        PlayerPrefs.SetString(key, json);
        PlayerPrefs.Save();

#if UNITY_EDITOR
        Debug.Log("Successfully saved data to PlayerPrefs. ");
#endif
    }

    public string LoadFromPlayerPrefs(string key)
    {

#if UNITY_EDITOR
        Debug.Log("Successfully loaded data from PlayerPrefs. ");
#endif

        return PlayerPrefs.GetString(key, null);
    }

    #endregion

    #region JSON_Save&Load
    public void SaveByJson(string saveFileName, object data)
    {
        var json = JsonUtility.ToJson(data);
        var path = Path.Combine(Application.persistentDataPath, saveFileName);
        try
        {
            File.WriteAllText(path, json);
            Debug.Log(path);
        }
        catch (System.Exception e)
        {
#if UNITY_EDITOR
            Debug.LogError($"Failed to save data to {path}. \n{e}");
#endif
        }
    }

    public T LoadFromJson<T>(string saveFileName)
    {
        var path = Path.Combine(Application.persistentDataPath, saveFileName);

        try
        {
            var json = File.ReadAllText(path);
            var data = JsonUtility.FromJson<T>(json);
            return data;
        }
        catch (System.Exception e)
        {
#if UNITY_EDITOR
            Debug.LogError($"Failed to Load data from {path}. \n{e}");
#endif
            return default;
        }
    }
    #endregion

    #region Deleting

    public void DeleteSaveFile(string saveFileName)
    {
        var path = Path.Combine(Application.persistentDataPath, saveFileName);

        try
        {
            File.Delete(path);
        }
        catch (System.Exception e) 
        {
#if UNITY_EDITOR
            Debug.LogError($"Failed to delete {path}. \n{e}");
#endif
        }
    }
    
    #endregion
}
