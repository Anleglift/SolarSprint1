using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip Music1;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource.clip = Music1;
        AudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
