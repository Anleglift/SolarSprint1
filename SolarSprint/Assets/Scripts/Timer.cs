using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    FadeScript ShowUi;
    FadeScript HideUi;

    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;

    [Header("Limit Settings")]
    public bool hasLimit;
    public float timerLimit;

    void Start()
    {
        ShowUi = GameObject.FindGameObjectWithTag("FadeScript").GetComponent<FadeScript>();
        HideUi = GameObject.FindGameObjectWithTag("FadeScript").GetComponent <FadeScript>();
        HideUi.HideUI();
    }

    void Update()
    {
        timerText.color = Color.green;
        currentTime = countDown ? currentTime - Time.deltaTime : currentTime + Time.deltaTime;

        if (hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit)))
        {
            currentTime = timerLimit;
            SetTimerText(); 
            timerText.color = Color.red;
            enabled = false;
        }

        SetTimerText() ;

        if(currentTime == timerLimit)
        {
            ShowUi.ShowUI();

            Invoke("RestartLevel", 2);
            
        }
    }

    private void SetTimerText()
    {
        timerText.text = currentTime.ToString("0.0");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

