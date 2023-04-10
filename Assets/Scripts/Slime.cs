using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    // Start is called before the first frame update
    //void start()
    //{

    //}

    // Update is called once per frame
    //void Update()
    //{

    //}

    private float speed = 15f;
    private float jump = 4f;
    private float gravity = 9.81f;
    public Rigidbody2D rb;
    private bool onGround;
    private Vector2 v_zero = Vector2.zero;

    // Start is called before the first frame update
    private void Start()
    {
        onGround = true;
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.AddRelativeForce((Vector2.down*gravity));
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 currentVelocity = rb.velocity;

        if (horizontalInput != 0) 
        {
            // vitesse * temps = distance parcourus
            // position finale = position initiale + (vitesse * temps)
            Vector2 target_velocity = new Vector2((horizontalInput * speed), currentVelocity.y);
            rb.velocity = Vector2.SmoothDamp(rb.velocity, target_velocity, ref v_zero, 0.01f);
        }

        if (verticalInput > 0 && onGround) 
        {
            // vitesse * temps = distance parcourus
            // position finale = position initiale + (vitesse * temps)
            rb.AddForce((Vector2.up*jump), ForceMode2D.Impulse);
            onGround = false;
        }
        rb.AddRelativeForce((Vector2.down*gravity));
    }

    // called when the cube hits the floor
    void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log(col.transform.tag);
        onGround = true;
    }

    void OnCollisionStay2D(Collision2D col){
        onGround = true;
    }

    void OnCollisionExit2D(Collision2D col){
        onGround = false;
    }

}
