using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseInput : MonoBehaviour
{
    [SerializeField] private CameraMovement CameraMove;

    private void Update()
    {
        float mouseInputX = Input.GetAxisRaw("Mouse X");
        float mouseInputY = Input.GetAxisRaw("Mouse Y");
        if(Time.timeScale == 1)
            CameraMove.Rotate(new Vector3(0, mouseInputX, 0), new Vector3(-mouseInputY, 0, 0));
    }
}
