using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public GameObject Collision;
    public GameObject Player;
    private Rigidbody2D rb;
    public Animator Water1;
    public float jumpVelocity;
    public GameObject WaterPrefab;
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
          
            Water1.SetBool("Water", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == Player)
        {
            Water1.SetBool("Water", false);
        }

    }
}
