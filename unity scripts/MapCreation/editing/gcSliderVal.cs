using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gcSliderVal : MonoBehaviour
{
    public Slider gcSlider;
    float valC;

    public float getGcSliderVal()
    {
        valC = gcSlider.value;
        return valC;
    }
}
