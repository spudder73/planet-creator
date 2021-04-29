using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assignRandomV : MonoBehaviour
{

    float[,,] randVectorMap;
    
    AssignMap get2;

    private float[,,,] assignedVectMap;
    
    

    //function to assign each point its 4 random vectors that surround it
    public float[,,,] assignRandomVectors(int gridSize, int frequency, int distance1)
    {
        //assign variables to the editable value in noise Editor using public get methods
        //set get as the noiseEditor class
        
        
        get2 = gameObject.GetComponent<AssignMap>();
        randVectorMap = get2.getRandVectMap();

        assignedVectMap = new float[(int)((gridSize - frequency - 1) / 4f) + 2, (int)((gridSize - frequency - 1) / 4f) + 2, 4, 2];



        //initialize vectors (top left, top right, bottom left, bottom right)
        float[] vector1 = new float[2];
        float[] vector2 = new float[2];
        float[] vector3 = new float[2];
        float[] vector4 = new float[2];

        distance1 += 1;

        //initialise the vector map size
        //(height,width,(top left, top right, bottom left, bottom right) vector directions, (y and x) coordinates)


        //for loop to add both x and y coordinates
        for (int iii = 0; iii < 2; iii++)
        {
            //for loop to increment y counter
            for (int i = 0; i < (int)((gridSize - frequency - 1) / 4f) + 2; i++)
            {
                //set y to the top left vector that surrounds the point
                int rem = i % distance1;
                int y = i - rem;

                //for loop to increment x counter
                for (int ii = 0; ii < (int)((gridSize - frequency - 1) / 4f) + 2; ii++)
                {

                    //checks if the random vectors on the x axis need to be changed if not then neither does y
                    if (ii % distance1 == 0)
                    {
                        //set vector1 as the top left vector
                        vector1[iii] = randVectorMap[y, ii, iii];

                        //checks if there is another top right vector 
                        if (ii + distance1 < (int)((gridSize - frequency - 1) / 4f) + 2)
                        {
                            //if so it assigns it to vector2
                            vector2[iii] = randVectorMap[y, ii + distance1, iii];
                        }

                        else
                        {
                            //else it just assigns the top left to vector2
                            vector2[iii] = randVectorMap[y, ii, iii];
                        }


                        //checks if there is another bottom left vector 
                        if (y + distance1 < (int)((gridSize - frequency - 1) / 4f) + 2)
                        {
                            //if so it assigns it to vector3
                            vector3[iii] = randVectorMap[y + distance1, ii, iii];
                        }

                        else
                        {
                            //else it just assigns the top left to vector3
                            vector3[iii] = randVectorMap[y, ii, iii];
                        }


                        //4 checks whether there is another bottom right vector and which to replace it with if not


                        if (y + distance1 > (int)((gridSize - frequency - 1) / 4f) + 2 & ii + distance1 < (int)((gridSize - frequency - 1) / 4f) + 2)
                        {
                            //assigns vector4 to vector2
                            vector4[iii] = randVectorMap[y, ii + distance1, iii];
                        }

                        if (ii + distance1 > (int)((gridSize - frequency - 1) / 4f) + 2 & y + distance1 < (int)((gridSize - frequency - 1) / 4f) + 2)
                        {
                            //assigns vector4 to vector3
                            vector4[iii] = randVectorMap[y + distance1, ii, iii];
                        }

                        if (y + distance1 > (int)((gridSize - frequency - 1) / 4f) + 2 & ii + distance1 > (int)((gridSize - frequency - 1) / 4f) + 2)
                        {
                            //assigns vector4 to vector1
                            vector4[iii] = randVectorMap[y, ii, iii];
                        }

                        //if there is another bottom right vector
                        if (y + distance1 < (int)((gridSize - frequency - 1) / 4f) + 2 & ii + distance1 < (int)((gridSize - frequency - 1) / 4f) + 2)
                        {
                            //assigns vector4 to bottom right
                            vector4[iii] = randVectorMap[y + distance1, ii + distance1, iii];
                        }
                    }
                    //assigns each point on the map 4 vectors for each of the 4 corners surrounding it
                    assignedVectMap[i, ii, 0, iii] = vector1[iii];
                    assignedVectMap[i, ii, 1, iii] = vector2[iii];
                    assignedVectMap[i, ii, 2, iii] = vector3[iii];
                    assignedVectMap[i, ii, 3, iii] = vector4[iii];


                }
            }
        }

        return assignedVectMap;

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
