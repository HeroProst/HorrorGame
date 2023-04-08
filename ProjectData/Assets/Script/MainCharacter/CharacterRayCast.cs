using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRayCast : MonoBehaviour
{
    [SerializeField] float distance;
    [SerializeField] Camera characterCamera;

    public RaycastHit CastRay()
    {
        Ray ray = new Ray(characterCamera.transform.position, characterCamera.transform.forward);
        RaycastHit hit;
    
        Physics.Raycast(ray, out hit ,distance);
        return hit;
    }
}
