using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class backup : MonoBehaviour
{
    //get gridSize and Frequency
    //initialize the map size



    //create the maps

    //initial random vectors
    private float[,,] randVectorMap;
    //distances to these vectors
    private float[,,,] distanceVectMap;
    //which of these vectors border the point
    private float[,,,] assignedVectMap;
    //dot product between these vectors
    private float[,,] dotMap;
    //linearly interpolated the created values
    //make the final noise map public
    public float[,] noiseMap;







    // Start is called before the first frame update
    void Start()
    {
        //assign variables to the editable value in noise Editor using public get methods
        //set get as the noiseEditor class
        int gridSize;
        int frequency;
        int distance;

        gridSize = 1000;
        frequency = 5;
        distance = (Convert.ToInt32(Mathf.Floor((gridSize - 2 - (frequency - 1)) / frequency)));

        //function to create map of random vectors to base the noise on
        void setUpGrid()
        {
            //set size of the map (height,length,vector)
            randVectorMap = new float[gridSize, gridSize, 2];

            //for loop to add random vectors to the 4 corners of the map
            for (int i = 0; i < 2; i++)
            {
                //set i equal to the end of the map
                i = i * (gridSize - 1);

                //nested for loop to add both the x and the y coordinates of the vector
                for (int ii = 0; ii < 2; ii++)
                {

                    randVectorMap[0, i, ii] = UnityEngine.Random.Range(-1f, 1.0f);


                    randVectorMap[gridSize - 1, i, ii] = UnityEngine.Random.Range(-1f, 1.0f);
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




        }

        //function to create map of distance vectors to each random vector surrounding the given point
        void getDistanceVectors()
        {

            float xCounter = 0;
            float yCounter = 0;

            //initialise the vector map size
            //(height,width,(top left, top right, bottom left, bottom right) vector directions, (y and x) coordinates)
            distanceVectMap = new float[gridSize, gridSize, 4, 2];

            //for loop to increment y counter
            for (int i = 0; i < gridSize; i++)
            {
                //reset x counter
                xCounter = 0;

                //nested for loop to increment x counter
                for (int ii = 0; ii < gridSize; ii++)

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



        }


        //function to assign each point its 4 random vectors that surround it
        void assignRandomVectors()
        {
            //initialize vectors (top left, top right, bottom left, bottom right)
            float[] vector1 = new float[2];
            float[] vector2 = new float[2];
            float[] vector3 = new float[2];
            float[] vector4 = new float[2];
            int distance1 = Convert.ToInt32(Mathf.Floor((gridSize - 1 - (frequency)) / frequency));
            distance1 += 1;
            //initialise the vector map size
            //(height,width,(top left, top right, bottom left, bottom right) vector directions, (y and x) coordinates)
            assignedVectMap = new float[gridSize, gridSize, 4, 2];

            //for loop to add both x and y coordinates
            for (int iii = 0; iii < 2; iii++)
            {
                //for loop to increment y counter
                for (int i = 0; i < gridSize; i++)
                {
                    //set y to the top left vector that surrounds the point
                    int rem = i % distance1;
                    int y = i - rem;

                    //for loop to increment x counter
                    for (int ii = 0; ii < gridSize; ii++)
                    {

                        //checks if the random vectors on the x axis need to be changed if not then neither does y
                        if (ii % distance1 == 0)
                        {
                            //set vector1 as the top left vector
                            vector1[iii] = randVectorMap[y, ii, iii];

                            //checks if there is another top right vector 
                            if (ii + distance1 < gridSize)
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
                            if (y + distance1 < gridSize)
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


                            if (y + distance1 > gridSize & ii + distance1 < gridSize)
                            {
                                //assigns vector4 to vector2
                                vector4[iii] = randVectorMap[y, ii + distance1, iii];
                            }

                            if (ii + distance1 > gridSize & y + distance1 < gridSize)
                            {
                                //assigns vector4 to vector3
                                vector4[iii] = randVectorMap[y + distance1, ii, iii];
                            }

                            if (y + distance1 > gridSize & ii + distance1 > gridSize)
                            {
                                //assigns vector4 to vector1
                                vector4[iii] = randVectorMap[y, ii, iii];
                            }

                            //if there is another bottom right vector
                            if (y + distance1 < gridSize & ii + distance1 < gridSize)
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


        }

        //function to combine the direction and random vectors via dot product
        void dotProduct()
        {
            //initialize the vector placeholders
            float[] direction1;
            float[] direction2;
            float[] direction3;
            float[] direction4;
            float[] gradient1;
            float[] gradient2;
            float[] gradient3;
            float[] gradient4;

            gradient1 = new float[2];
            gradient2 = new float[2];
            gradient3 = new float[2];
            gradient4 = new float[2];
            direction1 = new float[2];
            direction2 = new float[2];
            direction3 = new float[2];
            direction4 = new float[2];

            //initialize map size
            dotMap = new float[gridSize, gridSize, 4];

            //for loop to increment y counter
            for (int i = 0; i < gridSize - frequency; i++)
            {
                //for loop to increment x counter
                for (int ii = 0; ii < gridSize - frequency; ii++)
                {

                    //for loop to add both x and y coordinates
                    for (int iii = 0; iii < 2; iii++)
                    {

                        //get all direction and random vectors for the given point

                        gradient1[iii] = assignedVectMap[i, ii, 0, iii];

                        direction1[iii] = distanceVectMap[i, ii, 0, iii];

                        gradient2[iii] = assignedVectMap[i, ii, 1, iii];

                        direction2[iii] = distanceVectMap[i, ii, 1, iii];

                        gradient3[iii] = assignedVectMap[i, ii, 2, iii];

                        direction3[iii] = distanceVectMap[i, ii, 2, iii];

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

        }

        //function to linearly interpolate between the 4 vectors we just got for a given point
        void lerp()
        {
            //fade function, to give a smoother gradient of noise
            float fade(float num)
            {
                float newNum = 6 * Mathf.Pow(num, 5) - 15 * Mathf.Pow(num, 4) + 10 * Mathf.Pow(num, 3);
                return newNum;
            }

            //initialize final noise map
            noiseMap = new float[(gridSize - frequency - 1), (gridSize - frequency - 1)];

            //for loop to increment y counter
            for (int i = 0; i < gridSize - frequency - 1; i++)
            {
                //for loop to increment x counter
                for (int ii = 0; ii < gridSize - frequency - 1; ii++)
                {
                    //linearly interpolate between the top pair
                    float top = dotMap[i, ii, 0] + fade(distanceVectMap[i, ii, 0, 0]) * (dotMap[i, ii, 1] - dotMap[i, ii, 0]);

                    //linearly interpolate between the bottom pair
                    float bottom = dotMap[i, ii, 2] + fade(distanceVectMap[i, ii, 0, 0]) * (dotMap[i, ii, 3] - dotMap[i, ii, 2]);

                    //linearly interpolate between the two interpolations we just got
                    float total = top + fade(distanceVectMap[i, ii, 0, 1]) * (bottom - top);

                    //add to the map
                    noiseMap[i, ii] = (total) + 0.5f;

                }
            }
        }


        //call the functions
        setUpGrid();
        getDistanceVectors();
        assignRandomVectors();
        dotProduct();
        lerp();





        // Create a new 2x2 texture ARGB32 (32 bit with alpha) and no mipmaps
        Texture2D texture = new Texture2D(gridSize - frequency - 1, gridSize - frequency - 1);
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = texture;


        for (int i = 0; i < gridSize - frequency - 1; i++)
        {
            for (int ii = 0; ii < gridSize - frequency - 1; ii++)
            {

                if (noiseMap[i, ii] > 1)
                {
                    noiseMap[i, ii] = 1;
                }

                Color newColour = new Color(noiseMap[i, ii], noiseMap[i, ii], noiseMap[i, ii], 1);

                texture.SetPixel(ii, i, newColour);

            }
        }

        texture.Apply();

        void SaveTexture(Texture2D texture1)
        {
            byte[] bytes = texture1.EncodeToPNG();
            var dirPath = Application.dataPath + "/RenderOutput";
            if (!System.IO.Directory.Exists(dirPath))
            {
                System.IO.Directory.CreateDirectory(dirPath);
            }
            System.IO.File.WriteAllBytes(dirPath + "/R_" + UnityEngine.Random.Range(0, 100000) + ".png", bytes);
            Debug.Log(bytes.Length / 1024 + "Kb was saved as: " + dirPath);

        }
        SaveTexture(texture);

    }

}
