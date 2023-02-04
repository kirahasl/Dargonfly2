using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun; //Libreria de Photon para Online
using Photon.Realtime; //Libreria de Photon para Online

public class ManagerRed : MonoBehaviourPunCallbacks //renombar la extensión de lalibreria
{
    public static ManagerRed instancia; //Esto declaramos la instancia para iniciar la conexion de red de todo los usuario que se conecten.
    // Start is called before the first frame update
    private void Awake()
    {
        instancia = this;
        DontDestroyOnLoad(gameObject); //creamos esta accion para evitar que nuestra instancia credano se destruya. cuando se cambian de escena.
    }
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(); //Esto permite conectarnos a nuestro servidor, una vez cargada la instancia.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void OnConnectedToMaster() //Funcion que permite validar si estamos conectados al cargar el evento Start
    {
        Debug.Log("Estas conectado al servidor Photon"); //Mensaje de debug prueba para vlidar nuestra conexion al servidor.
    }
}
