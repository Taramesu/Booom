using System.Collections;
using System.Collections.Generic;
using UIFrameWork;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene : SceneBase
{
    private static readonly string sceneName = "Scenes/GameScene";
    public override void OnEnter()
    {
        if (SceneManager.GetActiveScene().name != sceneName)
        {
            GameRoot.Instance.SwitchScene(sceneName);
            SceneManager.sceneLoaded += SceneLoaded;
        }
        else
        {
            //PanelManager.Instance.Push(new MainMenuPanel());
        }
    }

    public override void OnExit()
    {
        SceneManager.sceneLoaded -= SceneLoaded;
        PanelManager.Instance.Clear();
    }

    private void SceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //PanelManager.Instance.Push(new MainMenuPanel());
    }
}
