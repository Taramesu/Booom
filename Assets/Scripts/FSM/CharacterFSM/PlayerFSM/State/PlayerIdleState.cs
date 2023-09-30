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
        //parameter.animator.Play("Idle");
    }

    public void OnUpdate()
    {
        //此处写该状态的运行逻辑，以及退出该状态转入其他状态的时机判断（常用动画播放进度判断）

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
        //此处填写退出此状态时的相关操作
    }
  
}
