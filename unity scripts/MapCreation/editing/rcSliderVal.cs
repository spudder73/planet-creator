using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rcSliderVal : MonoBehaviour
{
    public Slider rcSlider;
    float valC;

    public float getRcSliderVal()
    {
        valC = rcSlider.value;
        return valC;
    }
}
