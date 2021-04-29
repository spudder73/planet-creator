using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class oSliderVal : MonoBehaviour
{

    public Slider oSlider;
    float valO;
    int valO2;

    public int getOSliderVal()
    {
        valO = oSlider.value;
        valO2 = (int)valO;
        return valO2;
    }

}
