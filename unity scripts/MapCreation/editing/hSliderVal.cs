using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hSliderVal : MonoBehaviour
{

    public Slider hSlider;
    float valH;

    public float getHSliderVal()
    {
        valH = hSlider.value;
        return valH;
    }

}
