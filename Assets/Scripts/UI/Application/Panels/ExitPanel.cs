using System.Collections;
using System.Collections.Generic;
using UIFrameWork;
using UnityEngine;
using UnityEngine.UI;

public class ExitPanel : BasePanel
{
    private static readonly string path = "Prefabs/Panels/ExitPanel";
    public ExitPanel() : base(new UIType(path))
    {

    }

    public override void OnEnter()
    {
        GameObject panel = UIManager.Instance.GetSingleUI(UIType);
        UITool.GetOrAddComponentInChildren<Button>("Btn_Confirm", panel).onClick.AddListener(() =>
        {
            // 自动保存并退回到主菜单
            PanelManager.Instance.Pop();
        });
        UITool.GetOrAddComponentInChildren<Button>("Btn_Cancel", panel).onClick.AddListener(() =>
        {
            PanelManager.Instance.Pop();
        });
    }
}
