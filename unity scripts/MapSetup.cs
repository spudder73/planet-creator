using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSetup : MonoBehaviour
{
    
    

    //create map
    private float[,,] randVectorMap;






    public float[,,] setUpGrid(int gridSize, int frequency, int distance)
    {
        //assign variables to the editable value in noise Editor using public get methods
        //set get as the noiseEditor class

        

        //set size of the map (height,length,vector)
        randVectorMap = new float[(int)((gridSize - frequency - 1) / 4f) + 2, (int)((gridSize - frequency - 1) / 4f) + 2, 2];

        //for loop to add random vectors to the 4 corners of the map
        for (int i = 0; i < 2; i++)
        {
            //set i equal to the end of the map
            i = i * ((int)((gridSize - frequency - 1) / 4f) + 2 - 1);

            //nested for loop to add both the x and the y coordinates of the vector
            for (int ii = 0; ii < 2; ii++)
            {

                randVectorMap[0, i, ii] = UnityEngine.Random.Range(-1f, 1.0f);


                randVectorMap[(int)((gridSize - frequency - 1) / 4f) + 2 - 1, i, ii] = UnityEngine.Random.Range(-1f, 1.0f);
            }


        }


        //assign future counters with distance

        int distanceX = distance;
        int distanceY = distance;
        //for loop to add random vectors on the lines y=0 and x=0
        for (int i = 0; i < frequency; i++)
        {
            //nested for loop to add both the x and the y coordinates of the vector
            for (int ii = 0; ii < 2; ii++)
            {
                //x axis
                
                randVectorMap[0, distanceX + 1, ii] = UnityEngine.Random.Range(-1f, 1.0f);
                //y axis
                randVectorMap[distanceY + 1, 0, ii] = UnityEngine.Random.Range(-1f, 1.0f);
            }
            //increment counter
            distanceX = distanceX + 1 + distance;
            distanceY = distanceY + 1 + distance;
        }

        //resetting the y counter
        distanceY = distance;

        //final for loop to add the remaining random vectors

        //first for loop for incrementing the y counter
        for (int i = 0; i < frequency; i++)
        {
            //resetting the x counter
            distanceX = distance;
            //nested for loop for incrementing the x counter
            for (int ii = 0; ii < frequency; ii++)
            {
                //nested for loop to add both the x and the y coordinates of the vector
                for (int iii = 0; iii < 2; iii++)
                {
                    randVectorMap[distanceY + 1, distanceX + 1, iii] = UnityEngine.Random.Range(-1f, 1.0f);

                }
                //increment x counter
                distanceX = distanceX + distance + 1;
            }

            //increment y counter
            distanceY = distanceY + distance + 1;
        }


        return randVectorMap;

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
