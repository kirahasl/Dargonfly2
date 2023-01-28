//utilizamos nuestras librerias 
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveManager 
{
    //Al declarar como clase estatica evitamos que se generen varias instancias del mismo.

    //Al ser una clase statica los metodos tambien tendran que ser estaticos.
   
    //Creamos el metodo para guardar los datos
    public static void SavePlayerData(Player player,string Archivo)
    {
        //Inicializamos una instancia de playerData.cs
        PlayerData playerdata = new PlayerData(player);
        
        //Definir la ruta donde se guardar el binario
        string dataPath = Application.persistentDataPath + "/"+Archivo+".save";//Este comando crea una ruta persistente independiente y valido para cualquier salida de la aplicacion Android,Windows o MAC.
        
        Debug.Log(dataPath);
        // Libreria de Unity Application.persistentDataPath. el nombre del archivo puede tener cualquier extensión.

        //Para trabajar con archivos propias de C# es el FileStream para leer archivos o escribir.
        FileStream fileStream = new FileStream(dataPath, FileMode.Create); //FileMode permite Crear Abrir ... como el archivo no existe aqui lo vamos a crear.
        
        //Lo siguiente es Serializar nuestro archivo usando el metodo BinaryFormatter.
        BinaryFormatter binaryFormatter = new BinaryFormatter(); //Inicializamos el constructor
        //Serializamos el archivo e indicamos que datos se vana almacenar.
        binaryFormatter.Serialize(fileStream,playerdata);
        //Una vez grabado cerramos el fileStream (esto es importante sino consumo RAM y se mantiene abierto generando error ya que el archivo se queda abierto)
        fileStream.Close();
    }
    //Creamos el metodo para Cargar los datos guardados.
    public static PlayerData LoadPlayerData(string Archivo)
    {
        
        //Definir la ruta donde se guardar el binario
        string dataPath = Application.persistentDataPath + "/"+Archivo+".save";//Este comando crea una ruta persistente independiente y valido para cualquier salida de la aplicacion Android,Windows o MAC.
        // Libreria de Unity Application.persistentDataPath. el nombre del archivo puede tener cualquier extensión.

        //validamos que el archivo existe leemos los datos.
        if (File.Exists(dataPath))
        {
            //Como el archivo existe en este caso se debe Abrir el archivo
            FileStream fileStream = new FileStream(dataPath, FileMode.Open);

            //Lo siguiente es Deserializa nuestro archivo usando el metodo BinaryFormatter.
            BinaryFormatter binaryFormatter = new BinaryFormatter(); //Inicializamos el constructor
            //Ahora deserializamos la data;
            PlayerData playerData = (PlayerData) binaryFormatter.Deserialize(fileStream);
            //Como no sabemos el tipo de dato se castea al tipo de dato que se necesita (PlayerData).

            //Cerramos el Fichero
            fileStream.Close();
            //Retornamos el dato PlayerData
            return playerData;

            //Si desean eliminar el archivo 
            //Usar el siguiente proceso File.Delete(dataPath); // donde solo debes indicar la ruta donde se eliminara el archivo.
        }   
        //En caso no se cumpla la condicion indicamos que no existe.
        else{
            Debug.LogError("No se encontro el archivo de guardado");
            return null;
        }
    }
}