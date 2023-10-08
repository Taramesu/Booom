using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class TimeTools : MonoBehaviour
{
    private float elapsedTime = 0f;
    private bool timerIsRunning = false;

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

    /// <summary>
    /// ��ʼ��ʱ��
    /// </summary>
    public void StartTimer()
    {
        timerIsRunning = true;
    }

    /// <summary>
    /// ��beginTime��ʼ��ʱ
    /// </summary>
    /// <param name="beginTime"></param>
    public void StartTimer(float beginTime)
    {
        elapsedTime = beginTime;
        timerIsRunning = true;
    }

    /// <summary>
    /// ���ü�ʱ��������ʼ��ʱ
    /// </summary>
    public void ResetAndStartTimer()
    {
        elapsedTime = 0f;
        timerIsRunning = true;

#if UNITY_EDITOR
        Debug.Log("Reset! Start Timer");
#endif
    }

    /// <summary>
    /// ���ؾ���ʱ��
    /// </summary>
    /// <returns></returns>
    public float GetElapsedTime()
    {
        return elapsedTime;
    }

    /// <summary>
    /// �رռ�ʱ���������ؾ���ʱ��
    /// </summary>
    public float StopTimer()
    {
        timerIsRunning = false;
        return elapsedTime;
    }

    private void Update()
    {
        if (timerIsRunning)
        {
            elapsedTime += Time.deltaTime;
        }
    }

}
