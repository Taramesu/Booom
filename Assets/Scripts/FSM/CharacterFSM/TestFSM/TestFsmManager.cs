using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//本脚本框架为状态机管理器，用以注册状态、更新状态等功能
public class TestFsmManager : MonoBehaviour
{
    private IState currentState;
    private Dictionary<TestST, IState> states = new Dictionary<TestST, IState>();

    public TestParameter parameter = new TestParameter();

    // Start is called before the first frame update
    void Start()
    {
        //此处注册状态
        states.Add(TestST.Empty, new TestEmptyState(this));
        states.Add(TestST.Walk, new TestWalkState(this));

        /*------------------------------------------------------------------*/

        TransitionState(TestST.Empty);//选择一个初始状态并在运行初始时转入（一般为Idle状态）
    }

    // 运行当前子状态的更新函数实现当前状态的实时更新
    void Update()
    {
        currentState.OnUpdate();
    }

    //状态转换方法
    public void TransitionState(TestST type)
    {
        if (currentState != null)
        {
            currentState.OnExit();
        }
        currentState = states[type];
        currentState.OnEnter();
    }
}
