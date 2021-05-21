using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ddModeVal : MonoBehaviour
{
    public TMPro.TMP_Dropdown changeMode;
    float valM;
    int valM2;

    public int getMode()
    {
        valM = changeMode.value;
        valM2 = (int)valM;
        return valM2;
    }
}
