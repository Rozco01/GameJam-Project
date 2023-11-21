using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{
    private Slider slider;
    private float life = 100f;
    
    private void Start()
    {
        slider = GetComponent<Slider>();       
    }

    public void ChangeMaxLife(float maxLife)
    {
        slider.maxValue = maxLife;
    }

    public void ChangeLife(float life)
    {
        slider.value = life;
    }

    public void InitializeLife(float life)
    {
        ChangeMaxLife(life);
        ChangeLife(life);
    }

}
