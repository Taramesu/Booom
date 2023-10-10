using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
//游戏的根管理器
public class GameRoot : MonoBehaviour
{
    public static GameRoot Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    //设定开始运行加载的场景
    private void Start()
    {
        SceneSystem.Instance.SetScene(new MainMenuScene());
    }

    public void SwitchScene(string sceneName)
    {
        StartCoroutine(Delay(sceneName));      
    }

    private IEnumerator Delay(string sceneName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(sceneName);
        while(!ao.isDone)
        {
            yield return new WaitForSeconds(3.0f);
        }
    }
}
