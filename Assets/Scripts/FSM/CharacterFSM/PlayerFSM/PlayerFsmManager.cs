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
        var degrees = Mathf.Rad2Deg * Mathf.Atan2(inputData.y, inputData.x);

        if(degrees is >= -135f and <=-45f)
        {
            dir = PlayerMoveDir.down;
        }
        else if (degrees is >= -45f and <= 45f)
        {
            dir = PlayerMoveDir.right;
        }
        else if (degrees is >= 45f and <= 135f)
        {
            dir= PlayerMoveDir.up;
        }else
        {
            dir = PlayerMoveDir.left;
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
        parameter.animator = transform.Find("Body").GetComponent<Animator>();
        parameter.headSpriteRenderer = transform.Find("Head").GetComponent<SpriteRenderer>();

        parameter.headSpritePath = "Assets/ArtAssets/Player/head/";

#if UNITY_EDITOR
        Debug.Log($"realSpeed: {parameter.speed}");
        Debug.Log($"dataSpeed: {data.speed}");
#endif
    }
    #endregion
}
