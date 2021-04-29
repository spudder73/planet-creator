using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MeshGeneration : MonoBehaviour
{
    
    // Start is called before the first frame update
    public Mesh assignMesh(int gridSize, int frequency, float[,] noiseMap, float amplitude,  AnimationCurve heightCurve)
    {
        //get the mesh size
        int height = (int)((gridSize - frequency - 1) / 4f);
        int width = (int)((gridSize - frequency - 1) / 4f);


        //assign variables needed for mesh creation
        int[] triangles;
        Vector3[] vertices;
        int vertCounter = 0;
        int triCounter = 0;
        Vector2[] uvs;
        Mesh mesh = new Mesh();

        //set top left pointers for the verticie assignment
        float tlx = (width - 1) / -2f;
        float tlz = (height - 1) / -2f;

        //set size of arrays
        //each vertice(height*width(-1 because edges have no triangles)) * 3(for each vertice in a triangle) * 2(2 triangles per vertice)
        triangles = new int[(height-1) * (width-1)*6];
        vertices = new Vector3[height * width];
        uvs = new Vector2[height * width];


        //nested for loop for each vertice
        for (int i = 0; i<height; i++)
        {
            for (int ii = 0; ii < width; ii++)
            {
                vertices[vertCounter] = new Vector3(tlx + i, amplitude * heightCurve.Evaluate(noiseMap[i,ii]), tlz - ii);


                //if on edge no triangles are created
                if (i < height - 2 & ii < width - 2)
                {
                    //1st triangle, vertices in clockwise order
                    triangles[triCounter] = vertCounter;
                    triangles[triCounter + 1] = vertCounter + 1 + width;
                    triangles[triCounter + 2] = vertCounter + width;

                    //2nd triangle
                    triangles[triCounter + 3] = vertCounter + 1 + width;
                    triangles[triCounter + 4] = vertCounter;
                    triangles[triCounter + 5] = vertCounter + 1;
                    //increase the vertices in triangles counter
                    triCounter += 6;
                }


                //set uv map size
                uvs[vertCounter] = new Vector2(i / (float)width, ii / (float)height);

                //increment vertice counter
                vertCounter++;
            }
            
        }

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
