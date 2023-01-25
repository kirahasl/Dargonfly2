using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float correrSpeed =  3;
    public float saltarSpeed = 5;
    Rigidbody2D rb2D;

    public bool gransalto = true;
    public float multiplicador = 0.5f;
    public float bajo_multiplicador = 1.0f;
    public AudioSource clipJump;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //definido lo movimientos del personaje izquierda derecha

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2D.velocity = new Vector2(correrSpeed, rb2D.velocity.y);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2D.velocity = new Vector2(-correrSpeed, rb2D.velocity.y);
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
        }

        //movimiento del personaje para saltar
        if (Input.GetKey("space") && Ground.isGround) {
            rb2D.velocity = new Vector2(rb2D.velocity.x,saltarSpeed);
            clipJump.Play();
        }

        //gran salto
        if (gransalto) {

            if (rb2D.velocity.y < 0) 
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (multiplicador) * Time.deltaTime;
            }
            if (rb2D.velocity.y > 0 && !Input.GetKey("space"))
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (bajo_multiplicador) * Time.deltaTime;
            }


        }
    }
}
