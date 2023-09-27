using FsmManager;
using Parameter;
using StateType;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class TestWalkState : IState
{
    private TestFsmManager manager;
    private TestParameter parameter;

    public TestWalkState(TestFsmManager manager)
    {
        //ͨ������Ĺ��캯������ʹ�ù������ķ������Լ��޸Ľ�ɫ�Ĳ���
        this.manager = manager;
        this.parameter = manager.parameter;
    }

    public void OnEnter()
    {
        //�˴���д�����״̬ʱ����ز������磺���Ŵ�״̬�Ķ�������ʼ��ĳЩ����
        Debug.Log("startWalk");
    }

    public void OnUpdate()
    {
        //�˴�д��״̬�������߼����Լ��˳���״̬ת������״̬��ʱ���жϣ����ö������Ž����жϣ�

        //manager.TransitionState(TestST.Attack); ����ʹ�ù�������״̬ת������ת�빥��״̬
        Debug.Log("Walking");
        Debug.Log("�ҵ�����"+parameter.name);
        if (PlayerInputData.Instance.moveVal == Vector2.zero)
        {
            manager.TransitionState(TestST.Empty);
        }
    }

    public void OnExit()
    {
        //�˴���д�˳���״̬ʱ����ز���
        Debug.Log("stopWalk");
    }
}
