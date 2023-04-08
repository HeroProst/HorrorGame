using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathToWaypoint : MonoBehaviour
{
    public GameObject[] waypoints;
    public int currentWp = 0;
    public float speed;

    public void GoToPath()
    {
        if(Vector3.Distance(this.transform.position, waypoints[currentWp].transform.position) < 1)
            currentWp++;
        if(currentWp >= waypoints.Length)
            currentWp = 0;
        
        this.transform.LookAt(waypoints[currentWp].transform);
        this.transform.Translate(0,0,speed * Time.deltaTime);
    }
}
