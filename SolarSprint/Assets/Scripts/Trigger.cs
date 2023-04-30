using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour

{
    public GameObject Player;
    public GameObject Text;
    public GameObject Dialogue;
    public GameObject Image;
    public float DelayTime;
    public Dialogue CodeDialogue;

    // Start is called before the first frame update
    void Start()
    {
        Text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player)
        {
            Text.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
