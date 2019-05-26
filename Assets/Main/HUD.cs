using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    public Slider slider;
    private float hp = 1;
    
    void Update()
    {

    }

    void Damage(float damage)
    {
        hp -= damage;
        slider.value = hp;
    }


}
