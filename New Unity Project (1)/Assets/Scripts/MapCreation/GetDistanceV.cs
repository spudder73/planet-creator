using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDistanceV : MonoBehaviour
{
    
    

    private float[,,,] distanceVectMap;
    
    

    //function to create map of distance vectors to each random vector surrounding the given point
    public float[,,,] getDistanceVectors(int gridSize, int frequency, int distance)
    {
        //assign variables to the editable value in noise Editor using public get methods
        //set get as the noiseEditor class

        
        
        //initialise the vector map size
        //(height,width,(top left, top right, bottom left, bottom right) vector directions, (y and x) coordinates)
        distanceVectMap = new float[(int)((gridSize - frequency - 1) / 4f) + 2, (int)((gridSize - frequency - 1) / 4f) + 2, 4, 2];

        //create counters
        float xCounter = 0;
        float yCounter = 0;


        
        //for loop to increment y counter
        for (int i = 0; i < (int)((gridSize - frequency - 1) / 4f) + 2; i++)
        {

            //reset x counter
            xCounter = 0;

            //nested for loop to increment x counter
            for (int ii = 0; ii < (int)((gridSize - frequency - 1) / 4f) + 2; ii++)

            {
                //resets the y counter when it reaches a new random vector
                if (yCounter % (distance + 1) == 0)
                {
                    yCounter = 0;
                }

                //resets the x counter when it reaches a new random vector
                if (xCounter % (distance + 1) == 0)
                {
                    xCounter = 0;
                }


                //finds the percentage distance vector of the point to the random vectors for x and y

                //positive for the top left and bottom left random vectors
                float yVal;
                yVal = yCounter / (distance + 1);
                float xVal;
                xVal = (xCounter / (distance + 1));


                //negative for the top right and bottom right random vectors
                float negXVal = (-(((distance + 1) - xCounter)) / (distance + 1));
                float negYVal = (-(((distance + 1) - yCounter)) / (distance + 1));

                //assign distance to top left
                distanceVectMap[i, ii, 0, 1] = yVal;
                distanceVectMap[i, ii, 0, 0] = xVal;

                //assign distance to top right
                distanceVectMap[i, ii, 1, 1] = yVal;
                distanceVectMap[i, ii, 1, 0] = negXVal;

                //assign distance to bottom left
                distanceVectMap[i, ii, 2, 1] = negYVal;
                distanceVectMap[i, ii, 2, 0] = xVal;

                //assign distance to bottom right
                distanceVectMap[i, ii, 3, 1] = negYVal;
                distanceVectMap[i, ii, 3, 0] = negXVal;

                //increment x counter
                xCounter = xCounter + 1;
            }

            //increment y counter
            yCounter = yCounter + 1;

        }
        
        return distanceVectMap;

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
