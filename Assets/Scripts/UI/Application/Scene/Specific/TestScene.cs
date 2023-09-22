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
            //���������������Ļ�л����Լ������л��¼�
            GameRoot.Instance.SwitchScene(sceneName);
            SceneManager.sceneLoaded += SceneLoaded;
        }
        else
        {
            //�л���Ļʱ���¼�д������,�������һ������ϷUI���
            PanelManager.Instance.Push(new TestPanel());
            //�����SceneLoaded��һ���ĵط�����SceneLoaded��������ĳ��ʹ��SceneManager��SetScene������
            //ʹ��SetScene��һ��������Ϸ�if����߼����������ǰScene�Ѿ���ָ��Scene�����������
        }
    }

    public override void OnExit()
    {
        SceneManager.sceneLoaded -= SceneLoaded;
        PanelManager.Instance.Clear();
    }

    private void SceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //��Ļ�л��¼�
        PanelManager.Instance.Push(new TestPanel());
    }
}
