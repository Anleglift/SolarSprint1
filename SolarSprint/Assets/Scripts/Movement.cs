using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float HorizontalInput;
    public float speed;
    public Rigidbody2D rb;
    public Animator Player;
    public Vector2 newCenterOfMass;
    public float linearDrag = 0.5f;
    public float angularDrag = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        rb.drag = linearDrag;
        rb.angularDrag = angularDrag;
        rb.centerOfMass = newCenterOfMass;
    }
    // Update is called once per frame
    void Update()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2 (HorizontalInput * speed, rb.velocity.y);
        Orientation();
    }
    void Orientation ()
    {
        if (HorizontalInput > 0f)
        {
            Player.SetBool("Right", true);
            Player.SetBool("Left", false);
        }
        if (HorizontalInput < 0f)
        {
            Player.SetBool("Right", false);
            Player.SetBool("Left", true);
        }
        if (HorizontalInput == 0f) 
        {
            Player.SetBool("Right", false);
            Player.SetBool("Left", false);
        }
    }
}
