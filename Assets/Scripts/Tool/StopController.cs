using UnityEngine;

public class StopController : MonoBehaviour
{
    private bool isPaused = false; // �Ƿ���ͣ�˶��ı�־
    private void Start()
    {
        
    }
    // ���·��������ڼ����ͣ����
    void Update()
    {
        if (PlayerInputData.Instance.pauseGameVal)
        {
            isPaused = !isPaused;

            if (isPaused)
            {
                PauseMovement(); // ��ͣ�����˶�
            }
            else
            {
                ResumeMovement(); // �ָ������˶�
            }
        }
    }

    // ��ͣ�����˶��ķ���
    void PauseMovement()
    {
        // ��ȡ�����ϵ������˶����������Rigidbody��Animator��
        Component[] movementComponents = GetComponents(typeof(MonoBehaviour));

        // ���������˶����
        foreach (Component component in movementComponents)
        {
            if (component != this && component.GetType() != typeof(PlayerController)) // �ų���ǰ�ű�����
            {
                ((MonoBehaviour)component).enabled = false;
            }
        }
    }

    // �ָ������˶��ķ���
    void ResumeMovement()
    {
        // ��ȡ�����ϵ������˶����
        Component[] movementComponents = GetComponents(typeof(MonoBehaviour));

        // ���������˶����
        foreach (Component component in movementComponents)
        {
            if (component != this) // �ų���ǰ�ű�����
            {
                ((MonoBehaviour)component).enabled = true;
            }
        }
    }
}
