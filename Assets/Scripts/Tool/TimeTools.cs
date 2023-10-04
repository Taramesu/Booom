using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTools : Singleton2Manager<TimeTools>
{
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
}
