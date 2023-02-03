using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FruitManager : MonoBehaviour
{
    public GameObject levelCompleted;
    public GameObject transition;
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

        }
    }

    void CambiarEscenario() {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Activa la siguiente Escena de acuerdo al Build de las escenas.

    }
}
