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

        // ��ȡ��ǰ��ֵ
        float currentcurrentHP = parameter.currentHP;
        float currentATK = parameter.ATK;
        float currentshootRate = parameter.shootRate;
        float currentspeed = parameter.speed;

        // ����Ƿ����˱仯
        healthText.text = "" + currentcurrentHP;

        attackPowerText.text = "" + currentATK;

        attackSpeedText.text = "" + currentshootRate;

        moveSpeedText.text = "" + currentspeed;
    }

    private void InitializeData()
    {
        parameter = PlayerGenerator.Instance.fsmManager.parameter;
        // ��ʼ��֮ǰ��ֵ
        previouscurrentHP = parameter.currentHP;
        previousATK = parameter.ATK;
        previousshootRate = parameter.shootRate;
        previousspeed = parameter.speed;
    }
}