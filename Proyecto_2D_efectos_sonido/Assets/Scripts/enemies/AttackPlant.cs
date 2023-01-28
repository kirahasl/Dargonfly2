using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlant : MonoBehaviour
{
    private float waitedTime; //tiempo de espera antes de atacar.

    public float waitTimeAttack = 3; //El tiempo de espera entre ataques de la planta.

    public Animator animator; //La animacion de ataque

    public GameObject bulletPrefab; //GameObject de la bala que se usara para la animacion de ataque;

    public Transform SpawnPoint_disparo;

    private void Start()
    {
        waitedTime = waitTimeAttack;
    }

    private void Update()
    {
        if (waitedTime <= 0) {  //validamos el tiempo si se vencio
            //en caso de vencerse
            waitedTime = waitTimeAttack;
            animator.Play("PlantAttackAnimation");
            Invoke("Lanzarbala", 0.5f);
        }

        else {
            waitedTime -= Time.deltaTime; //reducimos el tiempo
        }
    }

    public void Lanzarbala() {
        GameObject newBala;

        newBala = Instantiate(bulletPrefab, SpawnPoint_disparo.position, SpawnPoint_disparo.rotation); //creamos la bala cada vez que se dispara y pasado cierto tiempo vuelve a crearse el GameObject
    }
}
