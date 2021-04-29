using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeCreation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Start is called before the first frame update
    public Mesh createCube(int gridSize, int frequency, float[,] noiseMap, float amplitude, AnimationCurve depthCurve)
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
        int vertCounter = 0;
        int triCounter = 0;
        Vector2[] uvs;
        Mesh mesh = new Mesh();

        //set top left pointers for the verticie assignment
        float tlx = (width - 1) / -2f;
        float tlz = (depth - 1) / -2f;

        //set size of arrays
        //each vertice(depth*width(-1 because edges have no triangles)) * 3(for each vertice in a triangle) * 2(2 triangles per vertice)
        triangles = new int[6 * (height) * (height) * 7];
        //vertices = new Vector3[depth * width * 6 - 12 * height + 8];
        vertices = new Vector3[depth * width * 7];
        uvs = new Vector2[depth * width * 7];
        heightMap = new float[depth * width * 7];

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



        for (int iii = 0; iii < height+1; iii++)
        {


            for (int ii = 0; ii < depth + 1; ii++)
            {
                vertices[vertCounter] = new Vector3(ii - depth/2, iii - depth / 2, 0 - depth / 2);

                //set uv map size
                uvs[vertCounter] = new Vector2((ii) / (float)width, iii / (float)depth);
                heightMap[vertCounter] = ((float)amplitude / 10f) * ((depthCurve.Evaluate(noiseMap[ii, iii]) + 1) / 2f);
                //increment vertice counter
                vertCounter++;
            }

            for (int ii = 0; ii < depth + 1; ii++)
            {
                vertices[vertCounter] = new Vector3(height - depth / 2, iii - depth/2, ii - depth/2);

                //set uv map size
                uvs[vertCounter] = new Vector2(iii / (float)width, ii / (float)depth);
                heightMap[vertCounter] = ((float)amplitude / 10f) * ((depthCurve.Evaluate(noiseMap[iii, ii]) + 1) / 2f);
                //increment vertice counter
                vertCounter++;
            }

            for (int ii = depth ; ii > -1; ii--)
            {
                vertices[vertCounter] = new Vector3(ii - depth/2, iii - depth/2, height - depth/2);

                //set uv map size
                uvs[vertCounter] = new Vector2(iii / (float)width, ii / (float)depth);
                heightMap[vertCounter] = ((float)amplitude / 10f) * ((depthCurve.Evaluate(noiseMap[iii, ii]) + 1) / 2f);
                //increment vertice counter
                vertCounter++;
            }

            for (int ii = depth ; ii > -1; ii--)
            {
                vertices[vertCounter] = new Vector3(0 - depth/2, iii - depth/2, ii - depth/2);

                //set uv map size
                uvs[vertCounter] = new Vector2((iii) / (float)width, ii / (float)depth);
                heightMap[vertCounter] = ((float)amplitude / 10f) * ((depthCurve.Evaluate(noiseMap[iii, ii]) + 1) / 2f);
                //set heoght here?
                //increment vertice counter
                vertCounter++;
            }
        }
        
        

        int vertCounter3 = vertCounter;
        for (int iii = 0; iii < 2; iii++)
        {
            //nested for loop for each vertice
            for (int i = 0; i < height+2; i++)
            {
                for (int ii = 0; ii < height+2; ii++)
                {
                    vertices[vertCounter] = new Vector3(ii - depth / 2, iii * height - depth / 2, i - depth / 2);

                    //createQuad(vertCounter, vertCounter + (height), vertCounter + (height) + 1, vertCounter + 1);

                    //set uv map size
                    if (iii == 0)
                    {
                        uvs[vertCounter] = new Vector2(i / (float)width, ii / (float)depth);
                        heightMap[vertCounter] = ((float)amplitude / 10f) * ((float)(depthCurve.Evaluate(noiseMap[i, ii]) + 1) / 2f);
    }
                    else
                    {
                        uvs[vertCounter] = new Vector2(ii / (float)width, i / (float)depth);

                        heightMap[vertCounter] = ((float)amplitude / 10f) * ((float)(depthCurve.Evaluate(noiseMap[ii, i]) +1)  /2f);
                    }

                    //create list of verts not to change

                    //increment vertice counter
                    vertCounter++;
                }
            }
        }

        
        for (int i = 0; i < vertCounter; i++)
        {
            
            vertices[i] = (vertices[i]).normalized;
            //vertices[i] = (vertices[i] * (float)((depthCurve.Evaluate(noiseMap[ii, iii]) + 2) * 0.5f));
            vertices[i] = vertices[i] * ((float)(2f -(float)(heightMap[i])));

        }
        



        
        int vertCounter2 = 0;
        
        for (int i = 0; i < height; i++)
        {
            int first = vertCounter2;
            int second = vertCounter2 + width * 4 + 4;

            for (int ii = 0; ii < 4 * (width+1) -1  ; ii++)
            {

                createQuad(vertCounter2, vertCounter2 + width * 4+4 , vertCounter2 + width * 4 + 4 + 1, vertCounter2 + 1);

                vertCounter2++;
            }

            createQuad(vertCounter2, vertCounter2 + width * 4 + 4, second, first);
            vertCounter2++;
        }

        


        vertCounter2 = vertCounter3;
        for (int iii = 0; iii < 2; iii++)
        {
            for (int i = 0; i < height+2; i++)
            {
                for (int ii = 0; ii < (height+2); ii++)
                {
                    if (i < height+1 & ii < width+1) // ? +2
                    {
                        if (iii == 0)
                        {
                            createQuad2(vertCounter2, vertCounter2 + (height+2), vertCounter2 + (height + 2) + 1, vertCounter2 + 1);
                        }

                        else
                        {
                            createQuad(vertCounter2, vertCounter2 + height + 2, vertCounter2 + (height + 2) + 1, vertCounter2 + 1);
                        }
                    }

                    vertCounter2++;
                }
            }


            
            //vertCounter2 += 5;
        }
        

        //bottom last
        //this is wrong
        /*
        int a = vertCounter - ((height - 2) * (height - 2));
        
        createQuad(0, 4*height-5, a, 1);
        vertCounter2++;

        for (int i = 1; i < height-3; i++)
        {
            createQuad(i, a+ i-1, a + i, i+1);
            vertCounter2++;
        }

        createQuad(height - 2, a + height - 2, height, height - 1);
        vertCounter2++;


        for (int i = 1; i < height - 3; i++)
        {
            createQuad(height+ i -1, a + height - 2 + (i- 1)*(height-2), a + height - 2 + (i) * (height - 2), height + i);
            vertCounter2++;
        }

        createQuad(2*height - 2, 2 * height - 3,vertCounter2 , 2 * height - 1);
        vertCounter2++;

        for (int i = 1; i < height - 3; i++)
        {
            createQuad(2 * height - 2 + i, vertCounter2-i+1, vertCounter2-i, 2 * height -1 + i);
            vertCounter2++;
        }

        createQuad(3*height - 3, 3 * height - 4, vertCounter2 - (height-3), 3 * height - 2);
        vertCounter2++;


        for (int i = 1; i < height - 3; i++)
        {
            createQuad(height + i - 1, vertCounter2 - (i - 1) * (height - 2), vertCounter2 - (i) * (height - 2), height + i);
            vertCounter2++;
        }
        */




        //increase the allowed mesh vertice limit
        mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;

        //set the meshes triangles verticies and uvs to the ones created
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;

        //calculate the mesh normals properly
        mesh.RecalculateNormals();


        return mesh;

    }
}