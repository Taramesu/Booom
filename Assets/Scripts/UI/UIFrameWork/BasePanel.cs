using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//面板的基类
namespace UIFrameWork
{
    public abstract class BasePanel 
    {
        public UIType UIType { get; private set; }
        public BasePanel(UIType uIType)
        {
            UIType = uIType;
        }
        //进入时
        public virtual void OnEnter() { }
        //被其他面板覆盖时
        public virtual void OnPause()
        {
            GameObject panel = UIManager.Instance.GetSingleUI(UIType);
            UITool.GetOrAddComponent<CanvasGroup>(panel).blocksRaycasts = false;
        }
        //恢复时
        public virtual void OnResume()
        {
            GameObject panel = UIManager.Instance.GetSingleUI(UIType);
            UITool.RemoveComponent<CanvasGroup>(panel);
        }
        //退出时
        public virtual void OnExit()
        {
            UIManager.Instance.DestroyUI(UIType);
        }
    }
}

