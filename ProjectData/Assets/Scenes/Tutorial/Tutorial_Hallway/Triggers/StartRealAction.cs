using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartRealAction : MonoBehaviour
{
    [SerializeField] BabaykaMovement babayka;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == "Character")
        {
            babayka.startAction = true;
            babayka.GetComponent<AudioSource>().Play();
            Destroy(this);
        }
    }
}
