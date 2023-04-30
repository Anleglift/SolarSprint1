using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float duration = 1.0f;

    private void Start()
    {
        // Start the fade-out process when the script is enabled
        StartCoroutine(FadeOutCanvas(duration));
    }

    IEnumerator FadeOutCanvas(float duration)
    {
        float startTime = Time.time;
        float endTime = startTime + duration;

        while (Time.time < endTime)
        {
            float timeRatio = (Time.time - startTime) / duration;
            float alpha = Mathf.Lerp(1.0f, 0.0f, timeRatio);

            canvasGroup.alpha = alpha;

            yield return null;
        }

        // Set the alpha to 0 when the fade-out is complete
        canvasGroup.alpha = 0.0f;

        // Add code to load the next scene here
    }
}
