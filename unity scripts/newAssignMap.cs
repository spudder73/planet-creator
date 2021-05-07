using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newAssignMap : MonoBehaviour
{

    public noiseEditor get;
    public createMap1 get2;
    public createMap2 get3;
    public createMap3 get4;
    public createMap4 get5;
    public createMap5 get6;
    public drawMap get7;
    public createMesh get8;
    
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

        get = gameObject.GetComponent<noiseEditor>();
        get2 = gameObject.GetComponent<createMap1>();
        get3 = gameObject.GetComponent<createMap2>();
        get4 = gameObject.GetComponent<createMap3>();
        get5 = gameObject.GetComponent<createMap4>();
        get6 = gameObject.GetComponent<createMap5>();
        get7 = gameObject.GetComponent<drawMap>();
        get8 = gameObject.GetComponent<createMesh>();

        grid = get.getGridSize();
        amplitude = get.getAmplitude();
        octaves = get.getOctaves();
        freq = get.getFrequency();
        frequency2 = freq;
        mode = get.getMode();
        height = get.getHeight();
        persistance = get.getDetail();
        startVal = 0.7f;
        height2 = 0;

        dist = (int)((grid - freq*2) / freq);
        length = dist * freq + 2;

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
        grid = get.getGridSize();
        amplitude = get.getAmplitude();
        octaves = get.getOctaves();
        freq = get.getFrequency();
        frequency2 = freq;
        mode = get.getMode();
        height = get.getHeight();
        persistance = get.getDetail();
        startVal = 0.7f;


        //function to create final noise map
        void addOctaves()
        {

            get.setFrequency(frequency2);


            for (int i = 0; i < octaves; i++)
            {
                freq = get.getFrequency();

                map1 = get2.addPoints(length, dist, startingPos);
                map2 = get3.setDistances(length, dist, startingPos);
                map3 = get4.getRandVectors(length, dist, map1, startingPos);
                map4 = get5.dotProduct(length, dist, map2, map3, startingPos);
                map5 = get6.lerp(length, dist, i, mode, height, map2, map4, startingPos);



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
                get.setFrequency(freq * 2);


            }


            get.setFrequency(frequency2);
            
        }
        

        //create noise
        addOctaves();
        freq = get.getFrequency();

        if (!get.getChangeA())
        {
            get.setChangeA();
        }

    }


    // Update is called once per frame
    void Update()
    {
        bool changeP = get.getChangeP();
        bool changeM = get.getChangeM();
        bool changeA = get.getChangeA();
        bool changeH = get.getChangeH();
        bool changeS = get.getChangeS();
        bool changeOH = get.getChangeOH();
        bool changeC = get.getChangeC();

        scale =  get.getScaler();
        grid = get.getGridSize();
        amplitude = get.getAmplitude();
        octaves = get.getOctaves();
        freq = get.getFrequency();
        frequency2 = freq;
        mode = get.getMode();
        height = get.getHeight();
        persistance = get.getDetail();
        startVal = 0.7f;




        if (changeOH)
        {
            get8.createOcean(length, finalMap, amplitude, meshHeightCurve, scale, true, startingPos);

            get.setChangeOH();
        }

        if (changeC)
        {
            get8.addMaterials(length, finalMap, amplitude, meshHeightCurve, scale, startingPos);
            get8.addOceanMaterial(length, finalMap, amplitude, meshHeightCurve, scale, startingPos);

            get.setChangeC();
        }

        if (changeM)
        {
            recreateNoise();

            height2 = 0;
            get.setChangeH();
            changeH = true;

            get.setChangeM();
        }


        if (changeH)
        {
            for (int i = 0; i < 6; i++)
            {
                int x = startingPos[i, 0];
                int y = startingPos[i, 1];

                for (int ii = x; ii < x + length; ii++)
                {
                    for (int iii = y; iii < y + length; iii++)
                    {
                        finalMap[ii, iii] += (height - height2);
                    }
                }
            }

            height2 = height;

            if (!changeA)
            {
                get.setChangeA();
                changeA = true;
            }

            get.setChangeH();
        }

        if (changeP)
        {
            for (int i = 0; i < octaves; i++)
            {
                if (i != 0)
                {
                    for (int iv = 0; iv < 6; iv++)
                    {
                        int x = startingPos[iv, 0];
                        int y = startingPos[iv, 1];

                        for (int ii = x; ii < x + length; ii++)
                        {
                            for (int iii = y; iii < y + length; iii++)
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

                        for (int ii = x; ii < x + length; ii++)
                        {
                            for (int iii = y; iii < y + length; iii++)
                            {
                                finalMap[ii, iii] = startVal * mapOctaves[i, ii, i];
                                finalMap[ii, iii] += height;
                            }
                        }
                    }
                }



                startVal = startVal * persistance;
            }




            height2 = height;
            get.setChangeA();

            get.setChangeP();

        }

        if (changeA)
        {
            freq = freq3; // fixed big borders

            get8.createMeshes(length, finalMap, amplitude, meshHeightCurve, scale, false, startingPos);
            get8.createOcean(length, finalMap, amplitude, meshHeightCurve, scale, false, startingPos);
            get8.addOceanMaterial(length, finalMap, amplitude, meshHeightCurve, scale, startingPos);

            get.setChangeS();
            changeS = get.getChangeS();

            get.setChangeA();

        }

        if (changeS)
        {
            get8.createMeshes(length, finalMap, amplitude, meshHeightCurve, scale, true, startingPos);
            get8.createOcean(length, finalMap, amplitude, meshHeightCurve, scale, true, startingPos);

            get.setChangeS();
        }

    }

}
