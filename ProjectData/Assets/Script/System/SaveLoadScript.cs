using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoadScript
{
    public static void Save()
    {
        string currentLocation = SceneManager.GetActiveScene().name;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create (Application.persistentDataPath + "/savedGames.gd");
        bf.Serialize(file, currentLocation);
        file.Close();
        Debug.Log("Save");
    }

    public static void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/savedGames.gd")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
            string sceneName = (string)bf.Deserialize(file);
            file.Close();
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.Log("NO");
        }
    }
}
