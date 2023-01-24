using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegundoNIvel : MonoBehaviour
{
    public AudioSource clip;
    public GameObject MusicaFondo;
    private AudioSource musica;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            clip.Play();
            musica = MusicaFondo.GetComponent<AudioSource>();
            musica.Stop();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            clip.Stop();
            musica = MusicaFondo.GetComponent<AudioSource>();
            musica.Play();

        }
    }
}