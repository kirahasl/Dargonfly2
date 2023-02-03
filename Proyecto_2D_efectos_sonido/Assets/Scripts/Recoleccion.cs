using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoleccion : MonoBehaviour
{
    public AudioSource clip;
    [SerializeField] private float cantidadPuntos; //declarando la variable que permite recibir el puntaje EL PUNTAJE SE DEFINE en el GameObject;
    [SerializeField] private Puntaje puntaje; //declarando la clase puntaje para convocar la funciona respectiva sumarpuntos.
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false; //desactivamos el Render de la fruta es decir se oculta.
            gameObject.transform.GetChild(0).gameObject.SetActive(true); //aca indicamos que el hijo se activa es decir el collected que esta desactivado se reacitva al colisionar.

            //FindObjectOfType<FruitManager>().AllFruitsCollected();//Validamos si quedan frutas, llamando al evento del script FruitManager
            puntaje.SumarPuntos(cantidadPuntos); //Puntaje llamando al metodo SumarPuntos de la clase puntaje.
            Destroy(gameObject, 0.5f); //de�spues de la animacion debemos destruir el collected. le damos 0,5 segundos.

            clip.Play();
        }
    }
}
