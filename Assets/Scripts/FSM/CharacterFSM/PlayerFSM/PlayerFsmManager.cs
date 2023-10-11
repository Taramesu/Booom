using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public enum PlayerDir
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
        OtherOperationManage();
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
    public PlayerDir GetDir(Vector2 inputData)
    {
        PlayerDir dir;
        var degrees = Mathf.Rad2Deg * Mathf.Atan2(inputData.y, inputData.x);

        if(degrees is >= -135f and <=-45f)
        {
            dir = PlayerDir.down;
        }
        else if (degrees is >= -45f and <= 45f)
        {
            dir = PlayerDir.right;
        }
        else if (degrees is >= 45f and <= 135f)
        {
            dir= PlayerDir.up;
        }else
        {
            dir = PlayerDir.left;
        }

        return dir;
    }

    private void InitializeData()
    {
        //DataManager.Instance.LoadAll();
        //var data = DataManager.Instance.GetfasdffByID(8);
        //parameter.currentHP = data.HP;
        //parameter.ATK = data.ATK;
        //parameter.speed = data.speed;
        //parameter.shootRate = data.shootRate;

        parameter.transform = GetComponent<Transform>();
        parameter.animator = transform.Find("Body").GetComponent<Animator>();
        parameter.headSpriteRenderer = transform.Find("Head").GetComponent<SpriteRenderer>();

        parameter.headSpritePath = "ArtAssets/Player/head/";

#if UNITY_EDITOR
        //Debug.Log($"realSpeed: {parameter.speed}");
        //Debug.Log($"dataSpeed: {data.speed}");
#endif
    }

    /// <summary>
    /// Player特殊处理，AI请直接将攻击写成状态
    /// </summary>
    private void OtherOperationManage()
    {
#if UNITY_EDITOR
        //Debug.Log($"attackData: {PlayerInputData.Instance.attackVal}");
#endif
        if(PlayerInputData.Instance.attackVal != Vector2.zero)
        {
            parameter.attacking = true;
            switch (GetDir(PlayerInputData.Instance.attackVal))
            {
                case PlayerDir.up:
                    parameter.headSpriteRenderer.sprite = Resources.Load<Sprite>(parameter.headSpritePath + "head-behind");
                    break;
                case PlayerDir.down:
                    parameter.headSpriteRenderer.sprite = Resources.Load<Sprite>(parameter.headSpritePath + "head-front");
                    break;
                case PlayerDir.left:
                    parameter.headSpriteRenderer.sprite = Resources.Load<Sprite>(parameter.headSpritePath + "head-left");
                    break;
                case PlayerDir.right:
                    parameter.headSpriteRenderer.sprite = Resources.Load<Sprite>(parameter.headSpritePath + "head-right");
                    break;
            }
        }
        else
        {
            parameter.attacking=false;
            HeadSynchronize?.Invoke();
        }

        if(PlayerInputData.Instance.dropBoomVal)
        {
#if UNITY_EDITOR
            Debug.Log("dropBoom!");
#endif
        }

        if(PlayerInputData.Instance.openBagVal)
        {
#if UNITY_EDITOR
            Debug.Log("openBag!");
#endif
        }

        if(PlayerInputData.Instance.useItemsVal)
        {
#if UNITY_EDITOR
            Debug.Log("useItems!");
#endif
        }
    }

    public event Action HeadSynchronize;

    public void GetDamage(float damage)
    {
        parameter.currentHP -= damage;
        Debug.Log(parameter.currentHP);
    }

    public Room GetCurrentRoom()
    {
        return RoomGenerator.Instance.GetPlayerCurrentRoom(parameter.currentRoomID);
    }

    #endregion
}
