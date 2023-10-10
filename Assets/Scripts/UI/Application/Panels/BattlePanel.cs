using System.Collections;
using System.Collections.Generic;
using UIFrameWork;
using UnityEngine;
using UnityEngine.UI;

public class BattlePanel : BasePanel
{
    private static readonly string path = "Prefabs/Panels/BattlePanel";
    public BattlePanel() : base(new UIType(path))
    {

    }

    public override void OnEnter()
    {
        GameObject panel = UIManager.Instance.GetSingleUI(UIType);
        UITool.GetOrAddComponentInChildren<Button>("Btn_Character", panel).onClick.AddListener(() =>
        {

        });
    }
}
