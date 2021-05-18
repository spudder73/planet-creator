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

    float h2;
    float h3;
    float h4;
    float h5;

    int colourNo;

    public Texture2D draw(int length, float[,] map, AnimationCurve heightCurve, int[,] startingPos)
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

        Texture2D texture = new Texture2D(length * 4, length * 3);

        texture.filterMode = FilterMode.Point;

        Renderer renderer = GetComponent<Renderer>();

        renderer.material.mainTexture = texture;

        //nested for loop for each pixel

        for (int i = 0; i < 6; i++)
        {
            int x = startingPos[i, 0];
            int y = startingPos[i, 1];

            for (int ii = x; ii < x + length; ii++)
            {
                for (int iii = y; iii < y + length ; iii++)
                {

                    //create colours of texture based on the height of the noise
                    map[ii, iii] = (map[ii, iii]+1) / 2f;

                    if (heightCurve.Evaluate(map[ii, iii]) > h2)
                    {
                        newColour = colour2;
                    }

                    else if (heightCurve.Evaluate(map[ii, iii]) > h3)
                    {
                        newColour = colour3;
                    }

                    else if (heightCurve.Evaluate(map[ii, iii]) > h4)
                    {
                        newColour = colour4;
                    }

                    else
                    {
                        newColour = colour5;
                    }

                    //set the pixel of the texture to colour created
                    texture.SetPixel(ii, iii, newColour);

                    

                }
            }
        }

        //apply the texture calls
        texture.Apply();

        byte[] bytes = texture.EncodeToPNG();
        var dirPath = Application.dataPath + "/RenderOutput";
        if (!System.IO.Directory.Exists(dirPath))
        {
            System.IO.Directory.CreateDirectory(dirPath);
        }
        System.IO.File.WriteAllBytes(dirPath + "/R_" + Random.Range(0, 100000) + ".png", bytes);
        Debug.Log(bytes.Length / 1024 + "Kb was saved as: " + dirPath);

        return texture;
    }

    

}
