using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerIdleState : IState
{
    private PlayerFsmManager manager;
    private PlayerParameter parameter;

    public PlayerIdleState(PlayerFsmManager manager)
    {
        //通过这里的构造函数可以使用管理器的方法，以及修改角色的参数
        this.manager = manager;
        this.parameter = manager.parameter;
    }

    public void OnEnter()
    {
        //此处填写进入此状态时的相关操作（如：播放此状态的动画，初始化某些数据）
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
        //此处写该状态的运行逻辑，以及退出该状态转入其他状态的时机判断（常用动画播放进度判断）

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
        //此处填写退出此状态时的相关操作
        manager.HeadSynchronize -= OnHeadSynchronizeIdle;
    }

    public void OnHeadSynchronizeIdle()
    {
        parameter.headSpriteRenderer.sprite = Resources.Load<Sprite>(parameter.headSpritePath + "head-front");
    }
}
