using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Water : MonoBehaviour
{
    public GameObject Collision;
    public GameObject Player;
    public AudioSource AudioSource;
    public AudioClip WaterSplash;
    private Rigidbody2D rb;
    public Animator Water1;
    public float jumpVelocity;
    public GameObject WaterPrefab;
    private bool Enter;
    // Start is called before the first frame update
    void Start()
    {
        rb = Player.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Collision)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
        }
        if (collision.gameObject == Player)
        {
            AudioSource.clip = WaterSplash;
            AudioSource.Play();
            Water1.SetBool("Water", true);
            Invoke("ResetWater", 1f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == Player)
        {
            Enter = true;
        }
    }
    void ResetWater()
    {
        if (Enter)
        {
            Water1.SetBool("Water", false);
        }
    }
}
