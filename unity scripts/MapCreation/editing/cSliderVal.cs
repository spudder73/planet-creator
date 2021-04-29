using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cSliderVal : MonoBehaviour
{
    public Slider cSlider;
    float valC;
    int valC2;

    public int getCSliderVal()
    {
        valC = cSlider.value;
        valC2 = (int)valC;
        return valC2;
    }
}
