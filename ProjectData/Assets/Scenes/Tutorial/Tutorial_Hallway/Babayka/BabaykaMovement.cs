using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabaykaMovement : MonoBehaviour
{
    [SerializeField] public float speed;
    public bool startAction = false;
    public bool goForward = true;

    void Update() {
        if(Time.timeScale == 0)
            return;
        if(startAction && goForward)
            MoveBabaykaZ();
        else if(startAction && !goForward)
            MoveBabaykaX();
    }

    public void MoveBabaykaZ()
    {
        this.transform.position += Vector3.back * speed/75;
    }
    public void MoveBabaykaX()
    {
        this.transform.position += Vector3.left * speed/75;
    }
}
