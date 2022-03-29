using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class Exploration_Progression : MonoBehaviour
{
    public Lootting script;
    public int maximum;
    public int current;
    public int minimum;
    public Image Mask;

    void Start()
    {
        maximum = GameObject.FindGameObjectsWithTag("Chest").Length;
    }


    void Update()
    {

            current += 1;
            GetCurrentFill();
        if (current >= maximum)
        {
            current += 0;
        }
    }
    void GetCurrentFill()
    {
        float currentOffset = current - minimum;
        float maxOffset = maximum - minimum;
        float fillAmount = currentOffset / maxOffset;
        Mask.fillAmount = fillAmount;
    }
}
