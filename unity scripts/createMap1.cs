using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createMap1 : MonoBehaviour
{

    public float[,,] addPoints(int length, int dist, int[,] startingPos , AnimationCurve heightCurve)
    {

        float[,,] map1 = new float[length * 4, length * 3, 2];

        for (int i = 0; i < 6; i++)
        {
            int x = startingPos[i, 0];
            int y = startingPos[i, 1];

            for (int ii = x; ii < x + length; ii += dist)
            {
                for (int iii = y; iii < y + length; iii += dist)
                {
                    map1[ii, iii, 0] = UnityEngine.Random.Range(-1f, 1.0f);
                    map1[ii, iii, 1] = UnityEngine.Random.Range(-1f, 1.0f);
                }
            }
        }

        return map1;

    }
}
