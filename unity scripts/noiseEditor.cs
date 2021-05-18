using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class noiseEditor : MonoBehaviour
{
    public int gridSize;
    public int frequency;
    public int frequency2;
    public float amplitude;
    public int octaves;
    public float fade;
    public bool changeO2;
    public bool ridge;
    public bool billow;
    public bool apply;
    public bool modify;
    public float height;

    public fSliderVal frequencySlider;
    public aSliderVal amplitudeSlider;
    public gSliderVal gridSlider;
    public oSliderVal octaveSlider;
    public hSliderVal heightSlider;
    public dSliderVal persistanceSlider;
    public ddModeVal modeSelect;
    public sSliderVal sizeSlider;
    public cdModeVal colourNumberSelect;
    public chSliderVal colourHeightSlider;
    public rcSliderVal redSlider;
    public gcSliderVal greenSlider;
    public bcSliderVal blueSlider;
    public acSliderVal shadeSlider;

    public float rValue;
    public float gValue;
    public float bValue;
    public float aValue;

    public float persistance;
    public bool mode;
    public float scale;
    public int colourNo;
    public int noOfColours;
    public float colourHeight;
    float a2Val;
    int dist;
    int length;

    Color[] colours;
    float[] heights;
    newAssignMap newAssignMap;

    //set all variables
    void Start()
    {
        newAssignMap = gameObject.GetComponent<newAssignMap>();
        int temp = 1;
        a2Val = 0;
        heights = new float[5];
        colours = new Color[5];
        mode = true;
        modify = false;
        apply = false;
        height = 0f;
        gridSize = 100;
        frequency = 2;
        frequency2 = 2;
        octaves = 5;
        amplitude = 3f;
        persistance = 0.5f;
        scale = 1f;

        heights[0] = 1.25f;
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

        gridSize--;
        while (temp != 0)
        {
            gridSize++;
            temp = (gridSize) % (frequency * (int)(Mathf.Pow(2,5)));
        }
        Debug.Log(gridSize);
        

        dist = (int)((gridSize) / frequency);
        length = gridSize;

    }


    public void setFrequency(int frequency1)
    {
        frequency = frequency1;
    }



    public void randColours()
    {
        for (int i = 0; i < 5; i++)
        {
            colours[i].r = UnityEngine.Random.Range(0f, 1.0f);
            colours[i].g = UnityEngine.Random.Range(0f, 1.0f);
            colours[i].b = UnityEngine.Random.Range(0f, 1.0f);
        }
        
        newAssignMap.changeC(length, amplitude, scale);
    }

    public void changeMode()
    {
        if (mode)
        {
            mode = false;
        }
        else
        {
            mode = true;
        }

        newAssignMap.changeM(height, length, amplitude, scale);
    }

    public void newSeed()
    {
        newAssignMap.changeM(height, length, amplitude, scale);
    }


    public void changeFrequency()
    {
        frequency = frequencySlider.getFSliderVal();
        frequency2 = frequencySlider.getFSliderVal();
        newAssignMap.changeM(height, length, amplitude, scale);
    }

    public void changePersistance()
    {
        persistance = persistanceSlider.getDSliderVal();
        newAssignMap.changeP(height, octaves, length, persistance, amplitude, scale);
    }

    public void changeScaler()
    {
        float scale2 = scale;
        scale = sizeSlider.getSSliderVal();
        heights[0] *= (scale / scale2);
        newAssignMap.changeS(length, amplitude, scale);
    }

    public void changeNoOfColour()
    {
        colourNo = colourNumberSelect.getColour();
    }

    public void changeRvalue()
    {
        rValue = redSlider.getRcSliderVal();

        colours[colourNo].r = rValue;


        newAssignMap.changeC(length, amplitude, scale);

    }


    public void changeGvalue()
    {
        gValue = greenSlider.getGcSliderVal();
        colours[colourNo].g = gValue;
        newAssignMap.changeC(length, amplitude, scale);

    }

    public void changeBvalue()
    {

        bValue = blueSlider.getBcSliderVal();
        colours[colourNo].b = bValue;
        newAssignMap.changeC(length, amplitude, scale);

    }

    public void changeAvalue()
    {
        aValue = shadeSlider.getAcSliderVal();
        if (colourNo != 0)
        {

            colours[colourNo].a = aValue - a2Val;
            colours[colourNo].b += aValue - a2Val;
            colours[colourNo].g += aValue - a2Val;
            colours[colourNo].r += aValue - a2Val;
            a2Val = aValue;

        }
        else
        {
            colours[colourNo].a = aValue;

        }
        newAssignMap.changeC(length, amplitude, scale);
    }


    public void changeColourHeight()
    {
        colourHeight = colourHeightSlider.getChSliderVal();
        heights[colourNo] = colourHeight;
        if (colourNo == 0)
        {
            newAssignMap.changeOH(length, amplitude, scale);
        }
        else
        {
            newAssignMap.changeC(length, amplitude, scale);
        }

    }


    public void changeHeight()
    {
        height = heightSlider.getHSliderVal();
        newAssignMap.changeH(height, length, amplitude, scale);
    }

    public void changeOctaves()
    {
        octaves = octaveSlider.getOSliderVal();
        newAssignMap.changeP(height, octaves, length, persistance, amplitude, scale);
    }


    public void changeAmplitude()
    {
        amplitude = amplitudeSlider.getASliderVal();
        newAssignMap.changeA(length, amplitude, scale);
    }

    public void changeGridSize()
    {
        gridSize = gridSlider.getGSliderVal();
        frequency = frequency2;
        newAssignMap.changeM(height, length, amplitude, scale);
    }

    public int getLength()
    {
        return length;
    }

    public int getDist()
    {
        return dist;
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


    public float getPersistance()
    {
        return persistance;
    }

    public float getHeight()
    {
        return height;
    }

    public bool getMode()
    {
        return mode;
    }

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
    public int getOctaves()
    {
        return octaves;
    }
}