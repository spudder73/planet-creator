using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newAssignMap : MonoBehaviour
{

    public noiseEditor noiseEditor;
    public createMap1 createMap1;
    public createMap2 createMap2;
    public createMap3 createMap3;
    public createMap4 createMap4;
    public createMap5 createMap5;
    public drawMap drawMap;
    public createMesh createMesh;
    
    public int grid;
    public float amplitude;
    public int octaves;
    public int freq;
    public int frequency2;
    public bool mode;
    public float height;
    public float persistance;
    public float startVal;
    public float height2;

    int[,] startingPos;
    public float[,] finalMap;
    public float[,,] mapOctaves;
    public float[,] noiseMap;
    
    public float[,,] map1;
    public float[,,,] map2;
    public float[,,,] map3;
    public float[,,] map4;
    public float[,] map5;
    
    public int freq3;
    public int length;
    public int dist;

    public AnimationCurve meshHeightCurve;

    //initialize mesh modifiers
    public float scale;

    //initialize texture
    Texture2D texture;

    void Start()
    {

        noiseEditor = gameObject.GetComponent<noiseEditor>();
        createMap1 = gameObject.GetComponent<createMap1>();
        createMap2 = gameObject.GetComponent<createMap2>();
        createMap3 = gameObject.GetComponent<createMap3>();
        createMap4 = gameObject.GetComponent<createMap4>();
        createMap5 = gameObject.GetComponent<createMap5>();
        drawMap = gameObject.GetComponent<drawMap>();
        createMesh = gameObject.GetComponent<createMesh>();

        grid = noiseEditor.getGridSize();
        amplitude = noiseEditor.getAmplitude();
        octaves = noiseEditor.getOctaves();
        freq = noiseEditor.getFrequency();
        frequency2 = freq;
        mode = noiseEditor.getMode();
        height = noiseEditor.getHeight();
        persistance = noiseEditor.getPersistance();
        startVal = 0.7f;
        height2 = 0;

        dist = noiseEditor.getDist();
        length = noiseEditor.getLength();

        finalMap = new float[length * 4, length * 3];
        mapOctaves = new float[octaves, length * 4, length * 3];
        noiseMap = new float[length * 4, length * 3];

        map1 = new float[length * 4, length * 3, 2];
        map2 = new float[length * 4, length * 3, 4, 2];
        map3 = new float[length * 4, length * 3, 4, 2];
        map4 = new float[length * 4, length * 3, 4];
        map5 = new float[length * 4, length * 3];
        finalMap = new float[length * 4, length * 3];

        startingPos = new int[,] { { length, 0 }, { 0, length }, { length, length }, { length * 2, length }, { length * 3, length }, { length, length * 2 } };
        freq3 = (int)(frequency2 * (Mathf.Pow(2, octaves - 1))); 

        recreateNoise();
    }



    void recreateNoise()
    {

        //get noise modifiers
        grid = noiseEditor.getGridSize();
        amplitude = noiseEditor.getAmplitude();
        octaves = noiseEditor.getOctaves();
        freq = noiseEditor.getFrequency();
        frequency2 = freq;
        mode = noiseEditor.getMode();
        height = noiseEditor.getHeight();
        persistance = noiseEditor.getPersistance();
        startVal = 0.7f;


        //function to create final noise map
        void addOctaves()
        {

            noiseEditor.setFrequency(frequency2);


            for (int i = 0; i < octaves; i++)
            {
                freq = noiseEditor.getFrequency();

                map1 = createMap1.addPoints(length, dist, startingPos, meshHeightCurve);
                map2 = createMap2.setDistances(length, dist, startingPos);
                map3 = createMap3.getRandVectors(length, dist, map1, startingPos);
                map4 = createMap4.dotProduct(length, dist, map2, map3, startingPos);
                map5 = createMap5.lerp(length, dist, i, mode, height, map2, map4, startingPos);



                for (int iv = 0; iv < 6; iv++)
                {
                    int x = startingPos[iv, 0];
                    int y = startingPos[iv, 1];

                    for (int ii = x; ii < x + length; ii++)
                    {
                        for (int iii = y; iii < y + length; iii++)
                        {
                            //for rest
                            if (i != 0)
                            {
                                finalMap[ii, iii] = finalMap[ii, iii] + (startVal * (noiseMap[ii, iii]));
                            }

                            //for first octave
                            else
                            {
                                finalMap[ii, iii] = (startVal * noiseMap[ii, iii]);
                            }

                            mapOctaves[i, ii, iii] = finalMap[ii, iii];
                        }
                    }

                }

                //for next octave lower the opacity
                startVal *= persistance;

                //change level of detail
                noiseEditor.setFrequency(freq * 2);


            }


            noiseEditor.setFrequency(frequency2);
            
        }
        

        //create noise
        addOctaves();
        freq = noiseEditor.getFrequency();

        changeA(length, amplitude, scale);

    }

    public void changeOH(int length1, float amplitude1, float scale1)
    {
        createMesh.createOcean(length1, finalMap, amplitude1, meshHeightCurve, scale1, true, startingPos);
    }

    public void changeC(int length1, float amplitude1, float scale1)
    {
        createMesh.addMaterials(length1, finalMap, amplitude1, meshHeightCurve, scale1, startingPos);
        createMesh.addOceanMaterial(length1, finalMap, amplitude1, meshHeightCurve, scale1, startingPos);
    }

    public void changeM(float height1, int length1, float amplitude1, float scale1)
    {
        recreateNoise();
        height2 = 0;
        changeH(height1, length1, amplitude1, scale1);
    }


    public void changeH(float height1, int length1, float amplitude1, float scale1)
    {
        for (int i = 0; i < 6; i++)
        {
            int x = startingPos[i, 0];
            int y = startingPos[i, 1];

            for (int ii = x; ii < x + length1; ii++)
            {
                for (int iii = y; iii < y + length1; iii++)
                {
                    finalMap[ii, iii] += (height1 - height2);
                }
            }
        }

        height2 = height1;
        changeA(length1, scale1, amplitude1);
    }

    public void changeP(float height1, int octaves1, int length1, float persistance1, float amplitude1, float scale1)
    {
        for (int i = 0; i < octaves1; i++)
        {
            if (i != 0)
            {
                for (int iv = 0; iv < 6; iv++)
                {
                    int x = startingPos[iv, 0];
                    int y = startingPos[iv, 1];

                    for (int ii = x; ii < x + length1; ii++)
                    {
                        for (int iii = y; iii < y + length1; iii++)
                        {
                            finalMap[ii, iii] = finalMap[ii, iii] + startVal * mapOctaves[i, ii, iii];
                        }
                    }
                }

            }

            //for first octave
            else
            {
                for (int iv = 0; iv < 6; iv++)
                {
                    int x = startingPos[iv, 0];
                    int y = startingPos[iv, 1];

                    for (int ii = x; ii < x + length1; ii++)
                    {
                        for (int iii = y; iii < y + length1; iii++)
                        {
                            finalMap[ii, iii] = startVal * mapOctaves[i, ii, i];
                            finalMap[ii, iii] += height1;
                        }
                    }
                }
            }



            startVal = startVal * persistance1;
        }


        height2 = height1;

        changeA(length1, amplitude1, scale1);

    }

    public void changeA(int length1, float amplitude1, float scale1)
    {
        freq = freq3; // fixed big borders

        createMesh.createMeshes(length1, map5, amplitude1, meshHeightCurve, scale1, false, startingPos);
        createMesh.createOcean(length1, finalMap, amplitude1, meshHeightCurve, scale1, false, startingPos);
        createMesh.addOceanMaterial(length1, finalMap, amplitude1, meshHeightCurve, scale1, startingPos);

    }

    public void changeS(int length1, float amplitude1, float scale1)
    {
        createMesh.createMeshes(length1, finalMap, amplitude1, meshHeightCurve, scale1, true, startingPos);
        createMesh.createOcean(length1, finalMap, amplitude1, meshHeightCurve, scale1, true, startingPos);
        
    }

}
