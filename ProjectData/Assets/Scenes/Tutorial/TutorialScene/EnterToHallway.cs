using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterToHallway : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.name == "Character")
            SceneManager.LoadScene("Tutorial_Hallway");
    }
}
