using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    FadeScript ShowUi;
    FadeScript HideUi;

    NoTime ShowNoTime;
    NoTime HideNoTime;

    Retry RetryIn;
    Retry RetryOut;

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

        ShowNoTime = GameObject.FindGameObjectWithTag("NoTime").GetComponent<NoTime>();
        HideNoTime = GameObject.FindGameObjectWithTag("NoTime").GetComponent<NoTime>();
        HideNoTime.TextOut();

        RetryIn = GameObject.FindGameObjectWithTag("Retry").GetComponent<Retry>();
        RetryOut = GameObject.FindGameObjectWithTag("Retry").GetComponent<Retry>();
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
            ShowNoTime.Invoke("TextIn", 1);
            RetryIn.Invoke("RetryIn", 1);
        }
    }

    private void SetTimerText()
    {
        timerText.text = currentTime.ToString("0.0");
    }

}

