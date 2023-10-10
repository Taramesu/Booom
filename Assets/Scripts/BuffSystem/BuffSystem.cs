using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSystem : Singleton2Manager<BuffSystem>
{
    //��������һ��buff��Чһ�Σ���������Ч����

    public string Card_0_Buff()
    {
        PlayerGenerator.Instance.fsmManager.parameter.currentHP -= 1;
        var buffDes = "�۳�1Ѫ";
        return buffDes;
    }

    public string Card_1_Buff()
    {
        PlayerGenerator.Instance.fsmManager.parameter.speed -= 0.3f;
        var buffDes = "����-0.3";
        return buffDes;
    }

    public string Card_2_Buff() 
    {

        var buffDes = "�����ƶ��ٶ�+0.3";
        return buffDes;
    }      
           
    public string Card_3_Buff() 
    {
        var buffDes = "���˹���+0.5";
        return buffDes;
    }
    public string Card_4_Buff() 
    {
        PlayerGenerator.Instance.fsmManager.parameter.speed -= 0.1f;
        var buffDes = "�ƶ��ٶ�-0.1";
        return buffDes;
    }
    public string Card_5_Buff() 
    {
        PlayerGenerator.Instance.fsmManager.parameter.ATK -= 1;
        var buffDes = "������-1";
        return buffDes;
    }
    public string Card_6_Buff() 
    {
        PlayerGenerator.Instance.fsmManager.parameter.currentHP -= 1.5f;
        var buffDes = "�۳�1.5Ѫ";
        return buffDes;
    }
    public string Card_7_Buff() 
    {
        var buffDes = "��������+3";
        return buffDes;
    }
    public string Card_8_Buff() 
    {
        var buffDes = "�۳�1Ѫ";
        return buffDes;
    }
    public string Card_9_Buff() 
    {
        var buffDes = "BossѪ��+50";
        return buffDes;
    }
    public string Card_10_Buff() 
    {
        PlayerGenerator.Instance.fsmManager.parameter.shootRate -= 0.2f;
        var buffDes = "����-0.2";
        return buffDes;
    }

}
