using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool isGround = true;
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGround = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGround = false;
    }

    // Update is called once per frame

}
