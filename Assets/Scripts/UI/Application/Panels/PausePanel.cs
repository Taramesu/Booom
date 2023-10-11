using System.Collections;
using System.Collections.Generic;
using UIFrameWork;
using UnityEngine;
using UnityEngine.UI;

public class PausePanel : BasePanel
{
    private static readonly string path = "Prefabs/Panels/PausePanel";
    public PausePanel() : base(new UIType(path))
    {

    }

    public override void OnEnter()
    {
        GameObject panel = UIManager.Instance.GetSingleUI(UIType);
        UITool.GetOrAddComponentInChildren<Button>("Btn_Confirm", panel).onClick.AddListener(() =>
        {
            PlayerInputData.Instance.pauseGameVal = false;
            PanelManager.Instance.Pop();
            PanelManager.Instance.Pop();
        });
        UITool.GetOrAddComponentInChildren<Button>("Btn_Cancel", panel).onClick.AddListener(() =>
        {
            PanelManager.Instance.Pop();
        });
    }
}
