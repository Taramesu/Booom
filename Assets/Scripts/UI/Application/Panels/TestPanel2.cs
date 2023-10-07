using System.Collections;
using System.Collections.Generic;
using UIFrameWork;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestPanel2 : BasePanel
{
    private static readonly string path = "Prefabs/Panels/TestPanel2";
    public TestPanel2() : base(new UIType(path))
    {

    }
    public override void OnEnter()
    {
        GameObject panel = UIManager.Instance.GetSingleUI(UIType);
        
    }
}
