using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoTime : MonoBehaviour
{
    [SerializeField] private CanvasGroup myUIGroup;

    [SerializeField] private bool textIn = false;
    [SerializeField] private bool textOut = false;

    public void TextIn()
    {
        textIn = true;
    }
    public void TextOut() 
    { 
        textOut = true;
    }

    void Update()
    {
        if(textIn)
        {
            if(myUIGroup.alpha < 1)
            {
                myUIGroup.alpha += Time.deltaTime;
                if(myUIGroup.alpha >= 1)
                {
                    textIn = false;
                }
            }
        }
    }
}
