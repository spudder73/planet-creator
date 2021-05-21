using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gSliderVal : MonoBehaviour
{

    public Slider gSlider;
    float valG;
    int valG2;

    public int getGSliderVal()
    {
        valG = gSlider.value;
        valG2 = (int)valG;
        return valG2;
    }

}
