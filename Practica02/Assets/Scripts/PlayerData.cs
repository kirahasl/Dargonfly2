[System.Serializable] //Esto Habilita la serializacion de datos para la clase creada
public class PlayerData 
{
    //declaramos las variables que deseo grabar
    public int health; //Vida
    public int score;  //Score
    public float[] position = new float[3];    //Posicion del Personaje

    //Nota: No podemos serializar datos especificos de Unity por lo que en este caso para la posición
    //usamos como variable auxiliar un float array para almacenar los 3 coordenadas.


    //Ahora debemos inicializar las variables
    public PlayerData(Player player)
    {
        health = player.health;
        score = player.score;
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
