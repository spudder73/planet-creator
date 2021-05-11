using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createMap1 : MonoBehaviour
{

    public float[,,] addPoints(int length1, int dist, int[,] startingPos1 , AnimationCurve heightCurve1)
    {

        float[,,] map1 = new float[length1 * 4, length1 * 3, 2];
        float[,] mapx = new float[length1 * 4, length1 * 3];

        for (int i = 0; i < 6; i++)
        {
            int x = startingPos1[i, 0];
            int y = startingPos1[i, 1];
            

            for (int ii = x; ii < x + length1; ii += dist)
            {
                for (int iii = y; iii < y + length1; iii += dist)
                {
                    map1[ii, iii, 0] = UnityEngine.Random.Range(-1f, 1.0f);
                    map1[ii, iii, 1] = UnityEngine.Random.Range(-1f, 1.0f);
                    mapx[5, length1] = 1f;
                }
            }
        }
        /*
        for (int ii = 0; ii < length*4; ii ++)
        {
            string str = "";
            for (int iii = 0; iii < length*3; iii ++)
            {
                str += map1[ii, iii, 0] + ",";
            }
            Debug.Log(str);
        }
        */

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
        draw(length1, mapx, heightCurve1, startingPos1);

        Texture2D draw(int length, float[,] map, AnimationCurve heightCurve, int[,] startingPos)
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
                    for (int iii = y; iii < y + length; iii++)
                    {

                        //create colours of texture based on the height of the noise


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

        return map1;

    }
}
