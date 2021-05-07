using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createMap1 : MonoBehaviour
{

    public float[,,] addPoints(int length, int dist, int[,] startingPos)
    {

        float[,,] map1 = new float[length * 4, length * 3, 2];
        Debug.Log(length);

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

        for (int ii = 0; ii < length*4; ii ++)
        {
            string str = "";
            for (int iii = 0; iii < length*3; iii ++)
            {
                if (map1[ii, iii, 0] != 0)
                {
                    str += ((map1[ii, iii, 0]).ToString()).Substring(0, 4) + ",";
                }
                else
                {
                    str += (map1[ii, iii, 0]) + ",";
                }
                

            }
            Debug.Log(str);
        }

        return map1;

    }
}
