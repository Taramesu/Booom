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
            ArchiveSystem.Instance.NewArchive();
            SceneSystem.Instance.SetScene(new GameScene());
        });
        if (ArchiveSystem.Instance.IsArchiveExist())
        {
            UITool.GetOrAddComponentInChildren<Button>("Btn_Continue", panel).interactable = true;
            UITool.GetOrAddComponentInChildren<Button>("Btn_Continue", panel).onClick.AddListener(() =>
            {
                ArchiveSystem.Instance.LoadArchive();
                SceneSystem.Instance.SetScene(new GameScene());
            });
        }
        UITool.GetOrAddComponentInChildren<Button>("Btn_Setting", panel).onClick.AddListener(() =>
        {
            PanelManager.Instance.Push(new MainMenuSettingPanel());
        });
        UITool.GetOrAddComponentInChildren<Button>("Btn_Exit", panel).onClick.AddListener(() =>
        {
            Application.Quit();
            PanelManager.Instance.Push(new ExitPanel());
        });
    }
}
