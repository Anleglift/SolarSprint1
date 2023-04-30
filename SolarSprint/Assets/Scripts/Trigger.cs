using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour

{
    public GameObject Player;
    public GameObject Text;
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
        if(CodeDialogue.index == CodeDialogue.lines.Length)
        {
            Destroy(Text, DelayTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player)
        {
            Text.SetActive(true);
        }
    }
}
