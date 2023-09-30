using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerMoveDir
{ 
    up, down, left, right
}

//���ű����Ϊ״̬��������������ע��״̬������״̬�ȹ���
public class PlayerFsmManager : MonoBehaviour
{
    private IState currentState;
    private Dictionary<PlayerST, IState> states = new Dictionary<PlayerST, IState>();

    public PlayerParameter parameter = new PlayerParameter();

    // Start is called before the first frame update
    void Start()
    {
        //�˴�ע��״̬
        states.Add(PlayerST.Idle, new PlayerIdleState(this));
        states.Add(PlayerST.WalkDown, new PlayerWalkDownState(this));
        states.Add(PlayerST.WalkLeft, new PlayerWalkLeftState(this));
        states.Add(PlayerST.WalkRight, new PlayerWalkRightState(this));
        states.Add(PlayerST.WalkUp, new PlayerWalkUpState(this));
        
        /*------------------------------------------------------------------*/
        InitializeData();

        TransitionState(PlayerST.Idle);//ѡ��һ����ʼ״̬�������г�ʼʱת�루һ��ΪIdle״̬��
    }

    // ���е�ǰ��״̬�ĸ��º���ʵ�ֵ�ǰ״̬��ʵʱ����
    void Update()
    {
        currentState.OnUpdate();
    }

    //״̬ת������
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
