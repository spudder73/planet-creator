using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createMap4 : MonoBehaviour
{

    public float[,,] dotProduct(int length, int dist, float[,,,] map2, float[,,,] map3, int[,] startingPos)
    {
        float[,,] map4 = new float[length * 4, length * 3, 4];


        float[] gradient = new float[2];
        float[] direction = new float[2];

        for (int i = 0; i < 6; i++)
        {
            int x = startingPos[i, 0];
            int y = startingPos[i, 1];

            for (int ii = x; ii < x + length; ii++)
            {
                for (int iii = y; iii < y + length; iii++)
                {
                    for (int iv = 0; iv < 4; iv++)
                    {
                        for (int v = 0; v < 2; v++)
                        {
                            gradient[v] = map3[ii, iii, iv, v];
                            
                            direction[v] = map2[ii, iii, iv, v];
                        }

                        map4[ii, iii, iv] = (gradient[0] * direction[0] + gradient[1] * direction[1]);
                    }
                }
            }
        }

        return map4;
    }
}
