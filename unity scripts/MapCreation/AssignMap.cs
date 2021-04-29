using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignMap : MonoBehaviour
{

    //initialize noise modifiers
    float amplitude1;
    int gridSize1;
    int frequency1;
    int octaves;
    int frequency2;
    float fade;
    float sizeRatio;
    bool ridged;
    bool billowy;
    bool apply;
    float height1;
    bool changeA;
    bool changeH;
    bool changeS;
    bool changeH1;
    float scaler;
    float height2;
    bool changeP1;
    bool changeO;
    bool changeT;
    bool changeS2;

    //initialize counters and checks
    int distance1;
    int distance2;
    float counter;
    bool modify;




    //initialize maps
    float[,,] randVectMap;
    float[,,,] distanceVectMap;
    float[,,,] assignedVectMap;
    float[,,] dotMap;
    float[,] finalNoiseMap;
    float[,] noiseMap;

    float[,] noiseMap1;
    float[,] noiseMap2;
    float[,] noiseMap3;
    float[,] noiseMap4;
    float[,] noiseMap5;
    float[,] noiseMap6;
    public bool changeO2;

    float[,,,] noiseMaps;
    float[,] falloffMap;
    float[,,] allFinalNoiseMaps;

    public AnimationCurve meshHeightCurve;


    //initialize getter variables
    noiseEditor get;
    MapSetup get2;
    GetDistanceV get3;
    assignRandomV get4;
    DotProduct get5;
    drawMap get6;
    Lerp get7;
    MeshGeneration get8;

    cubeCreation get9;
    falloff get10;
    int mode;
    createMesh get17;



    //initialize mesh modifiers
    Vector3 scale;
    Vector3 pos;
    Vector3 rot;

    //initialize texture
    Texture2D texture;

    void Start()
    {
        changeO = false;
        changeO2 = false;
        changeT = false;
        //set all getters
        get = gameObject.GetComponent<noiseEditor>();
        get2 = gameObject.GetComponent<MapSetup>();
        get3 = gameObject.GetComponent<GetDistanceV>();
        get4 = gameObject.GetComponent<assignRandomV>();
        get5 = gameObject.GetComponent<DotProduct>();
        get6 = gameObject.GetComponent<drawMap>();
        get7 = gameObject.GetComponent<Lerp>();
        get8 = gameObject.GetComponent<MeshGeneration>();
        get9 = gameObject.GetComponent<cubeCreation>();
        get10 = gameObject.GetComponent<falloff>();



        get17 = gameObject.GetComponent<createMesh>();
        height2 = 0;
        recreateNoise();
    }

    

    void recreateNoise()
    {
        
        //get noise modifiers
        gridSize1 = get.getGridSize();
        amplitude1 = get.getAmplitude();
        octaves = get.getOctaves();
        frequency1 = get.getFrequency();
        frequency2 = frequency1;
        mode = get.getMode();
        height1 = get.getHeight();
        modify = get.getModify();
        fade = get.getDetail();
        counter = 0.7f;


        //function to create final noise map
        void addOctaves()
        {

            allFinalNoiseMaps = new float[6, (int)((gridSize1 - frequency1 - 1) / 4f) + 2, (int)((gridSize1 - frequency1 - 1) / 4f) + 2];
            noiseMaps = new float[6, octaves, (int)((gridSize1 - frequency1 - 1) / 4f) + 2, (int)((gridSize1 - frequency1 - 1) / 4f) + 2];
            //for loop for each octave
            for (int iv = 0; iv < 6; iv++)
            {
                get.setFrequency(frequency2);
                frequency1 = get.getFrequency();
                fade = get.getDetail();
                counter = 0.7f;

                //set size of noise map
                finalNoiseMap = new float[(int)((gridSize1 - frequency1 - 1) / 4f) + 2, (int)((gridSize1 - frequency1 - 1) / 4f) + 2];
                noiseMap = new float[(int)((gridSize1 - frequency1 - 1) / 4f) + 2, (int)((gridSize1 - frequency1 - 1) / 4f) + 2];
                

                for (int i = 0; i < octaves; i++)
                {
                    //get all maps

                    frequency1 = get.getFrequency();
                    distance1 = get.getDistance();
                    
                    distance2 = get.getDistance1();

                    randVectMap = get2.setUpGrid(gridSize1, frequency1, distance1);
                    distanceVectMap = get3.getDistanceVectors(gridSize1, frequency1, distance1);
                    assignedVectMap = get4.assignRandomVectors(gridSize1, frequency1, distance2);
                    dotMap = get5.dotProduct(gridSize1, frequency1);
                    noiseMap = get7.lerp(gridSize1, frequency1, i, mode, height1);


                    //nested for loop for each vertice
                    for (int ii = 0; ii < (int)((gridSize1 - frequency1 - 1) / 4f) + 2; ii++)
                    {
                        for (int iii = 0; iii < (int)((gridSize1 - frequency1 - 1) / 4f) + 2; iii++)
                        {
                            //for rest
                            if (i != 0)
                            {
                                finalNoiseMap[ii, iii] = finalNoiseMap[ii, iii] + (counter * (noiseMap[ii, iii]));
                            }

                            //for first octave
                            else
                            {
                                finalNoiseMap[ii, iii] = (counter * noiseMap[ii, iii]);
                            }

                            noiseMaps[iv, i, ii, iii] = noiseMap[ii, iii];
                        }

                    }

                    //for next octave lower the opacity
                    counter = counter * fade;

                    //change level of detail
                    get.setFrequency(frequency1 * 2);


                }

                falloffMap = new float[(int)((gridSize1 - frequency1 - 1) / 4f) + 2, (int)((gridSize1 - frequency1 - 1) / 4f) + 2];
                falloffMap = get10.createFalloffMap((int)((gridSize1 - frequency1 - 1) / 4f) + 2);

                for (int ii = 0; ii < (int)((gridSize1 - frequency1 - 1) / 4f) + 2; ii++)
                {
                    for (int iii = 0; iii < (int)((gridSize1 - frequency1 - 1) / 4f) + 2; iii++)
                    {
                        //Mathf.Clamp01

                        finalNoiseMap[iii, ii] = (finalNoiseMap[iii, ii] + falloffMap[iii, ii]);

                    }

                }

                for (int ii = 0; ii < (int)((gridSize1 - frequency1 - 1) / 4f) + 2; ii++)
                {
                    for (int iii = 0; iii < (int)((gridSize1 - frequency1 - 1) / 4f) + 2; iii++)
                    {
                        //Mathf.Clamp01
                        allFinalNoiseMaps[iv, iii, ii] = finalNoiseMap[iii, ii];

                    }

                }

            }
        }

        //create noise
        addOctaves();
        noiseMap1 = new float[(int)((gridSize1 - frequency1 - 1) / 4f) + 2, (int)((gridSize1 - frequency1 - 1) / 4f) + 2];
        noiseMap2 = new float[(int)((gridSize1 - frequency1 - 1) / 4f) + 2, (int)((gridSize1 - frequency1 - 1) / 4f) + 2];
        noiseMap3 = new float[(int)((gridSize1 - frequency1 - 1) / 4f) + 2, (int)((gridSize1 - frequency1 - 1) / 4f) + 2];
        noiseMap4 = new float[(int)((gridSize1 - frequency1 - 1) / 4f) + 2, (int)((gridSize1 - frequency1 - 1) / 4f) + 2];
        noiseMap5 = new float[(int)((gridSize1 - frequency1 - 1) / 4f) + 2, (int)((gridSize1 - frequency1 - 1) / 4f) + 2];
        noiseMap6 = new float[(int)((gridSize1 - frequency1 - 1) / 4f) + 2, (int)((gridSize1 - frequency1 - 1) / 4f) + 2];

        for (int ii = 0; ii < (int)((gridSize1 - frequency1 - 1) / 4f) + 2; ii++)
        {
            for (int iii = 0; iii < (int)((gridSize1 - frequency1 - 1) / 4f) + 2; iii++)
            {
                //Mathf.Clamp01
                
                noiseMap1[iii, ii] = allFinalNoiseMaps[0, iii, ii];
                noiseMap2[iii, ii] = allFinalNoiseMaps[1, iii, ii];
                noiseMap3[iii, ii] = allFinalNoiseMaps[2, iii, ii];
                noiseMap4[iii, ii] = allFinalNoiseMaps[3, iii, ii];
                noiseMap5[iii, ii] = allFinalNoiseMaps[4, iii, ii];
                noiseMap6[iii, ii] = allFinalNoiseMaps[5, iii, ii];
            }

        }

        get.setChangeA();

    }

    //get functions 
    public float[,,] getRandVectMap()
    {
        return randVectMap;
    }

    public float[,,,] getDistanceVectMap()
    {
        return distanceVectMap;
    }

    public float[,,,] getAssignedVectMap()
    {
        return assignedVectMap;
    }

    public float[,,] getDotMap()
    {
        return dotMap;
    }
    



    

    // Update is called once per frame
    void Update()
    {
        //+2

        scaler = get.getScaler();

        

        get.setChangeO();
        get.setChangeT();
        get.setChangeO2();
        get.setChangeS2();

        changeA = get.getChangeA();
        if (changeA == true)
        {

            Debug.Log("hi");
            changeH = get.getChangeH();

            if (changeH == true)
            {
                
                height1 = get.getHeight();

                for (int i=0; i< (int)((gridSize1 - frequency1 - 1) / 4f) + 2; i++)
                {
                    for (int ii = 0; ii < (int)((gridSize1 - frequency1 - 1) / 4f) + 2; ii++)
                    {
                        noiseMap1[i, ii] -= height2;
                        noiseMap1[i, ii] += height1;

                        noiseMap2[i, ii] -= height2;
                        noiseMap2[i, ii] += height1;

                        noiseMap3[i, ii] -= height2;
                        noiseMap3[i, ii] += height1;

                        noiseMap4[i, ii] -= height2;
                        noiseMap4[i, ii] += height1;

                        noiseMap5[i, ii] -= height2;
                        noiseMap5[i, ii] += height1;

                        noiseMap6[i, ii] -= height2;
                        noiseMap6[i, ii] += height1;
                    }
                }

                height2 = get.getHeight();
                get.setChangeH();
            }

            changeH1 = get.getChangeH1();

            if (changeH1 == true)
            {
                for (int i = 0; i < (int)((gridSize1 - frequency1 - 1) / 4f) + 2; i++)
                {
                    for (int ii = 0; ii < (int)((gridSize1 - frequency1 - 1) / 4f) + 2; ii++)
                    {
                        noiseMap1[i, ii] += height1;
                        noiseMap2[i, ii] += height1;
                        noiseMap3[i, ii] += height1;
                        noiseMap4[i, ii] += height1;
                        noiseMap5[i, ii] += height1;
                        noiseMap6[i, ii] += height1;
                    }
                }
                get.setChangeH1();
            }

            height2 = get.getHeight();
            changeP1 = get.getChangeP();

            if (changeP1 == true)
            {
                octaves = get.getOctaves();
                fade = get.getDetail();
                counter = 0.7f;
                height1 = get.getHeight();

                for (int iii = 0; iii < octaves; iii++)
                {
                    if (iii != 0)
                    {
                        for (int i = 0; i < (int)((gridSize1 - frequency1 - 1) / 4f) + 2; i++)
                        {
                            for (int ii = 0; ii < (int)((gridSize1 - frequency1 - 1) / 4f) + 2; ii++)
                            {
                                noiseMap1[i, ii] = noiseMap1[i, ii] + counter * noiseMaps[0, iii, i, ii];
                                noiseMap2[i, ii] = noiseMap2[i, ii] + counter * noiseMaps[1, iii, i, ii];
                                noiseMap3[i, ii] = noiseMap3[i, ii] + counter * noiseMaps[2, iii, i, ii];
                                noiseMap4[i, ii] = noiseMap4[i, ii] + counter * noiseMaps[3, iii, i, ii];
                                noiseMap5[i, ii] = noiseMap5[i, ii] + counter * noiseMaps[4, iii, i, ii];
                                noiseMap6[i, ii] = noiseMap6[i, ii] + counter * noiseMaps[5, iii, i, ii];

                            }
                        }
                        
                    }
                    //for first octave
                    else
                    {
                        for (int i = 0; i < (int)((gridSize1 - frequency1 - 1) / 4f) + 2; i++)
                        {
                            for (int ii = 0; ii < (int)((gridSize1 - frequency1 - 1) / 4f) + 2; ii++)
                            {
                                noiseMap1[i, ii] =  counter * noiseMaps[0, iii, i, ii];
                                noiseMap2[i, ii] =  counter * noiseMaps[1, iii, i, ii];
                                noiseMap3[i, ii] =  counter * noiseMaps[2, iii, i, ii];
                                noiseMap4[i, ii] =  counter * noiseMaps[3, iii, i, ii];
                                noiseMap5[i, ii] =  counter * noiseMaps[4, iii, i, ii];
                                noiseMap6[i, ii] =  counter * noiseMaps[5, iii, i, ii];
                            }
                        }
                    }

                    
                    counter = counter * fade;
                }

                

                for (int iii = 0; iii < (int)((gridSize1 - frequency1 - 1) / 4f) + 2; iii++)
                {
                    for (int ii = 0; ii < (int)((gridSize1 - frequency1 - 1) / 4f) + 2; ii++)
                    {

                        noiseMap1[iii, ii] = (noiseMap1[iii, ii] + falloffMap[iii, ii]);
                        noiseMap2[iii, ii] = (noiseMap2[iii, ii] + falloffMap[iii, ii]);
                        noiseMap3[iii, ii] = (noiseMap3[iii, ii] + falloffMap[iii, ii]);
                        noiseMap4[iii, ii] = (noiseMap4[iii, ii] + falloffMap[iii, ii]);
                        noiseMap5[iii, ii] = (noiseMap5[iii, ii] + falloffMap[iii, ii]);
                        noiseMap6[iii, ii] = (noiseMap6[iii, ii] + falloffMap[iii, ii]);


                    }

                }
                for (int i = 0; i < (int)((gridSize1 - frequency1 - 1) / 4f) + 2; i++)
                {
                    for (int ii = 0; ii < (int)((gridSize1 - frequency1 - 1) / 4f) + 2; ii++)
                    {
                        noiseMap1[i, ii] += height1;
                        noiseMap2[i, ii] += height1;
                        noiseMap3[i, ii] += height1;
                        noiseMap4[i, ii] += height1;
                        noiseMap5[i, ii] += height1;
                        noiseMap6[i, ii] += height1;
                    }
                }

                height2 = get.getHeight();
                get.setChangeP();
                
            }
            

            amplitude1 = get.getAmplitude();
            scaler = get.getScaler();


            get17.createMeshes(gridSize1, frequency1, noiseMap1, noiseMap2, noiseMap3, noiseMap4, noiseMap5, noiseMap6, amplitude1, meshHeightCurve, scaler, false);

            get17.createOcean(gridSize1, frequency1, noiseMap1, noiseMap2, noiseMap3, noiseMap4, noiseMap5, noiseMap6, amplitude1, meshHeightCurve, scaler, false);


            get.setChangeA();

        }

        
        

        apply = get.getApply();
        if (apply == true)
        {
            frequency2 = get.getFrequency2();
            get.setFrequency(frequency2);
            recreateNoise();
            get.setApply();

        }
    }

}
