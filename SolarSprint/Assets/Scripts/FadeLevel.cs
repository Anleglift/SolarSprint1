using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeLevel : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float fadeInDuration = 1.0f;
    public float waitDuration = 2.0f;
    public string nextSceneName;

    private void Start()
    {
        canvasGroup.alpha = 0.0f;
        StartCoroutine(FadeInAndLoad());
    }

    private IEnumerator FadeInAndLoad()
    {
        float timer = 0.0f;
        while (timer < fadeInDuration)
        {
            float alpha = Mathf.Lerp(0.0f, 1.0f, timer / fadeInDuration);
            canvasGroup.alpha = alpha;
            timer += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 1.0f;
        yield return new WaitForSeconds(waitDuration);

        SceneManager.LoadScene(nextSceneName);
    }
}
