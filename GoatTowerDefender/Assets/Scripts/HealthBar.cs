using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;

    // Available to change fill color to show various damage levels //
    /*public Gradient gradient;
    public Image fill;*/

    public void setMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        // Available to change fill color to show various damage levels //
        /*fill.color = gradient.Evaluate(1f);*/
    }

    public void setHealth(int health)
    {
        slider.value = health;

        // Available to change fill color to show various damage levels //
        /*fill.color = gradient.Evaluate(slider.normalizedValue);*/
    }
}
