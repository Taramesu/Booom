using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PathAndPrefabManager : Singleton2Manager<PathAndPrefabManager>
{
    public GameObject GetDoorPrefab(string roomPrefabName)
    {
        var path = "Prefabs/Doors/" + roomPrefabName;
        try
        {
            return Resources.Load<GameObject>(path);
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
        var path = "Prefabs/Rooms/" + roomEdgePrefabName;
        try
        {
            return Resources.Load<GameObject>(path);
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
        var path = "Prefabs/Rooms/" + spawnPointName;
        try
        {
            return Resources.Load<GameObject>(path);
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
        var path = "Prefabs/" + playerPrefabName;
        try
        {
            return Resources.Load<GameObject>(path);
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
        var path = "Prefabs/Bullets/" + BulletPrefabName;
        try
        {
            return Resources.Load<GameObject>(path);
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
        var path = "ArtAssets/Door/" + spriteName;
        return path;
    }

    public string GetCardSpritePath(string spriteName)
    {
        var path = "ArtAssets/CardShape/" + spriteName;
        return path;
    }

    public GameObject GetCardPrefab(string cardName)
    {
        var path = "Prefabs/Cards/" + cardName;
        try
        {
            return Resources.Load<GameObject>(path);
        }
        catch (System.Exception e)
        {
#if UNITY_EDITOR
            Debug.Log($"Failed to load card prefab at {path}. \n{e}");
#endif
            return default;
        }
    }

    public GameObject GetCardBagPrefab(string cardBagName)
    {
        var path = "Prefabs/Cards/" + cardBagName;
        try
        {
            return Resources.Load<GameObject>(path);
        }
        catch (System.Exception e)
        {
#if UNITY_EDITOR
            Debug.Log($"Failed to load cardBag prefab at {path}. \n{e}");
#endif
            return default;
        }
    }
}
