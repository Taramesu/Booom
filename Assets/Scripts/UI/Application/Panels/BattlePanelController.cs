using System.Data.Common;
using UnityEngine;
using UnityEngine.UI;

public class BattlePanelController : MonoBehaviour
{
    public Text healthText;
    public Text attackPowerText;
    public Text attackSpeedText;
    public Text moveSpeedText;

    private float previouscurrentHP;
    private float previousATK;
    private float previousshootRate;
    private float previousspeed;

    public PlayerParameter parameter;
    private void Start()
    {
        
    }

    private void Update()
    {
        if (parameter == null) 
        {
            InitializeData();
            return;
        }

        // 获取当前的值
        float currentcurrentHP = parameter.currentHP;
        float currentATK = parameter.ATK;
        float currentshootRate = parameter.shootRate;
        float currentspeed = parameter.speed;

        // 检查是否发生了变化
        healthText.text = "" + currentcurrentHP;

        attackPowerText.text = "" + currentATK;

        attackSpeedText.text = "" + currentshootRate;

        moveSpeedText.text = "" + currentspeed;
    }

    private void InitializeData()
    {
        parameter = PlayerGenerator.Instance.fsmManager.parameter;
        // 初始化之前的值
        previouscurrentHP = parameter.currentHP;
        previousATK = parameter.ATK;
        previousshootRate = parameter.shootRate;
        previousspeed = parameter.speed;
    }
}