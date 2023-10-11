using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSystem : Singleton2Manager<BuffSystem>
{
    // ��Dictionary�洢����buff�Ƿ���Ч����ֵȫ��Ϊfalse
    public Dictionary<int, bool> EnabledBuff = new Dictionary<int, bool>();
    // ��Dictionary�洢����buff����
    public Dictionary<int, BuffType> BufftypeList = new Dictionary<int, BuffType>();
    public Dictionary<int, string> Buffdeskist = new Dictionary<int, string>() {
        {0,"�۳�1Ѫ"},
        {1,"����-0.3"},
        {2,"�����ƶ��ٶ�+0.3"},
        {3,"���˹���+0.5"},
        {4,"�ƶ��ٶ�-0.1"},
        {5,"������-1"},
        {6,"�۳�1.5Ѫ"},
        {7,"��������+3"},
        {8,"�۳�1Ѫ"},
        {9,"BossѪ��+50"},
        {10,"����-0.2"},
    };
    public BuffSystem()
    {
        for(int i = 0; i < 10; i++)
        {
            EnabledBuff[i] = false;
        }
        BufftypeList[0] = BuffType.Player;
        BufftypeList[1] = BuffType.Player;
        BufftypeList[2] = BuffType.Enemy;
        BufftypeList[3] = BuffType.Enemy;
        BufftypeList[4] = BuffType.Player;
        BufftypeList[5] = BuffType.Player;
        BufftypeList[6] = BuffType.Player;
        BufftypeList[7] = BuffType.Enemy;
        BufftypeList[8] = BuffType.Player;
        BufftypeList[9] = BuffType.Enemy;
        BufftypeList[10] = BuffType.Player;
    }

    // ִ��buff���������ֵΪnull���ʾ��buff�Ѿ�����
    public string Excute_Buff(int buffnum)
    {
        if (EnabledBuff[buffnum])
        {
            return null;
        }
        EnabledBuff[buffnum] = true;
        string buffDes = null;
        switch (buffnum){
            case 0: { buffDes = Card_0_Buff();break; } ;
            case 1: { buffDes = Card_1_Buff(); break; };
            case 2: { buffDes = Card_2_Buff(); break; };
            case 3: { buffDes = Card_3_Buff(); break; };
            case 4: { buffDes = Card_4_Buff(); break; };
            case 5: { buffDes = Card_5_Buff(); break; };
            case 6: { buffDes = Card_6_Buff(); break; };
            case 7: { buffDes = Card_7_Buff(); break; };
            case 8: { buffDes = Card_8_Buff(); break; };
            case 9: { buffDes = Card_9_Buff(); break; };
            case 10: { buffDes = Card_10_Buff(); break; };
        }
        return buffDes;
    }
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
