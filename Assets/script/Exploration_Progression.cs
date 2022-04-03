using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exploration_Progression : MonoBehaviour
{
    public Slider slider;

    public void SetMaxChest(int health)
    {
        slider.maxValue = 10;
        slider.value = health;
    }
    public void SetChest(int optain)
    {
        slider.value = optain;
    }

}
