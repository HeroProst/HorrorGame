using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceSlider : MonoBehaviour
{
    private Vector3 _normal;
    private Vector3 OldNormal;

    public Vector3 Project(Vector3 forward)
    {
        return forward - Vector3.Dot(forward, _normal) * _normal;
    }
    
    private void OnCollisionEnter(Collision collision) 
    {
        if(collision.GetContact(0).normal.y > 0.1)
        {
            _normal = collision.GetContact(0).normal;
            OldNormal = _normal;
        }
        else
        {
            _normal = OldNormal;
        }
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position, transform.position + _normal * 3);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Project(transform.forward)); 
    }
}
