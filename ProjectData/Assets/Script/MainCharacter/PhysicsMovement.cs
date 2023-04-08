using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private SurfaceSlider _surfaceSlider;
    [SerializeField] private float _speed;
    [SerializeField] float maxSprintStamina;
    [SerializeField] float sprintStaminaRecoveryBorder;
    [SerializeField] public AudioSource moveSound;
    [SerializeField] AudioClip walkSound;
    [SerializeField] AudioClip sprintSound;
    [SerializeField] SprintBar SprintBar;
    private float minSpeed;
    private float maxSpeed;
    float sprintStamina;
    float sprintStaminaRecovery;

    private void Start() 
    {
        minSpeed = _speed;
        maxSpeed = _speed * 1.5f;
        sprintStamina = maxSprintStamina;
        sprintStaminaRecovery = sprintStaminaRecoveryBorder;
        Time.timeScale = 1;
    }

    public void Move(Vector3 direction)
    {
        _rigidbody.AddForce(direction * _speed);
        if (_rigidbody.velocity.magnitude >= _speed)
        {
            _rigidbody.velocity = _rigidbody.velocity.normalized * _speed;
        }
        if(direction != Vector3.zero)
        {
            if(!moveSound.isPlaying)
                moveSound.Play();
        }
        else
        {
            moveSound.Stop();
        }
        SprintBar.ChangeSprintBar(sprintStamina, maxSprintStamina);
    }

    public void sprintSpeedChanger(float isSprindOn)
    {
        if(sprintStamina < sprintStaminaRecovery && isSprindOn == 0)
        {
            _speed--;
            moveSound.clip = walkSound;
            sprintStaminaRecovery = sprintStamina;
        }
        else if(isSprindOn == 1 && sprintStamina != 0 && sprintStaminaRecovery == sprintStaminaRecoveryBorder)
        {
            _speed++;
            moveSound.clip = sprintSound;
            sprintStamina--;
            if(sprintStamina == 0)
                sprintStaminaRecovery = 0;
        }
        else
        {
            _speed--;
            moveSound.clip = walkSound;
            if(isSprindOn == 0)
            {
                sprintStamina++;
                sprintStaminaRecovery++;
            }
        }
        sprintStamina = Mathf.Clamp(sprintStamina,0,maxSprintStamina);
        sprintStaminaRecovery = Mathf.Clamp(sprintStaminaRecovery,0,sprintStaminaRecoveryBorder);
        _speed = Mathf.Clamp(_speed,minSpeed,maxSpeed);
    }
}
