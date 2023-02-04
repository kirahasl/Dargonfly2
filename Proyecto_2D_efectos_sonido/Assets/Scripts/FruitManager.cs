using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class FruitManager : MonoBehaviour
{
    public GameObject levelCompleted;
    public GameObject transition;
    [SerializeField] private HighScore highscorepuntos;
    [SerializeField] public TextMeshProUGUI txtPuntaje; //aqui agregamos el valor actual del puntaje.
    //creamos un objeto de tipo TextMeshPro para asignar a la variable.
    private void Start()
    {
        highscorepuntos = new HighScore();
    }
    private void Update()
    {
        AllFruitsCollected();
    }
    public void AllFruitsCollected() {
        if (transform.childCount == 0) {
            Debug.Log("No quedan frutas");


            levelCompleted.SetActive(true);

            //transition.SetActive(true);
            //Invoke("CambiarEscenario", 1.5f);
            
            highscorepuntos.HighScorePuntos(float.Parse(txtPuntaje.text));//Aqui llamamos al Evento para validar el puntaje actual
            UnityEditor.EditorApplication.isPlaying = false; //se usa esta funcion para finalizar el juego.
        }
    }

    void CambiarEscenario() {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Activa la siguiente Escena de acuerdo al Build de las escenas.

    }
}
