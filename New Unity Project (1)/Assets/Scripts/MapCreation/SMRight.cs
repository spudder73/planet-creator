using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMRight : MonoBehaviour
{
    drawOcean get6;

    void Start()
    {
        get6 = gameObject.GetComponent<drawOcean>();
    }

    public Object createCubeRight(int gridSize, int frequency, float[,] noiseMap, float amplitude, AnimationCurve depthCurve, bool ocean, string side, bool tex)
    {
        
        float[] heightMap;
        //get the mesh size
        int depth = gridSize - frequency - 1;
        depth = (int)(depth / 4f);
        int width = gridSize - frequency - 1;
        width = (int)(width / 4f);
        int height = gridSize - frequency - 1;
        height = (int)(height / 4f);
        //assign variables needed for mesh creation
        int[] triangles;
        Vector3[] vertices;
        int[] triangles1;
        Vector3[] vertices1;
        int vertCounter = 0;
        int triCounter1 = 0;
        int triCounter = 0;
        Vector2[] uvs;
        Vector3[] verticesFlat;
        Vector2[] uvsFlat;
        Vector2[] uvs1;
        Mesh mesh = new Mesh();
        Mesh mesh1 = new Mesh();

        float[,] oceanTexture;
        oceanTexture = new float[gridSize - frequency - 1, gridSize - frequency - 1];
        //set size of arrays
        //each vertice(depth*width(-1 because edges have no triangles)) * 3(for each vertice in a triangle) * 2(2 triangles per vertice)
        triangles = new int[6 * (height) * (height) * 2];
        //vertices = new Vector3[depth * width * 6 - 12 * height + 8];
        vertices = new Vector3[depth * width *2];
        uvs = new Vector2[(depth +2)* (width+2)];

        triangles1 = new int[6 * (height) * (height) * 2];
        //vertices = new Vector3[depth * width * 6 - 12 * height + 8];
        vertices1 = new Vector3[depth * width * 2];
        uvs1 = new Vector2[depth * width * 2];

        heightMap = new float[depth * width * 2];

        void createQuad(int bl, int tl, int tr, int br)
        {
            //1st triangle, vertices in clockwise order
            triangles[triCounter] = bl;
            triangles[triCounter + 1] = tl;
            triangles[triCounter + 2] = tr;

            //2nd triangle
            triangles[triCounter + 3] = bl;
            triangles[triCounter + 4] = tr;
            triangles[triCounter + 5] = br;

            //increase the vertices in triangles counter
            triCounter += 6;

            triangles1[triCounter1] = bl;
            triangles1[triCounter1 + 1] = tl;
            triangles1[triCounter1 + 2] = tr;

            //2nd triangle
            triangles1[triCounter1 + 3] = bl;
            triangles1[triCounter1 + 4] = tr;
            triangles1[triCounter1 + 5] = br;

            //increase the vertices in triangles counter
            triCounter1 += 6;
        }

        void createQuad2(int bl, int tl, int tr, int br)
        {
            //1st triangle, vertices in clockwise order
            triangles[triCounter] = tr;
            triangles[triCounter + 1] = tl;
            triangles[triCounter + 2] = bl;

            //2nd triangle
            triangles[triCounter + 3] = br;
            triangles[triCounter + 4] = tr;
            triangles[triCounter + 5] = bl;

            //increase the vertices in triangles counter
            triCounter += 6;

            triangles1[triCounter1] = tr;
            triangles1[triCounter1 + 1] = tl;
            triangles1[triCounter1 + 2] = bl;

            //2nd triangle
            triangles1[triCounter1 + 3] = br;
            triangles1[triCounter1 + 4] = tr;
            triangles1[triCounter1 + 5] = bl;

            //increase the vertices in triangles counter
            triCounter1 += 6;
        }



        for (int iii = 0; iii < height + 2; iii++)
        {
            for (int ii = 0; ii < depth + 2; ii++)
            {
                if (side == "right")
                {
                    vertices[vertCounter] = new Vector3(ii - depth / 2, iii - depth / 2, 0 - depth / 2);
                    vertices1[vertCounter] = new Vector3(ii - depth / 2, iii - depth / 2, 0 - depth / 2);
                }
                if (side == "left")
                {
                    vertices[vertCounter] = new Vector3(height - depth / 2, iii - depth / 2, ii - depth / 2);
                    vertices1[vertCounter] = new Vector3(height - depth / 2, iii - depth / 2, ii - depth / 2);
                }
                if (side == "front")
                {
                    vertices[vertCounter] = new Vector3(0 - depth / 2, iii - depth / 2, ii - depth / 2);
                    vertices1[vertCounter] = new Vector3(0 - depth / 2, iii - depth / 2, ii - depth / 2);
                }
                if (side == "back")
                {
                    vertices[vertCounter] = new Vector3(ii - depth / 2, iii - depth / 2, height - depth / 2);
                    vertices1[vertCounter] = new Vector3(ii - depth / 2, iii - depth / 2, height - depth / 2);
                }
                if (side == "top")
                {
                    vertices[vertCounter] = new Vector3(ii - depth / 2, - depth / 2, iii - depth / 2);
                    vertices1[vertCounter] = new Vector3(ii - depth / 2, - depth / 2, iii - depth / 2);
                }
                if (side == "bottom")
                {
                    vertices[vertCounter] = new Vector3(ii - depth / 2, height - depth / 2, iii - depth / 2);
                    vertices1[vertCounter] = new Vector3(ii - depth / 2, height - depth / 2, iii - depth / 2);
                }


                //set uv map size
                uvs[vertCounter] = new Vector2((ii) / (float)width, iii / (float)depth);
                uvs1[vertCounter] = new Vector2((ii) / (float)width, iii / (float)depth);
                oceanTexture[ii, iii] = noiseMap[ii, iii];
                heightMap[vertCounter] = ((float)amplitude / 10f) * ((depthCurve.Evaluate(noiseMap[ii, iii]) + 1) / 2f);
                //increment vertice counter
                vertCounter++;
            }
        }



        for (int i = 0; i < vertCounter; i++)
        {
            vertices1[i] = (vertices1[i]).normalized;
            vertices[i] = (vertices[i]).normalized;
            //vertices[i] = (vertices[i] * (float)((depthCurve.Evaluate(noiseMap[ii, iii]) + 2) * 0.5f));
            vertices[i] = vertices[i] * ((float)(2f - (float)(heightMap[i])));

        }





        int vertCounter2 = 0;

        for (int i = 0; i < height + 2; i++)
        {
            for (int ii = 0; ii < (width) + 2; ii++)
            {
                if (i < height  & ii < width ) // ? +2
                {
                    if (side == "front" || side == "back" || side == "top")
                    {
                        createQuad2(vertCounter2, vertCounter2 + width + 2, vertCounter2 + width + 3, vertCounter2 + 1);
                    }
                    else
                    {
                        createQuad(vertCounter2, vertCounter2 + width + 2, vertCounter2 + width + 3, vertCounter2 + 1);

                    }

                }
                vertCounter2++;
            }

        }


        void flatShade()
        {
            verticesFlat = new Vector3[triangles.Length];
            uvsFlat = new Vector2[triangles.Length];

            for (int i = 0; i<triangles.Length; i++)
            {
                verticesFlat[i] = vertices[triangles[i]];
                uvsFlat[i] = uvs[triangles[i]];
                triangles[i] = i;
            }
            vertices = verticesFlat;
            uvs = uvsFlat;
        }


        flatShade();

        //increase the allowed mesh vertice limit
        mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;

        //set the meshes triangles verticies and uvs to the ones created
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;

        //calculate the mesh normals properly
        mesh.RecalculateNormals();

        //increase the allowed mesh vertice limit
        mesh1.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;

        //set the meshes triangles verticies and uvs to the ones created
        mesh1.vertices = vertices1;
        mesh1.triangles = triangles1;
        mesh1.uv = uvs1;

        //calculate the mesh normals properly
        mesh1.RecalculateNormals();

        if (ocean)
        {
            return mesh1;
        }

        else if (tex)
        {
            Texture2D texture = new Texture2D(((int)(gridSize - frequency - 1) / 4) + 2, ((int)(gridSize - frequency - 1) / 4) + 2);
            //call texture creator from noise map created
            texture = get6.draw(gridSize, frequency, oceanTexture, depthCurve);

            return texture;
        }

        else
        {
            return mesh;
        }



    }
}
