using FsmManager;
using StateType;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class MonsterGenerator : Singleton2Manager<MonsterGenerator>
{

    List<GameObject> monsterList = new List<GameObject>();

    public void GenerateMonster(Transform roomPos)
    {
        
        switch(Random.Range(1, 4))
        {
            case 1:
                GenerateTumour(roomPos);
                break;
            case 2:
                GenerateFly(roomPos);
                break;
            case 3:
                GenerateSkeleton(roomPos);
                break;
            default:
                break;
        }
        

    }

    public void RandomList()
    {

        

    }

    GameObject GetMonsterPrefab(string monsterPrefabName)
    {
        var path = "Assets/Prefabs/Enemy/" + monsterPrefabName + ".prefab";
        try
        {
            var roomPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            return roomPrefab;
        }
        catch (System.Exception e)
        {
#if UNITY_EDITOR
            Debug.LogError($"Failed to Load room prefab at {path}. \n{e}");
#endif
            return default;
        }
    }

    public void GenerateTumour(Transform roomPos)
    {

        GameObject tumour = GetMonsterPrefab("Tumour");
        tumour.GetComponent<TumourFsmManager>().center = roomPos.position;

        

        for(int i = -1; i < 2; i += 2)
        {
            for(int j = -1; j < 2; j += 2)
            {
                Vector3 position = roomPos.position;
                position.y += i * 2.5f;
                position.x += j * 5;

                Instantiate(tumour, position, Quaternion.identity);

            }
        }

    }

    public void GenerateFly(Transform roomPos)
    {
        GameObject fly = GetMonsterPrefab("Fly");
        fly.GetComponent<FlyFsmManager>().center = roomPos.position;
        Vector3 position = roomPos.position;
        Instantiate(fly, position, Quaternion.identity);
    }

    public void GenerateSkeleton(Transform roomPos)
    {
        GameObject skeleton = GetMonsterPrefab("Skeleton");
        skeleton.GetComponent<SkeletonFsmManager>().center = roomPos.position;
        Vector3 position = roomPos.position;
        Instantiate(skeleton, position, Quaternion.identity);

    }

}
