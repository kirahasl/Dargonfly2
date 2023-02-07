using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class player : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) ) {
            transform.position += Vector3.left * 3f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * 3f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * 3f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * 3f * Time.deltaTime;
        }
        */
        //
        if (!IsOwner) return;
        float horizonalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(horizonalInput, 0, verticalInput);
        movimiento.Normalize();

        transform.Translate(movimiento * 3f * Time.deltaTime, Space.World);

        if (movimiento != Vector3.zero) {
            Quaternion rotacion = Quaternion.LookRotation(movimiento, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacion, 7f * Time.deltaTime);
        }


        ///mover con mouse libre para que lo agreguen aqui en las condiciones.
        ///
    }
}
