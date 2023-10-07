using System.Collections;
using System.Collections.Generic;
using UIFrameWork;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestScene : SceneBase
{
    private static readonly string sceneName = "Scenes/TestScene";
    public override void OnEnter()
    {
        if (SceneManager.GetActiveScene().name != sceneName)
        {
            //SceneManager.LoadScene(sceneName);
            //这里才真正进行屏幕切换，以及触发切换事件
            GameRoot.Instance.SwitchScene(sceneName);
            SceneManager.sceneLoaded += SceneLoaded;
        }
        else
        {
            //切换屏幕时的事件写在这里,比如加入一个主游戏UI面板
            PanelManager.Instance.Push(new TestPanel());
            //这里跟SceneLoaded不一样的地方在于SceneLoaded会运行在某处使用SceneManager的SetScene函数后
            //使用SetScene后一般会运行上方if里的逻辑，而如果当前Scene已经是指定Scene则会运行这里
        }
    }

    public override void OnExit()
    {
        SceneManager.sceneLoaded -= SceneLoaded;
        PanelManager.Instance.Clear();
    }

    private void SceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //屏幕切换事件
        PanelManager.Instance.Push(new TestPanel());
    }
}
