using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public class drawMap : MonoBehaviour
{
    noiseEditor get;

    Color colour2;
    Color colour3;
    Color colour4;
    Color colour5;
    Color newColour;
    Complex z;
    float h2;
    float h3;
    float h4;
    float h5;

    int colourNo;

    public Texture2D draw(int gridSize, int frequency,float[,] noiseMap1, AnimationCurve heightCurve)
    {
        get = gameObject.GetComponent<noiseEditor>();
        h2 = get.getH2();
        h3 = get.getH3();
        h4 = get.getH4();
        h5 = get.getH5();


        colour2 = get.getColour2();
        colour3 = get.getColour3();
        colour4 = get.getColour4();
        colour5 = get.getColour5();



        //create texture object
        Texture2D texture = new Texture2D(((int)(gridSize - frequency - 1) / 4) + 2, ((int)(gridSize - frequency - 1) / 4) + 2);

        texture.filterMode = FilterMode.Point;

        //set no texture wrap

        //get the renderer object
        Renderer renderer = GetComponent<Renderer>();
        //set the object's material as the created texture
        renderer.material.mainTexture = texture;
        
        //nested for loop for each pixel
        for (int i = 0; i < ((int)(gridSize - frequency - 1) / 4) + 2; i++)
        {

            for (int ii = 0; ii < ((int)(gridSize - frequency - 1) / 4) + 2; ii++)
            {

                //create colours of texture based on the height of the noise
                
                
                if (heightCurve.Evaluate(noiseMap1[i, ii]) > h2)
                {
                    newColour = colour2;
                }

                else if (heightCurve.Evaluate(noiseMap1[i, ii]) > h3)
                {
                    newColour = colour3;
                }
                
                else if (heightCurve.Evaluate(noiseMap1[i, ii]) > h4)
                {
                    newColour = colour4;
                }

                else
                {
                    newColour = colour5;
                }
                




                //set the pixel of the texture to colour created
                texture.SetPixel(i, ii, newColour);
            }
        }

        //apply the texture calls
        texture.Apply();

        return texture;
    }

    

}
