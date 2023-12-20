using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour
{
    int MaxHP = 100;
    float currentHP;

    public Slider slider;

    private void Start()
    {
        slider.value = 1;
        currentHP = MaxHP;
    }

    private void Update()
    {
        currentHP = PlayerParameterController._hp / MaxHP;
        slider.value = currentHP;
        if (slider.value >= 0)
        {
           
        }
    }
}
