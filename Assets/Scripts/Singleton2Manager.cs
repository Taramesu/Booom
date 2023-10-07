using UnityEngine;
using System.Collections;
/// <summary>
/// µ¥ÀýÄ£°åÀà
/// </summary>
public class Singleton2Manager<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject obj = new GameObject();
                obj.name = typeof(T).Name + "<Singleton>";
                instance = obj.AddComponent<T>();
                DontDestroyOnLoad(obj);
            }

            return instance;
        }
    }
}