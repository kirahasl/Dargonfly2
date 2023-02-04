using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HighScore : MonoBehaviour
{

    private float HighScorep;//creamos una variable para el HighScore que se almacena en memoria.
    private TextMeshProUGUI TxtHighScore;//Asignamos un TextMeshProGui del Score

    private void Start()
    {

        TxtHighScore = GetComponent<TextMeshProUGUI>(); //inicializamos el TextMeshPro del HighScore


        if (PlayerPrefs.GetFloat("HighScorep") != 0) //si el valor de la variable en memoria del HighScore es diferente de 0 alamcenar el valor en el TextMesh de HighScore;
        {
            HighScorep = PlayerPrefs.GetFloat("HighScorep");//asignamos el valor del puntaje actual a la variable HighScorep
            TxtHighScore.text = HighScorep.ToString("0");//asignamos el nuevo valor a la variable yh al textMeshPro.
        }

    }

    private void Update()
    {
        TxtHighScore.text = HighScorep.ToString("0");//asignamos el nuevo valor a la variable yh al textMeshPro.
    }


    public void HighScorePuntos(float PuntosActuales)
    { //creamos un metodo para asignar el HighScore
      //validamos si el puntaje es mayor al actual asignado en caso de serlo asignamos el nuevo valor.
        HighScorep = PlayerPrefs.GetFloat("HighScorep");
        if (HighScorep < PuntosActuales)
        {
            
            HighScorep = PuntosActuales;//asignamos el valor del puntaje actual a variable HighScorep
            PlayerPrefs.SetFloat("HighScorep", HighScorep);
        }
    }
}