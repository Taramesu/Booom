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
        parameter.animator.Play("idle");
        if(!parameter.attacking)
        {
            var image = AssetDatabase.LoadAssetAtPath<Sprite>(parameter.headSpritePath + "head-front.png");
            parameter.headSpriteRenderer.sprite = image;
#if UNITY_EDITOR
           if(image == null) 
           {
                Debug.Log("Failed to load the head image.");
            }
           else
            {
                Debug.Log("Succeed to load the head image");
            }
#endif
        }

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
