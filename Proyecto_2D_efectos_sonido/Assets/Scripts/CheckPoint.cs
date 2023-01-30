using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            collision.GetComponent<PlayerRespawn>().ReachedCheckPoint(transform.position.x, transform.position.y);  //Llamamos al Script PlayerRespawn insertado en el GameObject Player.
            //en el metodo anterior le estamos enviando las coordenadas del checkpoint para que el objeto Player se traslade a las coordenadas del checkpoint.
            GetComponent<Animator>().enabled = true;
        }
    }
}
