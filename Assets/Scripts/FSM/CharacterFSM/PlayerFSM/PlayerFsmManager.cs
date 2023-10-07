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

    private void OnEnable()
    {
      
    }

    // ���е�ǰ��״̬�ĸ��º���ʵ�ֵ�ǰ״̬��ʵʱ����
    void Update()
    {
        currentState.OnUpdate();
        OtherOperationManage();
    }

    private void OnDisable()
    {
        
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

        parameter.headSpritePath = "Assets/ArtAssets/Player/head/";

#if UNITY_EDITOR
        //Debug.Log($"realSpeed: {parameter.speed}");
        //Debug.Log($"dataSpeed: {data.speed}");
#endif
    }

    /// <summary>
    /// Player���⴦��AI��ֱ�ӽ�����д��״̬
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
                    parameter.headSpriteRenderer.sprite = AssetDatabase.LoadAssetAtPath<Sprite>(parameter.headSpritePath + "head-behind.png");
                    break;
                case PlayerDir.down:
                    parameter.headSpriteRenderer.sprite = AssetDatabase.LoadAssetAtPath<Sprite>(parameter.headSpritePath + "head-front.png");
                    break;
                case PlayerDir.left:
                    parameter.headSpriteRenderer.sprite = AssetDatabase.LoadAssetAtPath<Sprite>(parameter.headSpritePath + "head-left.png");
                    break;
                case PlayerDir.right:
                    parameter.headSpriteRenderer.sprite = AssetDatabase.LoadAssetAtPath<Sprite>(parameter.headSpritePath + "head-right.png");
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

    #endregion
}
