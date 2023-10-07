using UnityEngine;
using UnityEngine.InputSystem;

public class TestEmptyState : IState
{
    private TestFsmManager manager;
    private TestParameter parameter;

    public TestEmptyState(TestFsmManager manager)
    {
        //ͨ������Ĺ��캯������ʹ�ù������ķ������Լ��޸Ľ�ɫ�Ĳ���
        this.manager = manager;
        this.parameter = manager.parameter;
    }

    public void OnEnter()
    {
        //�˴���д�����״̬ʱ����ز������磺���Ŵ�״̬�Ķ�������ʼ��ĳЩ���ݣ�
    }

    public void OnUpdate()
    {
        //�˴�д��״̬�������߼����Լ��˳���״̬ת������״̬��ʱ���жϣ����ö������Ž����жϣ�

        //Debug.Log("idle");
        if(PlayerInputData.Instance.moveVal != Vector2.zero)
        manager.TransitionState(TestST.Walk); //����ʹ�ù�������״̬ת������ת�빥��״̬
    }

    public void OnExit()
    {
        //�˴���д�˳���״̬ʱ����ز���
    }
}
