using FsmManager;

using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class MonsterGenerator : Singleton2Manager<MonsterGenerator>
{

    public List<GameObject> monsterList = new List<GameObject>();
    private Room currentRoom;

    public void EnterRoom(Room targetRoom)
    {

        currentRoom = targetRoom;
        if(!currentRoom.isCleared)
        {
            GenerateMonster();
        }

    }

    public void GenerateMonster()
    {

        
        Transform roomPos = currentRoom.transform;

        if(currentRoom.type == RoomType.BOSS)
        {
            GenerateBoss(roomPos);
        }
        else if(currentRoom.type == RoomType.EliteMonster)
        {
            if(Random.Range(1,11) < 6)
            {
                GenerateSuperFly(roomPos);
            }
            else
            {
                GenerateSuperSkeleton(roomPos);
            }
        }
        else if(currentRoom.type == RoomType.OrdinaryMonster)
        {
            GenerateTumour(roomPos);
            if (Random.Range(1, 11) < 6)
            {
                GenerateFly(roomPos);
            }
            else
            {
                GenerateSkeleton(roomPos);
            }
        }
        
    }

    private void Update()
    {

        if(currentRoom == null)
        {
            return;
        }

        if (!currentRoom.isCleared)
        {

            if(monsterList.Count == 0)
            {
                currentRoom.isCleared = true;
                ArchiveSystem.Instance.AutoSave();
            }

        }

    }

    GameObject GetMonsterPrefab(string monsterPrefabName)
    {
        var path = "Prefabs/Enemy/" + monsterPrefabName;
        try
        {
            //var roomPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            var roomPrefab = Resources.Load<GameObject>(path);
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


        for (int j = -1; j < 2; j += 2)
        {
            Vector3 position = roomPos.position;
            position.x += j * 3;

            GameObject gameObject = Instantiate(tumour, position, Quaternion.identity);

            monsterList.Add(gameObject);

        }

    }

    public void GenerateFly(Transform roomPos)
    {
        GameObject fly = GetMonsterPrefab("Fly");
        fly.GetComponent<FlyFsmManager>().center = roomPos.position;
        for (int i = -1; i < 2; i += 2)
        {
            for (int j = -1; j < 2; j += 2)
            {
                Vector3 position = roomPos.position;
                position.y += i * 2.5f;
                position.x += j * 5;

                GameObject gameObject = Instantiate(fly, position, Quaternion.identity);

                monsterList.Add(gameObject);

            }
        }
    }

    public void GenerateSkeleton(Transform roomPos)
    {
        GameObject skeleton = GetMonsterPrefab("Skeleton");
        skeleton.GetComponent<SkeletonFsmManager>().center = roomPos.position;

        for (int i = -1; i < 2; i += 2)
        {
            for (int j = -1; j < 2; j += 2)
            {
                Vector3 position = roomPos.position;
                position.y += i * 2.5f;
                position.x += j * 5;

                GameObject gameObject = Instantiate(skeleton, position, Quaternion.identity);

                monsterList.Add(gameObject);

            }
        }

    }

    public void GenerateSuperFly(Transform roomPos)
    {
        GameObject superFly = GetMonsterPrefab("SuperFly");
        superFly.GetComponent<SuperFlyFsmManager>().center = roomPos.position;
        for (int j = -1; j < 2; j += 2)
        {
            Vector3 position = roomPos.position;
            position.x += j * 3;

            GameObject gameObject = Instantiate(superFly, position, Quaternion.identity);

            monsterList.Add(gameObject);

        }
    }

    public void GenerateSuperSkeleton(Transform roomPos)
    {
        GameObject superSkeleton = GetMonsterPrefab("SuperSkeleton");
        superSkeleton.GetComponent<SuperSkeletonFsmManager>().center = roomPos.position;
        for (int j = -1; j < 2; j += 2)
        {
            Vector3 position = roomPos.position;
            position.x += j * 3;

            GameObject gameObject = Instantiate(superSkeleton, position, Quaternion.identity);

            monsterList.Add(gameObject);

        }
    }

    public void GenerateBoss(Transform roomPos)
    {
        GameObject boss = GetMonsterPrefab("satan");
        boss.GetComponent<SatanFsmManager>().center = roomPos.position;
        GameObject gameObject = Instantiate(boss, roomPos.transform.position, Quaternion.identity);
        monsterList.Add(gameObject);
    }


}
