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

    public SpriteRenderer spriteRenderer; //Variable de renderizacion para move la direccion del sprite
    public Animator animator; //Para heredar las animaciones del Player.
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
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true); //para setear la variable y decir que se quede en run en el animator

        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2D.velocity = new Vector2(-correrSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true); //para setear la variable y decir que se quede en run en el animator
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            animator.SetBool("Run", false); //para setear la variable y decir que se quede en idle en el animator
        }

        //movimiento del personaje para saltar
        if (Input.GetKey("space") && Ground.isGround) {
            rb2D.velocity = new Vector2(rb2D.velocity.x,saltarSpeed);
            clipJump.Play();
            
        }
        if (Ground.isGround == false)
        {
            animator.SetBool("Jump", true); //para setear la variable y decir que se quede en Jump en el animator
            animator.SetBool("Run", false); //para setear la variable y decir que no haga animacion de salto.
        }
        else {
            animator.SetBool("Jump", false); //para setear la variable y decir que se quede en run en el animator
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
