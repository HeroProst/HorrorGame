using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Camera CharacterCamera;
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float vericalSpeed;

    public void Rotate(Vector3 directionX, Vector3 directionY)
    {
        var rotationAngleX = Quaternion.Euler(directionX * Time.fixedDeltaTime * horizontalSpeed);
        _rigidbody.MoveRotation(_rigidbody.rotation * rotationAngleX);

        if(Math.Truncate(CharacterCamera.transform.rotation.eulerAngles.x) < 85 || Math.Truncate(CharacterCamera.transform.rotation.eulerAngles.x) > 270)
        {
            var rotationAngleY = Quaternion.Euler(directionY * Time.fixedDeltaTime * vericalSpeed);
            if(Math.Truncate((CharacterCamera.transform.rotation * rotationAngleY).eulerAngles.x) < 85 || Math.Truncate((CharacterCamera.transform.rotation * rotationAngleY).eulerAngles.x) > 270)
                CharacterCamera.transform.rotation = CharacterCamera.transform.rotation * rotationAngleY;
        }
    }
}
