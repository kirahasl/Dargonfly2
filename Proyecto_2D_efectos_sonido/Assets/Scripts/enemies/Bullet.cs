using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 3; //velocidad de la bala de la planta.
    public float lifeTime = 2; //vida a restar
    public bool left; //Para indicar la direccion de la bala

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        if (left)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player")) {
            //SI choca con el Personaje que lo destruya
            Debug.Log("Colision de Objeto con el jugador");
        }
    }
}
