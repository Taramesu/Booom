using System.Collections;
using System.Collections.Generic;
using UIFrameWork;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPanel : BasePanel
{
    private static readonly string path = "Prefabs/Panels/CharacterPanel";
    public CharacterPanel() : base(new UIType(path))
    {

    }

    public override void OnEnter()
    {
        GameObject panel = UIManager.Instance.GetSingleUI(UIType);
        UITool.GetOrAddComponentInChildren<Button>("Btn_Character", panel).onClick.AddListener(() =>
        {
           
        });
        UITool.GetOrAddComponentInChildren<Button>("Btn_Setting", panel).onClick.AddListener(() =>
        {
            PanelManager.Instance.Pop();
            PanelManager.Instance.Push(new GameSettingPanel());
        });
        UITool.GetOrAddComponentInChildren<Button>("Btn_Continue", panel).onClick.AddListener(() =>
        {
            PanelManager.Instance.Pop();
            PanelManager.Instance.Push(new PausePanel());
        });
        UITool.GetOrAddComponentInChildren<Button>("Btn_Exit", panel).onClick.AddListener(() =>
        {
            PanelManager.Instance.Pop();
            PanelManager.Instance.Push(new ExitPanel());
        });
    }
}
