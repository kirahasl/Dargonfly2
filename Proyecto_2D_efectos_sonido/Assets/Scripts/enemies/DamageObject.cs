using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player")) {

            collision.transform.GetComponent<PlayerRespawn>().PlayerDamaged(); //Invocamos la funcion de PlayerRespawn asignada a Player, para recargar el escenario por la muerte.
            //Destroy(collision.gameObject); //Destruimos el GameObject que se esta colisionando en este caso el player

        }
    }
}
