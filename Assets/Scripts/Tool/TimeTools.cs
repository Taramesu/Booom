using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTools : Singleton2Manager<TimeTools>
{
    // ��ͣ��Ϸָ��ʱ��ĺ���
    public void PauseGame(float duration)
    {
        StartCoroutine(PauseCoroutine(duration));
    }

    // Э�̺�����������ͣ��Ϸָ��ʱ��
    private IEnumerator PauseCoroutine(float duration)
    {
        // ��¼��ǰ��ʱ��
        float startTime = Time.realtimeSinceStartup;

        // ��ͣ��Ϸ
        Time.timeScale = 0f;

        // �ȴ�ָ����ʱ��
        while (Time.realtimeSinceStartup - startTime < duration)
        {
            yield return null;
        }

        // �ָ���Ϸ
        Time.timeScale = 1f;
    }
}
