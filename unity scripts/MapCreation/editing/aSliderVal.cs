using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class aSliderVal : MonoBehaviour
{
    public Slider aSlider;
    float valA;
    int valA2;

    public int getASliderVal()
    {
        valA = aSlider.value;
        valA2 = (int)valA;
        return valA2;
    }
}
