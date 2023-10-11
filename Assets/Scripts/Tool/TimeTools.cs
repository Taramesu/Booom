using System.Collections;

using UnityEngine;

public class TimeTools : MonoBehaviour
{
    private float elapsedTime = 0f;
    private bool timerIsRunning = false;

    // 暂停游戏指定时间的函数
    public void PauseGame(float duration)
    {
        StartCoroutine(PauseCoroutine(duration));
    }

    // 协程函数，用于暂停游戏指定时间
    private IEnumerator PauseCoroutine(float duration)
    {
        // 记录当前的时间
        float startTime = Time.realtimeSinceStartup;

        // 暂停游戏
        Time.timeScale = 0f;

        // 等待指定的时间
        while (Time.realtimeSinceStartup - startTime < duration)
        {
            yield return null;
        }

        // 恢复游戏
        Time.timeScale = 1f;
    }

    /// <summary>
    /// 开始计时器
    /// </summary>
    public void StartTimer()
    {
        timerIsRunning = true;
    }

    /// <summary>
    /// 从beginTime开始计时
    /// </summary>
    /// <param name="beginTime"></param>
    public void StartTimer(float beginTime)
    {
        elapsedTime = beginTime;
        timerIsRunning = true;
    }

    /// <summary>
    /// 重置计时器，并开始计时
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
    /// 返回经过时间
    /// </summary>
    /// <returns></returns>
    public float GetElapsedTime()
    {
        return elapsedTime;
    }

    /// <summary>
    /// 关闭计时器，并返回经过时间
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
