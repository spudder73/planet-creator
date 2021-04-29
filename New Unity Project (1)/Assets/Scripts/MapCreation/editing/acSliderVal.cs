using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class acSliderVal : MonoBehaviour
{
    public Slider acSlider;
    float valC;

    public float getAcSliderVal()
    {
        valC = acSlider.value;
        return valC;
    }
}
