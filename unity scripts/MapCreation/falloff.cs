using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falloff : MonoBehaviour
{
    float[,] falloffMap;

    public float[,] createFalloffMap(int gridSize)
    {
        falloffMap = new float[gridSize, gridSize];

        for (int i = 0; i < gridSize; i++)
        {
            for (int ii = 0; ii < gridSize; ii++)
            {
                float x = i / (float)gridSize * 2 - 1;
                float y = ii / (float)gridSize * 2 - 1;

                float max = Mathf.Max(Mathf.Abs(x), Mathf.Abs(y));
                falloffMap[i, ii] = eval(max);
            }
        }

        return falloffMap;
    }

    float eval(float value)
    {
        float a = 2f;
        float b = 4f;

        return Mathf.Pow(value, a) / (Mathf.Pow(value, a) + Mathf.Pow(b - b * value, a));
    }
}
