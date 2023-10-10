using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Card : MonoBehaviour
{
    public bool isEffective;
    public int ID;
    public int[,] shape;
    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        GetShape();
        GetSprite();
    }

    private void GetShape()
    {
        if(CardLib.Instance.m_shapeDic.ContainsKey(ID))
        {
            shape = CardLib.Instance.m_shapeDic[ID];
        }
        else
        {
#if UNITY_EDITOR
            Debug.Log($"Failed to find shape_{ID}");
#endif
        }
    }

    private void GetSprite()
    {
        if (CardLib.Instance.m_shapeSpritePath.ContainsKey(ID))
        {
            spriteRenderer.sprite = AssetDatabase.LoadAssetAtPath<Sprite>(CardLib.Instance.m_shapeSpritePath[ID]);
        }
        else
        {
#if UNITY_EDITOR
            Debug.Log($"Failed to find shape_{ID}_Sprite");
#endif
        }
    }
}
