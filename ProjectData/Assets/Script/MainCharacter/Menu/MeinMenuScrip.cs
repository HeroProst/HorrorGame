using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeinMenuScrip : MonoBehaviour
{
    [SerializeField] GameObject InGameMenu;
    bool InGameMenuStatus = false;

    public bool ReturnInGameMenuStatus()
    {
        return InGameMenuStatus;
    }

    public void ChangeInGameMenuStatus()
    {
        InGameMenuStatus = !InGameMenuStatus;
    }

    public void ResumeButtonPress()
    {
        CallMenu();
    }

    public void ExitButtonPress()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SaveButtonPress()
    {
        SaveLoadScript.Save();
    }

    public void CallMenu()
    {
        if(ReturnInGameMenuStatus())
        {
            InGameMenu.SetActive(false);
            ChangeInGameMenuStatus();
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
            InGameMenu.SetActive(true);
            ChangeInGameMenuStatus();
        }
    }
}
