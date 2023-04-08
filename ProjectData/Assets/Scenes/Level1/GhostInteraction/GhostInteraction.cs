using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostInteraction : MonoBehaviour
{
    [SerializeField] GameObject DeathMenu;
    
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name != "Character")
            return;
        Time.timeScale = 0;
        DeathMenu.SetActive(true);
    }
}
