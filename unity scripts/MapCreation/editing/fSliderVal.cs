using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fSliderVal : MonoBehaviour
{

    public Slider fSlider;
    float valF;
    int valF2;

    public int getFSliderVal()
    {
        valF = fSlider.value;
        valF2 = (int)valF;
        return valF2;
    }

}
