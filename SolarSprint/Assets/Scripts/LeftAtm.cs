using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeftAtm : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float fadeInDuration = 1.0f;
    public float waitDuration = 2.0f;
    public GameObject Player;
    private void Start()
    {
        canvasGroup.alpha = 0f;
    }

    IEnumerator FadeInCanvasAndRestartLevel()
    {
        // Fade the canvas in
        float startTime = Time.time;
        float endTime = startTime + fadeInDuration;

        while (Time.time < endTime)
        {
            float timeRatio = (Time.time - startTime) / fadeInDuration;
            float alpha = Mathf.Lerp(0.0f, 1.0f, timeRatio);

            canvasGroup.alpha = alpha;

            yield return null;
        }

        canvasGroup.alpha = 1.0f;

        // Wait for the specified duration
        yield return new WaitForSeconds(waitDuration);

        // Restart the level
        int currentSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentSceneIndex);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player)
        {
            StartCoroutine(FadeInCanvasAndRestartLevel());
            Player.SetActive(false);
        }
    }
}
