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
                string str = "";
                for (int iii = y; iii < y + length; iii++)
                {

                    int xRem = ii % dist;
                    int xRem2 = dist - xRem;
                    int yRem = iii % dist;

                    int yRem2 = dist - yRem;


                    if (ii + xRem2 > length * 4 - 1)
                    {
                        xRem2 -= length * 4;
                    }

                    if (iii + yRem2 > length * 3 -1)
                    {
                        yRem2 -= length*3;
                    }

                    if (iii + yRem2 > length * 2 - 1 && ii + xRem2 < length)
                    {
                        yRem2 -= length;
                    }

                    if (iii + yRem2 > length * 2 - 1 && ii + xRem2 > length*2)
                    {
                        yRem2 -= length;
                    }

                    if (ii + xRem2 > length * 2 - 1 && iii + yRem2 < length)//had -1 for <
                    {
                        xRem2 -= length;
                    }

                    if (ii + xRem2 > length * 2 - 1 && iii + yRem2 > length * 2 - 1)
                    {
                        xRem2 -= length;
                    }


                    //Debug.Log(map1[ii - xRem, iii + yRem2, 0]);


                    //assign distance to top left
                    map3[ii, iii, 0, 0] = map1[ii + xRem2, iii + yRem2, 0];
                    map3[ii, iii, 0, 1] = map1[ii + xRem2, iii + yRem2, 1];

                    //assign distance to top right
                    map3[ii, iii, 1, 0] = map1[ii - xRem, iii + yRem2, 0];
                    map3[ii, iii, 1, 1] = map1[ii - xRem, iii + yRem2, 1];

                    //assign distance to bottom left
                    map3[ii, iii, 2, 0] = map1[ii + xRem2, iii - yRem, 0];
                    map3[ii, iii, 2, 1] = map1[ii + xRem2, iii - yRem, 1];

                    //assign distance to bottom right
                    map3[ii, iii, 3, 0] = map1[ii - xRem, iii - yRem, 0];
                    map3[ii, iii, 3, 1] = map1[ii - xRem, iii - yRem, 1];

                    if (ii + xRem2 > length * 4 - 1)
                    {
                        xRem2 -= length * 4;
                    }


                    if (ii > length * 2 - dist-1 && ii < length * 2 && iii > length * 2 -1- dist && iii < length * 2) //had -1
                    {
                        map3[ii, iii, 0, 0] = map1[length , length * 2 ,0];
                        map3[ii, iii, 0, 1] = map1[length, length * 2 ,1];


                        xRem = ii % dist;
                        xRem2 = dist - xRem;
                        yRem = iii % dist;

                        yRem2 = dist - yRem;
                        //assign distance to bottom left
                        map3[ii, iii, 2, 0] = map1[ii + xRem2, iii - yRem, 0];
                        map3[ii, iii, 2, 1] = map1[ii + xRem2, iii - yRem, 1];
                    }

                    if (ii > length*2-1 && ii < length*2+dist && iii > length*2-dist-1 && iii < length * 2 )
                    {
                        //assign distance to top right
                        map3[ii, iii, 1, 0] = map1[length, length * 2, 0];
                        map3[ii, iii, 1, 1] = map1[length, length * 2, 1];
                    }

                    if (ii > length * 2 - 1 - dist && ii < length * 2 && iii > length - dist - 1 && iii < length )
                    {

                        //assign distance to top right
                        map3[ii, iii, 2, 0] = map1[length, length-dist, 0];
                        map3[ii, iii, 2, 1] = map1[length, length-dist, 1];
                    }

                    if (ii > length - 1 - dist && ii < length  && iii > length*2 - dist - 1 && iii < length*2)
                    {
                        //assign distance to top right
                        map3[ii, iii, 1, 0] = map1[length-dist, length, 0];
                        map3[ii, iii, 1, 1] = map1[length-dist, length, 1];
                    }

                    if (iii > length * 2 - 1 && ii > length * 2 - 1 - dist && ii < length * 2)
                    {
                        int pos = (iii - yRem - length * 2 );
                        map3[ii, iii, 2, 0] = map1[length * 2 + pos, length, 0];
                        map3[ii, iii, 2, 1] = map1[length * 2 + pos, length, 1];

                        map3[ii, iii, 0, 0] = map1[length * 2 + (pos + dist), length , 0];
                        map3[ii, iii, 0, 1] = map1[length * 2 + (pos + dist), length , 1];
                    }
                    //Debug.Log(xRem2);
                }
                
            }
        }
        /*

        for (int ii = 0; ii < length * 4; ii++)
        {
            string str = "";
            for (int iii = 0; iii < length * 3; iii++)
            {
                if (map3[ii, iii, 0, 0] != 0)
                {
                    str += ((map3[ii, iii, 0, 0]).ToString()).Substring(0, 4) + ",";
                }
                else
                {
                    str += (map3[ii, iii, 0, 0]) + ",";
                }


            }
            Debug.Log(str);
        }

        
        for (int ii = 0; ii < length * 4; ii++)
        {
            string str = "";
            for (int iii = 0; iii < length * 3; iii++)
            {
                string str2 = "";
                for (int iv = 0; iv < 4; iv++)
                {
                    if (map3[ii, iii, iv, 0] != 0)
                    {
                        str2 += ((map3[ii, iii, iv, 0]).ToString()).Substring(0, 4) + ",";
                    }
                    else
                    {
                        str2 += (map3[ii, iii, iv, 0]) + ",";
                    }
                }
                str2 += ":   ";
                str += str2;
            }
            Debug.Log(str);
        }
        */
        return map3;
    }
}
