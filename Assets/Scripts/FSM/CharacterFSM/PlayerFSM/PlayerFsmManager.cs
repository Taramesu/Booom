using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerMoveDir
{ 
    up, down, left, right
}

//本脚本框架为状态机管理器，用以注册状态、更新状态等功能
public class PlayerFsmManager : MonoBehaviour
{
    private IState currentState;
    private Dictionary<PlayerST, IState> states = new Dictionary<PlayerST, IState>();

    public PlayerParameter parameter = new PlayerParameter();

    // Start is called before the first frame update
    void Start()
    {
        //此处注册状态
        states.Add(PlayerST.Idle, new PlayerIdleState(this));
        states.Add(PlayerST.WalkDown, new PlayerWalkDownState(this));
        states.Add(PlayerST.WalkLeft, new PlayerWalkLeftState(this));
        states.Add(PlayerST.WalkRight, new PlayerWalkRightState(this));
        states.Add(PlayerST.WalkUp, new PlayerWalkUpState(this));
        
        /*------------------------------------------------------------------*/
        InitializeData();

        TransitionState(PlayerST.Idle);//选择一个初始状态并在运行初始时转入（一般为Idle状态）
    }

    // 运行当前子状态的更新函数实现当前状态的实时更新
    void Update()
    {
        currentState.OnUpdate();
    }

    //状态转换方法
    public void TransitionState(PlayerST type)
    {
        if (currentState != null)
        {
            currentState.OnExit();
        }
        currentState = states[type];
        currentState.OnEnter();
    }

    #region Help_Function
    public PlayerMoveDir GetMoveDir(Vector2 inputData)
    {
        PlayerMoveDir dir;

        var moveRatio = inputData.y / inputData.x;

        if (inputData.y > 0)
        {
            dir = moveRatio >= 1 ? PlayerMoveDir.up : PlayerMoveDir.right;
        }
        else
        {
            dir = moveRatio >= 1 ? PlayerMoveDir.down : PlayerMoveDir.left;
        }

        return dir;
    }

    private void InitializeData()
    {
        DataManager.Instance.LoadAll();
        var data = DataManager.Instance.GetfasdffByID(8);
        parameter.currentHP = data.HP; 
        parameter.ATK = data.ATK;
        parameter.speed = data.speed;
        parameter.shootRate = data.shootRate;
        parameter.transform = GetComponent<Transform>();

#if UNITY_EDITOR
        Debug.Log($"realSpeed: {parameter.speed}");
        Debug.Log($"dataSpeed: {data.speed}");
#endif
    }
    #endregion
}
