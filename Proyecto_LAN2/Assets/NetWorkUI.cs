using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using TMPro;
using UnityEngine.UI;
public class NetWorkUI : NetworkBehaviour
{
    [SerializeField] private Button buttonHost;
    [SerializeField] private Button buttonClient;
    [SerializeField] private TextMeshProUGUI jugadores;

    private NetworkVariable<int> contadorJugadores = new NetworkVariable<int>(0, NetworkVariableReadPermission.Everyone);
    private void Awake()
    {
        buttonHost.onClick.AddListener(() =>
            {
                NetworkManager.Singleton.StartHost();
            });

        buttonClient.onClick.AddListener(() =>
            {
                NetworkManager.Singleton.StartClient();
            });
    }


    // Update is called once per frame
    void Update()
    {
        jugadores.text = "Jugadores : " + contadorJugadores.Value.ToString();
        if (!IsServer) return;
        contadorJugadores.Value = NetworkManager.Singleton.ConnectedClients.Count;
        
    }
}
