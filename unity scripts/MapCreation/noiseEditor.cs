using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class noiseEditor : MonoBehaviour
{
    // Start is called before the first frame update

    //initialize the map size
    public int gridSize;
    //initailize the frequency of the noise(the number of points + 1 per line that will be assigned a random vector)
    public int frequency;
    public int frequency2;
    //initialize the height multiplier for the noise
    public float amplitude;
    //creates variable of the total number of points that are not assigned random vectors
    //which is then used to work out the distance between each of the random vectors
    //which is then rounded
    public int distance;
    public int distance1;
    //initialize detail level
    public int octaves;
    //initialize water level
    public float waterLevel;
    //initialize the lowering rate of opacity in levels of detail
    public float fade;
    public bool changeO2;
    public bool ridge;
    public bool billow;
    public bool apply;
    public bool modify;
    public float height;
    public fSliderVal get;
    public aSliderVal get2;
    public gSliderVal get3;
    public oSliderVal get4;
    public hSliderVal get5;
    public dSliderVal get6;
    public ddModeVal get7;
    public sSliderVal get8;
    public cSliderVal get9;
    public chSliderVal get10;
    public cdModeVal get11;

    public rcSliderVal get12;
    public gcSliderVal get13;
    public bcSliderVal get14;
    public acSliderVal get15;

    public float rValue;
    public float gValue;
    public float bValue;
    public float aValue;

    public float detail;
    public int mode;
    public bool changeA;
    public bool changeH;
    public float scale;
    public bool changeP;
    public bool changeH1;
    public int colourNo;
    public int noOfColours;
    public float colourHeight;
    public bool changeT;
    float a2Val;
    public bool changeS2;
    public bool changeO;

    Color[] colours;

    float[] heights;

    //set all variables
    void Start()
    {
        a2Val = 0;
        changeT = false;
        changeS2 = false;
        changeO = false;
        changeO2 = false;
        heights = new float[5]; 
        colours = new Color[5];
        mode = 1;
        modify = false;
        apply = false;
        height = 0f;
        gridSize = 400;
        frequency = 2;
        frequency2 = 2;
        octaves = 5;
        amplitude = 3f;
        detail = 0.5f;
        scale = 1f;
        changeP = false;
        heights[0] = 1.12f;
        heights[1] = 0.9f;
        heights[2] = 0.6f;
        heights[3] = 0.2f;

        colours[0].r = 0.1226558f;
        colours[0].g = 0.5151509f;
        colours[0].b = 1f;
        colours[0].a = 0.8f;

        colours[1].r = 0.79f;
        colours[1].g = 0.74f;
        colours[1].b = 0.46f;
        colours[1].a = 0.1f;

        colours[2].r = 0.4f;
        colours[2].g = 0.65f;
        colours[2].b = 0.1f;
        colours[2].a = 0.28f;

        colours[3].r = 0.5f;
        colours[3].g = 0.5f;
        colours[3].b = 0.5f;
        colours[3].a = 0.6f;

        colours[4].r = 1;
        colours[4].g = 1;
        colours[4].b = 1;
        colours[4].a = 1;

    }


    public void randColours()
    {
        for (int i = 0; i < 5; i++)
        {
            colours[i].r = UnityEngine.Random.Range(0f, 1.0f);
            colours[i].g = UnityEngine.Random.Range(0f, 1.0f);
            colours[i].b = UnityEngine.Random.Range(0f, 1.0f);
            changeT = true;
            changeO = true;//forgot

        }
        changeA = true;
    }

    public void changeMode()
    {
        if (mode == 1)
        {
            mode = 0;
        }
        else
        {
            mode = 1;
        }

        apply = true;
        changeH1 = true;
    }

    public int getMode()
    {
        return mode;
    }

    public void changeFrequency()
    {
        frequency = get.getFSliderVal();
        frequency2 = get.getFSliderVal();
        apply = true;
    }

    public void changeDetail()
    {
        detail = get6.getDSliderVal();
        changeP = true;
        changeA = true;
    }

    public void changeScaler()
    {
        scale = get8.getSSliderVal();
        changeS2 = true;
    }



    public float getH1()
    {
        return heights[0];
    }

    public float getH2()
    {
        return heights[1];
    }

    public float getH3()
    {
        return heights[2];
    }

    public float getH4()
    {
        return heights[3];
    }

    public float getH5()
    {
        return heights[4];
    }

    public Color getColour1()
    {
        return colours[0];
    }

    public Color getColour2()
    {
        return colours[1];
    }

    public Color getColour3()
    {
        return colours[2];
    }

    public Color getColour4()
    {
        return colours[3];
    }

    public Color getColour5()
    {
        return colours[4];
    }


    public void changeNoOfColour()
    {
        noOfColours = get9.getCSliderVal();
    }

    public void changeRvalue()
    {
        rValue = get12.getRcSliderVal();

        colours[colourNo].r = rValue;

        if (colourNo != 0)
        {
            changeT = true;
        }
        else
        {
            changeO = true;
        }

        changeA = true;
    }

    public bool getChangeT()
    {
        return changeT;
    }

    public void changeGvalue()
    {
        gValue = get13.getGcSliderVal();
        colours[colourNo].g = gValue;
        if (colourNo != 0)
        {
            changeT = true;
        }
        else
        {
            changeO = true;
        }
        changeA = true;
    }

    public void changeBvalue()
    {

        bValue = get14.getBcSliderVal();
        colours[colourNo].b = bValue;

        if (colourNo != 0)
        {
            changeT = true;
        }
        else
        {
            changeO = true;
        }
        changeA = true;
    }

    public void changeAvalue()
    {
        aValue = get15.getAcSliderVal();
        if (colourNo != 0)
        {
            
            colours[colourNo].a = aValue - a2Val;
            colours[colourNo].b += aValue - a2Val;
            colours[colourNo].g += aValue - a2Val;
            colours[colourNo].r += aValue - a2Val;
            a2Val = aValue;
            changeT = true;
        }
        else
        {
            colours[colourNo].a = aValue;
            changeO = true;
        }
        changeA = true;
    }


    public void changeColourHeight()
    {
        colourHeight = get10.getChSliderVal();
        heights[colourNo] = colourHeight;
        if (colourNo != 0)
        {
            changeT = true;
        }
        else
        {
            changeO2 = true;
        }
        changeA = true;
    }

    public bool getChangeO()
    {
        return changeO;
    }

    public void setChangeO()
    {
        if (changeO)
        {
            changeO = false;
        }
    }

    public bool getChangeO2()
    {
        return changeO2;
    }

    public void setChangeO2()
    {
        if (changeO2)
        {
            changeO2 = false;
        }
    }

    public bool getChangeS2()
    {
        return changeS2;
    }

    public void setChangeS2()
    {
        if (changeS2)
        {
            changeS2 = false;
        }
    }

    public void changeHeight()
    {
        height = get5.getHSliderVal();
        changeH = true;
        changeA = true;
    }

    public float getDetail()
    {
        return detail;
    }

    public float getHeight()
    {
        return height;
    }

    public bool getModify()
    {
        return modify;
    }

    public void setModify(bool val)
    {
        modify = val;
    }

    public void changeOctaves()
    {
        octaves = get4.getOSliderVal();
        apply = true;
        changeH1 = true;
    }

    public void changeColourNo()
    {
        colourNo = get11.getColour();
    }

    public void changeAmplitude()
    {
        amplitude = get2.getASliderVal();
        changeA = true;
    }


    public void changeGridSize()
    {
        gridSize = get3.getGSliderVal();
        frequency = frequency2;
        apply = true;
        changeH1 = true;
    }

    public bool getChangeA()
    {
        return changeA;
    }

    public bool getChangeH1()
    {
        return changeH1;
    }

    public bool getChangeP()
    {
        return changeP;
    }

    public bool getChangeH()
    {
        return changeH;
    }


    public bool getRidge()
    {
        return ridge;
    }

    public bool getBillow()
    {
        return billow;
    }


    public bool getApply()
    {
        return apply;
    }

    public void setApply()
    {
        if (apply == true)
        {
            apply = false;
        }
        else
        {
            apply = true;
        }
        changeH1 = true;
    }

    public void setChangeT()
    {
        if (changeT == true)
        {
            changeT = false;
        }
    }

    public void setChangeP()
    {
        if (changeP == true)
        {
            changeP = false;
        }
        else
        {
            changeP = true;
        }
    }

    public void setChangeH1()
    {
        if (changeH1 == true)
        {
            changeH1 = false;
        }
        else
        {
            changeH1 = true;
        }
    }

    public void setChangeH()
    {
        if (changeH == true)
        {
            changeH = false;
        }
        else
        {
            changeH = true;
        }
    }








    //get functions
    public int getGridSize()
    {
        return gridSize;
    }
    public float getScaler()
    {
        return scale;
    }
    public int getFrequency()
    {
        return frequency;
    }
    public int getFrequency2()
    {
        return frequency2;
    }
    public float getAmplitude()
    {
        return amplitude;
    }
    public int getDistance()
    {
        return (Convert.ToInt32(Mathf.Floor(((int)((gridSize - frequency - 1) / 4f) + 2 - 2 - (frequency - 1)) / frequency))); ;
    }
    public int getDistance1()
    {
        return (Convert.ToInt32(Mathf.Floor(((int)((gridSize - frequency - 1) / 4f) + 2 - 1 - (frequency)) / frequency)));
    }
    public int getOctaves()
    {
        return octaves;
    }
    public float getWaterLevel()
    {
        return waterLevel;
    }

    public void setFrequency(int frequency1)
    {
        frequency = frequency1;
    }
    public void setChangeA()
    {
        if (changeA == true)
        {
            changeA = false;
        }
        else
        {
            changeA = true;
        }
    }
    public void setOctaves(int octaves1)
    {
        octaves = octaves1;
    }
    public void setGridSize(int gridSize1)
    {
        gridSize = gridSize1;
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
