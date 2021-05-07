using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawOcean : MonoBehaviour
{
    Color newColour;
    Color colour1;
    noiseEditor get;
    float smallest;

    public Texture2D draw(int length, float[,] map, AnimationCurve heightCurve, int[,] startingPos)
    {
        get = gameObject.GetComponent<noiseEditor>();
        colour1 = get.getColour1();
        Texture2D texture = new Texture2D(length, length);

        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = texture;
        float val = 0; //wasnt working
        smallest = 1;

        for (int i = 0; i < 6; i++)
        {
            int x = startingPos[i, 0];
            int y = startingPos[i, 1];

            for (int ii = x; ii < x + length + 2; ii++)
            {
                for (int iii = y; iii < y + length + 2; iii++)
                {

                    if (map[ii, iii] < 1.1f)
                    {
                        val = (((map[ii, iii] - 0.05f) * 2 - 1) * colour1.a);
                        newColour = new Color(colour1.r / val, colour1.g / val, colour1.b / val, 1);
                        //set the pixel of the texture to colour created
                        texture.SetPixel(ii, iii, newColour);
                        if (val > smallest)
                        {
                            smallest = val;
                        }

                    }

                    else
                    {
                        newColour = new Color(colour1.r / smallest, colour1.g / smallest, colour1.b / smallest, 1);
                        //set the pixel of the texture to colour created
                        texture.SetPixel(ii, iii, newColour);
                    }

                }
            }
        }

        //apply the texture calls
        texture.Apply();

        return texture;
    }
}
