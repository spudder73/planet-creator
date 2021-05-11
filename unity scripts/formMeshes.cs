using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class formMeshes : MonoBehaviour
{

    public Mesh createPlanet(int length, float[,] map, float amplitude, AnimationCurve heightCurve, int[,] startingPos)
    {
        
        float[] heightMap;
        int[] triangles;
        Vector3[] vertices;
        int vertCounter = 0;
        int triCounter = 0;
        Vector2[] uvs;
        Vector3[] verticesFlat;
        Vector2[] uvsFlat;
        Mesh mesh = new Mesh();

        triangles = new int[(length) * 3 * (length) * 4 * 2 * 10];
        vertices = new Vector3[((length + 2) * 3) * ((length) * 4)];
        uvs = new Vector2[((length) * 3) * ((length) * 4)];
        heightMap = new float[((length) * 3) * ((length) * 4)];

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

        }

        vertCounter = 0;

        for (int i = 0; i < 6; i++)
        {
            int x = startingPos[i, 0];
            int y = startingPos[i, 1];

            for (int ii = x; ii < x + length; ii++)
            {
                for (int iii = y; iii < y + length; iii++)
                {
                    vertices[vertCounter] = new Vector3(ii, length, iii);

                    uvs[vertCounter] = new Vector2((ii) / (float)length, iii / (float)length);
                    heightMap[vertCounter] = ((float)amplitude / 10f) * ((heightCurve.Evaluate(map[ii, iii]) + 1) / 2f) + (0.1f - ((float)amplitude / 10f));

                    vertCounter++;
                }
            }
        }



        for (int i = 0; i < vertCounter+1; i++)
        {
            //vertices[i] = (vertices[i]).normalized;
            //vertices[i] = vertices[i] * ((float)(2f - (float)(heightMap[i])));

        }





        int vertCounter2 = 0;

        for (int i = 0; i < 6; i++)
        {
            int x = startingPos[i, 0];
            int y = startingPos[i, 1];

            for (int ii = x; ii < x + length; ii++)
            {
                for (int iii = y; iii < y + length; iii++)
                {
                    if (ii < x + length & iii < y + length) // ? +2
                    {
                        createQuad2(vertCounter2, vertCounter2 + length , vertCounter2 + length + 1, vertCounter2 + 1);
                    }
                    vertCounter2++;
                }
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


        //flatShade();

        mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;

        mesh.RecalculateNormals();

        return mesh;
    }


    public Mesh createOcean(int length, float[,] map, float amplitude, AnimationCurve heightCurve, int[,] startingPos)
    {

        float[] heightMap;
        int[] triangles1;
        Vector3[] vertices1;
        int vertCounter = 0;
        int triCounter1 = 0;
        Vector2[] uvs1;

        Mesh mesh1 = new Mesh();


        triangles1 = new int[3 * 4 * 2 * (length) * (length) * 10];
        vertices1 = new Vector3[((length) * 3) * ((length) * 4)];
        uvs1 = new Vector2[((length) * 3) * ((length) * 4)];
        heightMap = new float[((length) * 3) * ((length) * 4)];

        void createQuad(int bl, int tl, int tr, int br)
        {

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



        for (int i = 0; i < 6; i++)
        {
            int x = startingPos[i, 0];
            int y = startingPos[i, 1];

            for (int ii = x; ii < x + length ; ii++)
            {
                for (int iii = y; iii < y + length; iii++)
                {
                    vertices1[vertCounter] = new Vector3(ii, length, iii);
                    uvs1[vertCounter] = new Vector2((ii) / (float)length, iii / (float)length);
                    heightMap[vertCounter] = ((float)amplitude / 10f) * ((heightCurve.Evaluate(map[ii, iii]) + 1) / 2f);

                    vertCounter++;
                }
            }
            
        }


        for (int i = 0; i < vertCounter; i++)
        {
            //vertices1[i] = (vertices1[i]).normalized;
        }





        int vertCounter2 = 0;

        for (int i = 0; i < 6; i++)
        {
            int x = startingPos[i, 0];
            int y = startingPos[i, 1];

            for (int ii = x; ii < x + length; ii++)
            {
                for (int iii = y; iii < y + length ; iii++)
                {
                    if (ii < x + length & iii < y + length) // ? +2
                    {
                        createQuad2(vertCounter2, vertCounter2 + length, vertCounter2 + length + 1, vertCounter2 + 1);
                    }
                    vertCounter2++;
                }
            }

        }

        mesh1.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;

        mesh1.vertices = vertices1;
        mesh1.triangles = triangles1;
        mesh1.uv = uvs1;

        mesh1.RecalculateNormals();

        return mesh1;
    }

}
