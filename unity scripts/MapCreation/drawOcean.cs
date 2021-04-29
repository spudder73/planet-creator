using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawOcean : MonoBehaviour
{
    Color newColour;
    Color colour1;
    noiseEditor get;
    float smallest;

    public Texture2D draw(int gridSize, int frequency, float[,] noiseMap1, AnimationCurve heightCurve)
    {
        get = gameObject.GetComponent<noiseEditor>();
        colour1 = get.getColour1();

        //create texture object
        Texture2D texture = new Texture2D(((int)(gridSize - frequency - 1) / 4) + 2, ((int)(gridSize - frequency - 1) / 4) + 2);

        //texture.filterMode = FilterMode.Point;

        //set no texture wrap
        //texture.wrapMode = TextureWrapMode.Clamp;

        //get the renderer object
        Renderer renderer = GetComponent<Renderer>();
        //set the object's material as the created texture
        renderer.material.mainTexture = texture;
        float val = 0; //wasnt working
        smallest = 1;
        //nested for loop for each pixel
        for (int i = 0; i < ((int)(gridSize - frequency - 1) / 4) + 2; i++)
        {

            for (int ii = 0; ii < ((int)(gridSize - frequency - 1) / 4) + 2; ii++)
            {

                if (noiseMap1[i, ii] < 1.1f)
                {
                    
                    val = (((noiseMap1[i, ii]-0.05f) * 2 - 1) * colour1.a);
                    newColour = new Color(colour1.r / val, colour1.g / val, colour1.b/ val, 1);
                    //set the pixel of the texture to colour created
                    texture.SetPixel(i, ii, newColour);
                    if (val > smallest)
                    {
                        smallest = val;
                    }
                }
                else
                {
                    newColour = new Color(colour1.r / smallest, colour1.g / smallest, colour1.b / smallest, 1);
                    //set the pixel of the texture to colour created
                    texture.SetPixel(i, ii, newColour);
                }
            }
        }

        //apply the texture calls
        texture.Apply();

        return texture;
    }
}
