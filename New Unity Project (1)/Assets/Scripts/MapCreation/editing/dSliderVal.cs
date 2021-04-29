using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dSliderVal : MonoBehaviour
{

    public Slider dSlider;
    float valD;

    public float getDSliderVal()
    {
        valD = dSlider.value;
        return valD;
    }

}

