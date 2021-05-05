using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Lerp : MonoBehaviour
{

    //initialize variables
    newAssignMap get2;
    float[,,,] distanceVectMap;
    float[,,] dotMap;
    float[,] noiseMap;

    
    //function to linearly interpolate between the 4 vectors we just got for a given point
    public float[,] lerp(int gridSize, int frequency, int octave,  int mode, float height)
    {

        //set getter
        get2 = gameObject.GetComponent<newAssignMap>();

        //get variables from other class using getter
        distanceVectMap = get2.getDistanceVectMap();
        dotMap = get2.getDotMap();
        
        //set map size
        noiseMap = new float[((int)((gridSize - frequency - 1) / 4f) + 2), ((int)((gridSize - frequency - 1) / 4f) + 2)];

        //fade function, to give a smoother gradient of noise
        float fade(float num)
        {
            //create curve and find new position of the input on that curve
            float newNum = 6 * Mathf.Pow(num, 5) - 15 * Mathf.Pow(num, 4) + 10 * Mathf.Pow(num, 3);

            return newNum;
        }

        //Debug.Log(octave);
        //for loop to increment y counter
        for (int i = 0; i < ((int)((gridSize - frequency - 1) / 4f) + 2); i++)
        {
            
            //for loop to increment x counter
            for (int ii = 0; ii < (int)((gridSize - frequency - 1) / 4f) + 2; ii++)
            {
                //linearly interpolate between the top pair
                float top = dotMap[i, ii, 0] + fade(distanceVectMap[i, ii, 0, 0]) * (dotMap[i, ii, 1] - dotMap[i, ii, 0]);

                //linearly interpolate between the bottom pair
                float bottom = dotMap[i, ii, 2] + fade(distanceVectMap[i, ii, 0, 0]) * (dotMap[i, ii, 3] - dotMap[i, ii, 2]);

                //linearly interpolate between the two interpolations we just got
                float total = top + fade(distanceVectMap[i, ii, 0, 1]) * (bottom - top);


                
                //add to the map
                if (mode == 1)
                {
                    noiseMap[i, ii] = 4f * ((Mathf.Abs(total)));
                }
                else
                {
                    noiseMap[i, ii] = (1f-(4f * Mathf.Abs(total)));
                }
                
                
                
                
                
                        

            }
        }

        return noiseMap;
    }
    


    // Update is called once per frame
    void Update()
    {
        
    }
}
