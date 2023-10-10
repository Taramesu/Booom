using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSystem : Singleton2Manager<BuffSystem>
{
    //函数调用一次buff生效一次，并返回生效描述

    public string Card_0_Buff()
    {
        PlayerGenerator.Instance.fsmManager.parameter.currentHP -= 1;
        var buffDes = "扣除1血";
        return buffDes;
    }

    public string Card_1_Buff()
    {
        PlayerGenerator.Instance.fsmManager.parameter.speed -= 0.3f;
        var buffDes = "移速-0.3";
        return buffDes;
    }

    public string Card_2_Buff() 
    {

        var buffDes = "敌人移动速度+0.3";
        return buffDes;
    }      
           
    public string Card_3_Buff() 
    {
        var buffDes = "敌人攻击+0.5";
        return buffDes;
    }
    public string Card_4_Buff() 
    {
        PlayerGenerator.Instance.fsmManager.parameter.speed -= 0.1f;
        var buffDes = "移动速度-0.1";
        return buffDes;
    }
    public string Card_5_Buff() 
    {
        PlayerGenerator.Instance.fsmManager.parameter.ATK -= 1;
        var buffDes = "攻击力-1";
        return buffDes;
    }
    public string Card_6_Buff() 
    {
        PlayerGenerator.Instance.fsmManager.parameter.currentHP -= 1.5f;
        var buffDes = "扣除1.5血";
        return buffDes;
    }
    public string Card_7_Buff() 
    {
        var buffDes = "敌人生命+3";
        return buffDes;
    }
    public string Card_8_Buff() 
    {
        var buffDes = "扣除1血";
        return buffDes;
    }
    public string Card_9_Buff() 
    {
        var buffDes = "Boss血量+50";
        return buffDes;
    }
    public string Card_10_Buff() 
    {
        PlayerGenerator.Instance.fsmManager.parameter.shootRate -= 0.2f;
        var buffDes = "射速-0.2";
        return buffDes;
    }

}
