using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SprintBar : MonoBehaviour
{
    [SerializeField] Slider SprintSlider;

    public void ChangeSprintBar(float sprintStamina, float maxStamina)
    {
        SprintSlider.value = sprintStamina/maxStamina;
    }
}
