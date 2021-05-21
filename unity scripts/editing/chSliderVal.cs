using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chSliderVal : MonoBehaviour
{
    public Slider chSlider;
    float valCh;

    public float getChSliderVal()
    {
        valCh = chSlider.value;
        return valCh;
    }
}
