using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour
{
    int MaxHP = 100;
    int currentHP;

    public Slider slider;

    private void Start()
    {
        slider.value = 1;
        currentHP = MaxHP;
    }

    private void Update()
    {
        if(slider.value >= 0)
        {
            slider.value = PlayerParameterController.HP;
        }
    }
}
