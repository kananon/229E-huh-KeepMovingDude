using UnityEngine;
using System.Collections;

public class UIFadeIn : MonoBehaviour
{
    public float fadeDuration = 2f;

    private CanvasGroup canvasGroup;

    void Start()
    {
        // 🔥 หาเองอัตโนมัติ ไม่ต้องลากใน Inspector
        canvasGroup = GetComponent<CanvasGroup>();

        // เริ่มจากมองไม่เห็น
        canvasGroup.alpha = 0f;

        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;

            canvasGroup.alpha = Mathf.Lerp(0, 1, time / fadeDuration);

            yield return null;
        }

        canvasGroup.alpha = 1f;

        // เปิดให้กด UI ได้
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }
}