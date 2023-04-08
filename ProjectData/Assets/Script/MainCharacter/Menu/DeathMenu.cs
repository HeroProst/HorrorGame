using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeathMenu : MonoBehaviour
{
    public void LoadGame()
    {
        SaveLoadScript.Load();
    }

    public void ExitMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
