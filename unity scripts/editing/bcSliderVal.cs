using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bcSliderVal : MonoBehaviour
{
    public Slider bcSlider;
    float valC;

    public float getBcSliderVal()
    {
        valC = bcSlider.value;
        return valC;
    }
}
