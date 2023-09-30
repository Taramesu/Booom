using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerIdleState : IState
{
    private PlayerFsmManager manager;
    private PlayerParameter parameter;

    public PlayerIdleState(PlayerFsmManager manager)
    {
        //ͨ������Ĺ��캯������ʹ�ù������ķ������Լ��޸Ľ�ɫ�Ĳ���
        this.manager = manager;
        this.parameter = manager.parameter;
    }

    public void OnEnter()
    {
        //�˴���д�����״̬ʱ����ز������磺���Ŵ�״̬�Ķ�������ʼ��ĳЩ���ݣ�
        //parameter.animator.Play("Idle");
    }

    public void OnUpdate()
    {
        //�˴�д��״̬�������߼����Լ��˳���״̬ת������״̬��ʱ���жϣ����ö������Ž����жϣ�

        if(PlayerInputData.Instance.moveVal != Vector2.zero)
        {
            switch (manager.GetMoveDir(PlayerInputData.Instance.moveVal))
            {
                case PlayerMoveDir.up:
                    manager.TransitionState(PlayerST.WalkUp);
                    break;
                case PlayerMoveDir.down:
                    manager.TransitionState(PlayerST.WalkDown);
                    break;
                case PlayerMoveDir.left:
                    manager.TransitionState(PlayerST.WalkLeft);
                    break;
                case PlayerMoveDir.right:
                    manager.TransitionState(PlayerST.WalkRight);
                    break;
            }
        }

    }

    public void OnExit()
    {
        //�˴���д�˳���״̬ʱ����ز���
    }
  
}
