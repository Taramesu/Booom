using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPanelController : MonoBehaviour
{
    // Start is called before the first frame update
    public GridLayoutGroup gridLayout;
    public GameObject RedText;
    public GameObject GreenText;
    void Start()
    {
        var bufflist = BuffSystem.Instance.EnabledBuff;
        for(int i = 0; i < bufflist.Count; i++)
        {
            if (bufflist[i])
            {
                if (BuffSystem.Instance.BufftypeList[i] == BuffType.Enemy)
                {
                    AddChild(RedText, BuffSystem.Instance.Buffdeskist[i]);
                }
                else
                {
                    AddChild(GreenText, BuffSystem.Instance.Buffdeskist[i]);
                }
            }
        }
    }
    public void AddChild(GameObject childPrefab, string message)
    {
        // ʵ�����Ӷ���
        GameObject newChild = Instantiate(childPrefab, gridLayout.transform);
        newChild.GetComponent<TMP_Text>().text = message;
        // �������񲼾ֲ���
        RectTransform childRectTransform = newChild.GetComponent<RectTransform>();
        childRectTransform.localScale = Vector3.one;
        childRectTransform.localPosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
