using FsmManager;
using Parameter;
using StateType;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestEmptyState : IState
{
    private TestFsmManager manager;
    private TestParameter parameter;

    public TestEmptyState(TestFsmManager manager)
    {
        //通过这里的构造函数可以使用管理器的方法，以及修改角色的参数
        this.manager = manager;
        this.parameter = manager.parameter;
    }

    public void OnEnter()
    {
        //此处填写进入此状态时的相关操作（如：播放此状态的动画，初始化某些数据）
    }

    public void OnUpdate()
    {
        //此处写该状态的运行逻辑，以及退出该状态转入其他状态的时机判断（常用动画播放进度判断）

        //Debug.Log("idle");
        if(PlayerInputData.Instance.moveVal != Vector2.zero)
        manager.TransitionState(TestST.Walk); //例：使用管理器的状态转换函数转入攻击状态
    }

    public void OnExit()
    {
        //此处填写退出此状态时的相关操作
    }
}
