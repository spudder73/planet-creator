using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotProduct : MonoBehaviour
{
    //initialize variables
    noiseEditor get;
    AssignMap get2;
    

    float[,,,] assignedVectMap;
    float[,,,] distanceVectMap;
    float[,,] dotMap;


    float[] direction1;
    float[] direction2;
    float[] direction3;
    float[] direction4;
    float[] gradient1;
    float[] gradient2;
    float[] gradient3;
    float[] gradient4;
    

    //function to combine the direction and random vectors via dot product
    public float[,,] dotProduct(int gridSize, int frequency)
    {

        
        //set getter variables
        get = gameObject.GetComponent<noiseEditor>();
        get2 = gameObject.GetComponent<AssignMap>();

        //assign variables to the values in noise Editor class using public get methods
        gridSize = get.getGridSize();
        frequency = get.getFrequency();

        //get required maps
        assignedVectMap = get2.getAssignedVectMap();
        distanceVectMap = get2.getDistanceVectMap();

        //initialize map size
        dotMap = new float[(int)((gridSize - frequency - 1) / 4f) + 2, (int)((gridSize - frequency - 1) / 4f) + 2, 4];


        //initialize the vector placeholders
        gradient1 = new float[2];
        gradient2 = new float[2];
        gradient3 = new float[2];
        gradient4 = new float[2];
        direction1 = new float[2];
        direction2 = new float[2];
        direction3 = new float[2];
        direction4 = new float[2];

        

        //for loop to increment y counter
        for (int i = 0; i < (int)((gridSize - frequency - 1) / 4f) + 2; i++)
        {
            //for loop to increment x counter
            for (int ii = 0; ii < (int)((gridSize - frequency - 1) / 4f) + 2; ii++)
            {

                //for loop to add both x and y coordinates
                for (int iii = 0; iii < 2; iii++)
                {

                    //get all direction and random vectors for the given point

                    //top left
                    gradient1[iii] = assignedVectMap[i, ii, 0, iii];

                    direction1[iii] = distanceVectMap[i, ii, 0, iii];

                    //top right
                    gradient2[iii] = assignedVectMap[i, ii, 1, iii];

                    direction2[iii] = distanceVectMap[i, ii, 1, iii];

                    //bottom left
                    gradient3[iii] = assignedVectMap[i, ii, 2, iii];

                    direction3[iii] = distanceVectMap[i, ii, 2, iii];

                    //bottom right
                    gradient4[iii] = assignedVectMap[i, ii, 3, iii];

                    direction4[iii] = distanceVectMap[i, ii, 3, iii];


                }



                //do the dot product on each pair of direction and random vectors for each corner surrounding the point
                //add them to the new map
                dotMap[i, ii, 0] = (gradient1[0] * direction1[0] + gradient1[1] * direction1[1]);
                dotMap[i, ii, 1] = (gradient2[0] * direction2[0] + gradient2[1] * direction2[1]);
                dotMap[i, ii, 2] = (gradient3[0] * direction3[0] + gradient3[1] * direction3[1]);
                dotMap[i, ii, 3] = (gradient4[0] * direction4[0] + gradient4[1] * direction4[1]);
            }
        }
        return dotMap;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
