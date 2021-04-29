using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cdModeVal : MonoBehaviour
{
    public TMPro.TMP_Dropdown changeColour;
    float valM;
    int valM2;

    public int getColour()
    {
        valM = changeColour.value;
        valM2 = (int)valM;
        return valM2;
    }
}

