using System.Collections;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
    public float fadeDuration = 1f;  // 淡入淡出持续时间
    public float fadeWaitTime = 1f; // 淡入淡出之间的等待时间

    private CinemachineBrain cinemachineBrain;
    private CinemachineBlendDefinition originalBlendDefinition;

    private void Start()
    {
        cinemachineBrain = GetComponent<CinemachineBrain>();
        originalBlendDefinition = cinemachineBrain.m_DefaultBlend;
    }

    public void StartFade()
    {
        StartCoroutine(FadeCoroutine());
    }

    private IEnumerator FadeCoroutine()
    {
        // 创建一个用于淡入的黑色遮罩
        GameObject fadeCanvas = new GameObject("FadeCanvas");
        Canvas canvas = fadeCanvas.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        CanvasScaler canvasScaler = fadeCanvas.AddComponent<CanvasScaler>();
        canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        canvasScaler.referenceResolution = new Vector2(1920f, 1080f);
        fadeCanvas.AddComponent<UnityEngine.UI.Image>().color = Color.black;

        // 淡入淡出效果
        float time = 0f;
        while (time < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, time / fadeDuration);
            fadeCanvas.GetComponent<UnityEngine.UI.Image>().color = new Color(0f, 0f, 0f, alpha);
            time += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(fadeWaitTime);

        // 销毁黑色遮罩
        Destroy(fadeCanvas);

        // 恢复原始的混合效果
        cinemachineBrain.m_DefaultBlend = originalBlendDefinition;
    }
}