using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LerpShip : MonoBehaviour
{
    public float startDelay = 0.5f;   // Delay before lerping starts
    public float lerpTime = 0.25f;       // Time it takes to complete the lerp
    public float lerpHeight = 1f;     // Height to lerp the object
    private Vector2 startPosition;   // Start position of the object
    private float lerpTimer = 0f;     // Timer for the lerp
    private bool isLerping = false;   // Flag to indicate if lerping is in progress
    public bool Yes=false;
    public float startDelay1 = 1f;   // Delay before lerping starts
    public float lerpTime1 = 1f;     // Time it takes to complete the lerp
    private float startAlpha;       // Start alpha value of the canvas
    private float lerpTimer1 = 0f;   // Timer for the lerp
    private bool isLerping1 = false; // Flag to indicate if lerping is in progress
    public CanvasGroup canvasGroup;
    public GameObject Canvas;
    public AudioClip Press;
    public AudioSource AudioSource;
    void Start()
    {
        AudioSource.clip = Press;
        Canvas.SetActive(false);
        startPosition = transform.position;
        startAlpha = canvasGroup.alpha;
    }

    void Update()
    {
        if (Yes)
        {
            if (startDelay > 0f)
            {
                startDelay -= Time.deltaTime;
                return;
            }

            if (isLerping)
            {
                lerpTimer += Time.deltaTime;
                float t = lerpTimer / lerpTime;
                transform.position = Vector2.Lerp(startPosition, startPosition + Vector2.up * lerpHeight, t);
                if (lerpTimer >= lerpTime)
                {
                    isLerping = false;
                }
            }
            else
            {
                isLerping = true;
                lerpTimer = 0f;
                startPosition = transform.position;
            }
            Invoke("TransitionOut", 2f);
        }
    }
    public void StartLerp()
    {
        AudioSource.Play();
        Yes = true;
        Canvas.SetActive(true);

    }
    private void TransitionOut()
    {
        if (startDelay1 > 0f)
        {
            startDelay1 -= Time.deltaTime;
            return;
        }

        if (isLerping1)
        {
            lerpTimer1 += Time.deltaTime;
            float t = lerpTimer1 / lerpTime1;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 1f, t);
            if (lerpTimer1 >= lerpTime1)
            {
                isLerping1 = false;
            }
        }
        else
        {
            isLerping1 = true;
            lerpTimer1 = 0f;
            startAlpha = canvasGroup.alpha;
        }
        Invoke("NextLevel", 3f);
    }
    private void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex+1;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
