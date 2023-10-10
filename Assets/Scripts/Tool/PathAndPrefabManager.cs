using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PathAndPrefabManager : Singleton2Manager<PathAndPrefabManager>
{
    public GameObject GetDoorPrefab(string roomPrefabName)
    {
        var path = "Assets/Prefabs/Doors/" + roomPrefabName + ".prefab";
        try
        {
            return AssetDatabase.LoadAssetAtPath<GameObject>(path);
        }
        catch (System.Exception e)
        {
#if UNITY_EDITOR
            Debug.Log($"Failed to load door prefab at {path}. \n{e}");
#endif
            return default;
        }
    }

    public GameObject GetRoomEdgePrefab(string roomEdgePrefabName)
    {
        var path = "Assets/Prefabs/Rooms/" + roomEdgePrefabName + ".prefab";
        try
        {
            return AssetDatabase.LoadAssetAtPath<GameObject>(path);
        }
        catch (System.Exception e)
        {
#if UNITY_EDITOR
            Debug.Log($"Failed to load roomEdge prefab at {path}. \n{e}");
#endif
            return default;
        }
    }

    public GameObject GetRoomSpawnPointPrefab(string spawnPointName)
    {
        var path = "Assets/Prefabs/Rooms/" + spawnPointName + ".prefab";
        try
        {
            return AssetDatabase.LoadAssetAtPath<GameObject>(path);
        }
        catch (System.Exception e)
        {
#if UNITY_EDITOR
            Debug.Log($"Failed to load spawnPoint prefab at {path}. \n{e}");
#endif
            return default;
        }
    }

    public GameObject GetPlayerPrefab(string playerPrefabName) 
    {
        var path = "Assets/Prefabs/" + playerPrefabName + ".prefab";
        try
        {
            return AssetDatabase.LoadAssetAtPath<GameObject>(path);
        }
        catch (System.Exception e)
        {
#if UNITY_EDITOR
            Debug.Log($"Failed to load player prefab at {path}. \n{e}");
#endif
            return default;
        }
    }

    public GameObject GetBulletPrefab(string BulletPrefabName)
    {
        var path = "Assets/Prefabs/Bullets/" + BulletPrefabName + ".prefab";
        try
        {
            return AssetDatabase.LoadAssetAtPath<GameObject>(path);
        }
        catch (System.Exception e)
        {
#if UNITY_EDITOR
            Debug.Log($"Failed to load bullet prefab at {path}. \n{e}");
#endif
            return default;
        }
    }

    public string GetDoorSpritePath(string spriteName)
    {
        var path = "Assets/ArtAssets/Door/" + spriteName + ".png";
        return path;
    }

    public string GetCardSpritePath(string spriteName)
    {
        var path = "Assets/ArtAssets/CardShape/" + spriteName + ".png";
        return path;
    }
}
