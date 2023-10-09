using System.Collections;
using System.Collections.Generic;
using UIFrameWork;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuPanel : BasePanel
{
    private static readonly string path = "Prefabs/Panels/MainMenuPanel";
    public MainMenuPanel() : base(new UIType(path))
    {

    }

    public override void OnEnter()
    {
        GameObject panel = UIManager.Instance.GetSingleUI(UIType);
        UITool.GetOrAddComponentInChildren<Button>("Btn_StartGame", panel).onClick.AddListener(() =>
        {
            GameRoot.Instance.SwitchScene("GameScene");
        });
        UITool.GetOrAddComponentInChildren<Button>("Btn_Continue", panel).onClick.AddListener(() =>
        {
            
        });
        UITool.GetOrAddComponentInChildren<Button>("Btn_Setting", panel).onClick.AddListener(() =>
        {
            PanelManager.Instance.Push(new MainMenuSettingPanel());
        });
        UITool.GetOrAddComponentInChildren<Button>("Btn_Exit", panel).onClick.AddListener(() =>
        {
            PanelManager.Instance.Push(new PausePanel());
        });
    }
}
