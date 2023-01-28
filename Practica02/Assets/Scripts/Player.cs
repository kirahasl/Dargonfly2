using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public int health;
    public int score;
    public int Slot = 1; //Slot es para indicar el slot de guardado o numero de slot donde se guarda o se carga la partida.

    public  GameObject PanelSave;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text scoreText;

    private float hInput;
    private float vInput;
    private float speed = 5f;
    private Rigidbody2D playerRb;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        UpdateScoreUI(score);
        UpdateHealthUI(health);

    }

    private void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            IncreaseScore();
        }

        if (Input.GetKeyDown(KeyCode.G)) //Aqui agregamos la condicion para Grabar la Partida.
        {
            SaveData();
        }
        if (Input.GetKeyDown(KeyCode.C)) //Aqui agregamos la condcion para Cargar la Partida.
        {
            LoadData();
        }
        /*
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            Debug.Log("Presionaste 1");
            Slot = 1;
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            Debug.Log("Presionaste 2");
            Slot = 2;
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            Slot = 3;
        }
        */

    }

    private void Move()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");
        playerRb.velocity = new Vector2(hInput * speed, vInput * speed);
    }

    public void SaveData()
    {
        string Archivo;
        Archivo = "partida"+Slot; //cremos el nombre de nuestro Slot para guardar
        SaveManager.SavePlayerData(this,Archivo); //Aqui enviamos la instancia del GameObjet Player al PlayerData
        Debug.Log("Datos guardados"); 

        PanelSave.SetActive(true);



    }

    public void SlotButton(int vSlot){
        Slot = vSlot;
    }
    public void LoadData()
    {
        string Archivo;
        Archivo = "partida"+Slot; //cremos el nombre de nuestro Slot para guardar
         //seleccionamos el Archivo que queremos cargar
        PlayerData playerData = SaveManager.LoadPlayerData(Archivo);
        score = playerData.score;
        UpdateScoreUI(score);

        health = playerData.health;
        UpdateHealthUI(health);

        transform.position = new Vector3(playerData.position[0],playerData.position[1],playerData.position[2]);
        Debug.Log("Datos Cargados");
    }

    private void IncreaseScore()
    {
        score++;
        UpdateScoreUI(score);
    }

    private void UpdateScoreUI(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }

    private void OnCollisionEnter2D()
    {
        health--;
        UpdateHealthUI(health);
    }

    private void UpdateHealthUI(int health)
    {
        healthText.text = "Health: " + health.ToString();
    }
}