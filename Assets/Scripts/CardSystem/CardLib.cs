using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardLib : Singleton2Manager<CardLib>
{
    public Dictionary<int, int[,]> m_shapeDic = new Dictionary<int, int[,]>
    {
        { 1, CardLib.Instance.shape_1},
        { 2, CardLib.Instance.shape_2},
    };

    public Dictionary<int, string> m_shapeSpritePath = new Dictionary<int, string>
    {
        { 1, PathAndPrefabManager.Instance.GetCardSpritePath("cube1")},
        { 2, PathAndPrefabManager.Instance.GetCardSpritePath("cube2")},
    };
    private int[,] shape_1 = new int[,]
    {
        { 1,1,0,0,0,0,0,0,0,0},
        { 1,1,0,0,0,0,0,0,0,0},
        { 1,1,0,0,0,0,0,0,0,0},
        { 1,1,0,0,0,0,0,0,0,0},
        { 1,1,0,0,0,0,0,0,0,0},
        { 1,1,0,0,0,0,0,0,0,0},
        { 0,0,0,0,0,0,0,0,0,0},
        { 0,0,0,0,0,0,0,0,0,0},
        { 0,0,0,0,0,0,0,0,0,0},
        { 0,0,0,0,0,0,0,0,0,0}
    };

    private int[,] shape_2 = new int[,]
    {
        { 1,1,0,0,0,0,0,0,0,0},
        { 0,0,0,0,0,0,0,0,0,0},
        { 0,0,0,0,0,0,0,0,0,0},
        { 0,0,0,0,0,0,0,0,0,0},
        { 0,0,0,0,0,0,0,0,0,0},
        { 0,0,0,0,0,0,0,0,0,0},
        { 0,0,0,0,0,0,0,0,0,0},
        { 0,0,0,0,0,0,0,0,0,0},
        { 0,0,0,0,0,0,0,0,0,0},
        { 0,0,0,0,0,0,0,0,0,0}
    };
}
