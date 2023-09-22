using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIFrameWork
{
    public class UITool
    {
        //给指定面版获取或添加一个组件
        public static T GetOrAddComponent<T>(GameObject panel) where T : Component
        {
            if (panel == null)
                return null;
            if (panel.GetComponent<T>() == null)
                panel.AddComponent<T>();
            return panel.GetComponent<T>();
        }
        //给指定面板移除一个组件
        public static void RemoveComponent<T>(GameObject panel) where T : Component
        {
            if (panel == null)
                return;
            if (panel.GetComponent<T>() == null)
                return;
            GameObject.Destroy(panel.GetComponent<T>());
        }

        //根据名称在指定面板中查找一个子对象
        public static GameObject FindChildGameObject(string name, GameObject panel)
        {
            if (name == null || name.Length == 0 || panel == null)
                return null;
            Transform[] trans = panel.GetComponentsInChildren<Transform>();
            foreach (Transform item in trans)
            {
                if (item.name == name)
                    return item.gameObject;
            }
            Debug.LogError($"{panel.name}里找不到名为{name}的子对象");
            return null;
        }

        //根据名称在指定面板中获取或添加一个组件
        public static T GetOrAddComponentInChildren<T>(string name, GameObject panel) where T : Component
        {
            if (name == null || name.Length == 0 || panel == null)
                return null;
            GameObject child = FindChildGameObject(name, panel);
            if (child)
            {
                if (child.GetComponent<T>() == null)
                    child.AddComponent<T>();
                return child.GetComponent<T>();
            }
            return null;
        }
    }
}


