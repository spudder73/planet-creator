using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class createMap5 : MonoBehaviour
{
    public float[,] lerp(int length, int dist, int octave, bool mode, float height, float[,,,] map2, float[,,] map4, int[,] startingPos)
    {

        float[,] map5 = new float[length * 4, length * 3];


        float fade(float num)
        {
            float newNum = 6 * Mathf.Pow(num, 5) - 15 * Mathf.Pow(num, 4) + 10 * Mathf.Pow(num, 3);

            return newNum;
        }


        for (int i = 0; i < 6; i++)
        {
            int x = startingPos[i, 0];
            int y = startingPos[i, 1];

            for (int ii = x; ii < x + length; ii++)
            {
                for (int iii = y; iii < y + length; iii++)
                {

                    //linearly interpolate between the top pair
                    float top = map4[ii, iii, 0] + fade(map2[ii, iii, 0, 0]) * (map4[ii, iii, 1] - map4[ii, iii, 0]);

                    //linearly interpolate between the bottom pair
                    float bottom = map4[ii, iii, 2] + fade(map2[ii, iii, 0, 0]) * (map4[ii, iii, 3] - map4[ii, iii, 2]);

                    //linearly interpolate between the two interpolations we just got
                    float total = top + fade(map2[ii, iii, 0, 1]) * (bottom - top);


                    //add to the map
                    if (mode)
                    {
                        map5[ii, iii] = 4 * (((total)));
                    }
                    else
                    {
                        map5[ii, iii] = (1f - (4f *  Mathf.Abs(total)));
                    }

                }
            }
        }


        return map5;
    }

}
