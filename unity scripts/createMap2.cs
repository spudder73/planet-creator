using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createMap2 : MonoBehaviour
{
    public float[,,,] setDistances(int length, int dist, int[,] startingPos)
    {

        float[,,,] map2 = new float[length * 4, length * 3, 4, 2];


        for (int i = 0; i < 6; i++)
        {
            int x = startingPos[i, 0];
            int y = startingPos[i, 1];

            for (int ii = x; ii < x + length; ii++)
            {
                int xRem = ii % dist;

                int xRem2 = dist - xRem;


                for (int iii = y; iii < y + length; iii++)
                {

                    int yRem = iii % dist;

                    int yRem2 = dist - yRem;

                    //assign distance to top left
                    map2[ii, iii, 0, 0] = xRem2 / ((float)dist);
                    map2[ii, iii, 0, 1] = yRem2 / ((float)dist);

                    //assign distance to top right
                    map2[ii, iii, 1, 0] = -xRem / ((float)dist);
                    map2[ii, iii, 1, 1] = yRem2 / ((float)dist);

                    //assign distance to bottom left
                    map2[ii, iii, 2, 0] = xRem2 / ((float)dist);
                    map2[ii, iii, 2, 1] = -yRem / ((float)dist);

                    //assign distance to bottom right
                    map2[ii, iii, 3, 0] = -xRem / ((float)dist);
                    map2[ii, iii, 3, 1] = -yRem / ((float)dist);
                }
            }
        }
        /*
        for (int ii = 0; ii < length * 4; ii++)
        {
            string str = "";
            for (int iii = 0; iii < length * 3; iii++)
            {
                if (map2[ii, iii, 0, 0] != 0)
                {
                    str += ((map2[ii, iii, 0, 0]).ToString()).Substring(0, 4) + ",";
                }
                else
                {
                    str += (map2[ii, iii, 0, 0]) + ",";
                }


            }
            Debug.Log(str);
        }
        */
        return map2;
    }
}
