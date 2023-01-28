using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSalto : MonoBehaviour
{
    //Variables publicas
    public Collider2D collider2D; //Para la Colision del Objetyo con el Jugador

    public Animator animator; //Para  la animacion del Enemigo

    public SpriteRenderer spriterenderer; //Para el Sprite del Enemigo

    public GameObject destroyParticle; //Para el GameObject del Enemigo

    public float jumpForce = 2.5f; //Definir el salto maximo.
     
    public int lifes = 1; //Definir la vida del enemigo


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player")) { //Aqui validamos si el objeto con el que estoy colisionando es el Jugador en caso sea se ejecuta lo que esta dentro.
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * jumpForce); //igualamos el salto del jugador. (efecto)
            perdervida(); //evento para ejecutar cuando se pierda la vida
            validarvida(); //evento para validar si el enemigo tiene vida todavia.
        }
    }
    public void perdervida() {
        lifes--; //restamos vida
        animator.Play("Hit"); //cambiar la Animacion a la de Perdida, cada vez que se pierda la vida
    }
    public void validarvida() {
        if (lifes == 0) {
            destroyParticle.SetActive(true); //para agregar efecto de desaparicion
            spriterenderer.enabled = false; //para eliminar el objeto
            Invoke("enemyDie", 0.2f); //este evento se ejecuta despues de 0.2f para destruir el GameObject por completo-
        }
    }

    public void enemyDie() {
        Destroy(gameObject); //Aqui se destruye el GameObject.
    }
}
