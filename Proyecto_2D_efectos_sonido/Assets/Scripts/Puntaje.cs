using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Puntaje : MonoBehaviour
{
    private float puntos;
    private TextMeshProUGUI textMesh;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>(); //inicializamos el TextMeshPro
        puntos = 500; //Inicializamos el puntaje
    }

    private void Update()
    {
        
        puntos -= Time.deltaTime*3.3f; //Puntaje va a reducir sus puntos conforme pasa el tiempo.
        textMesh.text = puntos.ToString("0"); //Asignamos el puntaje al TextMeshPro
    }

    public void SumarPuntos(float puntosf) {  //Funcion llamada desde Recoleccion
        puntos += puntosf;
    }
}
