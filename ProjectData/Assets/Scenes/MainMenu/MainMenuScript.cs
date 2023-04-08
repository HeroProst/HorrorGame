using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class MainMenuScript : MonoBehaviour
{
    void Start()
    {
        
    }

    public void ExitButtonPress()
    {
        Application.Quit();
    }

    public void StartButtonPress()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    public void LoadButtonPress()
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
