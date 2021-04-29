using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sSliderVal : MonoBehaviour
{

    public Slider sSlider;
    float valS;

    public float getSSliderVal()
    {
        valS = sSlider.value;
        return valS;
    }

}