using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createMap3 : MonoBehaviour
{
    public float[,,,] getRandVectors(int length, int dist, float[,,] map1, int[,] startingPos)
    {
        float[,,,] map3 = new float[length * 4, length * 3, 4, 2];
        
        for (int i = 0; i < 6; i++)
        {
            int x = startingPos[i, 0];
            int y = startingPos[i, 1];

            for (int ii = x; ii < x + length; ii++)
            {
                for (int iii = y; iii < y + length; iii++)
                {
                    int xRem = ii % dist;
                    int yRem = iii % dist;
                    int xRem2 = dist - xRem + 1;
                    int yRem2 = dist - yRem + 1;

                    if (ii+xRem2 > length * 4 - 1)
                    {
                        xRem2 -= length * 4 - 1;
                    }

                    if (iii + yRem2 > length * 3 -1)
                    {
                        yRem2 -= length * 3 - 1;
                    }

                    if (ii + xRem2 > length * 2 - 1 && iii < length + 1)
                    {
                        xRem2 -= length - 1;
                    }

                    if (ii + xRem2 > length * 2 - 1 && iii > length * 2 + 1)
                    {
                        xRem2 -= length - 1;
                    }


                    //assign distance to top left
                    map3[ii, iii, 0, 0] = map1[ii - xRem , iii + yRem2, 0];
                    map3[ii, iii, 0, 1] = map1[ii - xRem , iii + yRem2, 1];

                    //assign distance to top right
                    map3[ii, iii, 1, 0] = map1[ii + xRem2, iii + yRem2, 0];
                    map3[ii, iii, 1, 1] = map1[ii + xRem2, iii + yRem2, 1];
                   
                    //assign distance to bottom left
                    map3[ii, iii, 2, 0] = map1[ii - xRem , iii - yRem, 0];
                    map3[ii, iii, 2, 1] = map1[ii - xRem , iii - yRem, 1];

                    //assign distance to bottom right
                    map3[ii, iii, 3, 0] = map1[ii + xRem2, iii - yRem, 0];
                    map3[ii, iii, 3, 1] = map1[ii + xRem2, iii - yRem, 1];
                }
            }
        }

        return map3;
    }
}
