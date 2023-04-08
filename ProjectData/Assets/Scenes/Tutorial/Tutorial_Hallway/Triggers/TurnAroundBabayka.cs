using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAroundBabayka : MonoBehaviour
{
    [SerializeField] BabaykaMovement babayka;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name != "Character")
        {
            Quaternion newQ = other.gameObject.transform.rotation;
            newQ.eulerAngles = new Vector3(0,180,0);
            other.gameObject.transform.rotation = newQ;
            babayka.goForward = false;
            Destroy(this);
        }
    }
}
