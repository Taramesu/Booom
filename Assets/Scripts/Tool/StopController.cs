using UnityEngine;

public class StopController : MonoBehaviour
{
    private bool isPaused = false; // 是否暂停运动的标志
    private void Start()
    {
        
    }
    // 更新方法，用于检测暂停输入
    void Update()
    {
        if (PlayerInputData.Instance.pauseGameVal)
        {
            isPaused = !isPaused;

            if (isPaused)
            {
                PauseMovement(); // 暂停物体运动
            }
            else
            {
                ResumeMovement(); // 恢复物体运动
            }
        }
    }

    // 暂停物体运动的方法
    void PauseMovement()
    {
        // 获取物体上的所有运动组件，例如Rigidbody、Animator等
        Component[] movementComponents = GetComponents(typeof(MonoBehaviour));

        // 禁用所有运动组件
        foreach (Component component in movementComponents)
        {
            if (component != this && component.GetType() != typeof(PlayerController)) // 排除当前脚本自身
            {
                ((MonoBehaviour)component).enabled = false;
            }
        }
    }

    // 恢复物体运动的方法
    void ResumeMovement()
    {
        // 获取物体上的所有运动组件
        Component[] movementComponents = GetComponents(typeof(MonoBehaviour));

        // 启用所有运动组件
        foreach (Component component in movementComponents)
        {
            if (component != this) // 排除当前脚本自身
            {
                ((MonoBehaviour)component).enabled = true;
            }
        }
    }
}
