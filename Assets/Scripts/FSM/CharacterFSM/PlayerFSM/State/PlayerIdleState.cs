using UnityEditor;
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
        if(parameter.animator == null)
        {
            Debug.LogError("Miss animator");
        }
        parameter.animator.Play("idle");
        if(!parameter.attacking)
        {
            var image = Resources.Load<Sprite>(parameter.headSpritePath + "head-front");
            parameter.headSpriteRenderer.sprite = image;
#if UNITY_EDITOR
           //if(image == null) 
           //{
           //     Debug.Log("Failed to load the head image.");
           // }
           //else
           // {
           //     Debug.Log("Succeed to load the head image");
           // }
#endif
        }

        manager.HeadSynchronize += OnHeadSynchronizeIdle;

    }

    public void OnUpdate()
    {
        //�˴�д��״̬�������߼����Լ��˳���״̬ת������״̬��ʱ���жϣ����ö������Ž����жϣ�

        if(PlayerInputData.Instance.moveVal != Vector2.zero)
        {
            switch (manager.GetDir(PlayerInputData.Instance.moveVal))
            {
                case PlayerDir.up:
                    manager.TransitionState(PlayerST.WalkUp);
                    break;
                case PlayerDir.down:
                    manager.TransitionState(PlayerST.WalkDown);
                    break;
                case PlayerDir.left:
                    manager.TransitionState(PlayerST.WalkLeft);
                    break;
                case PlayerDir.right:
                    manager.TransitionState(PlayerST.WalkRight);
                    break;
            }
        }

    }

    public void OnExit()
    {
        //�˴���д�˳���״̬ʱ����ز���
        manager.HeadSynchronize -= OnHeadSynchronizeIdle;
    }

    public void OnHeadSynchronizeIdle()
    {
        parameter.headSpriteRenderer.sprite = Resources.Load<Sprite>(parameter.headSpritePath + "head-front");
    }
}
