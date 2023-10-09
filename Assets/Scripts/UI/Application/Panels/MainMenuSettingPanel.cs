using System.Collections;
using System.Collections.Generic;
using UIFrameWork;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenuSettingPanel : BasePanel
{
    private static readonly string path = "Prefabs/Panels/MainMenuSettingPanel";
    public MainMenuSettingPanel() : base(new UIType(path))
    {

    }

    public override void OnEnter()
    {
        GameObject panel = UIManager.Instance.GetSingleUI(UIType);
        UITool.GetOrAddComponentInChildren<Button>("Btn_Close", panel).onClick.AddListener(() =>
        {
            PanelManager.Instance.Pop();
        });

        // ¶ÔÓÚÈ«ÆÁ
        if (Screen.fullScreen)
        {
            UITool.GetOrAddComponentInChildren<Toggle>("Toggle_FullScreen", panel).isOn = true;
        }
        else
        {
            UITool.GetOrAddComponentInChildren<Toggle>("Toggle_FullScreen", panel).isOn = false;
        }
        UITool.GetOrAddComponentInChildren<Toggle>("Toggle_FullScreen", panel).onValueChanged.AddListener(b =>
        {
            if (UITool.GetOrAddComponentInChildren<Toggle>("Toggle_FullScreen", panel).isOn)
            {
                Screen.fullScreen = true;
            }
            else
            {
                Screen.fullScreen = false;
            }
        });

    }
}
