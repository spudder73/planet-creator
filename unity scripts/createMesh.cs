﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createMesh : MonoBehaviour
{
    bool check;
    bool check1;

    public noiseEditor get;
    public drawOcean get2;
    public drawMap get3;
    public formMeshes get4;

    public GameObject gameObject1;
    public GameObject gameObject2;


    //forgot capital S
    void Start()
    {
        check = false;
        check1 = false;
        get = gameObject.GetComponent<noiseEditor>();
        get2 = gameObject.GetComponent<drawOcean>();
        get3 = gameObject.GetComponent<drawMap>();
        get4 = gameObject.GetComponent<formMeshes>();
    }


    public void createMeshes(int length, float[,] map, float amplitude, AnimationCurve meshHeightCurve, float scaler1, bool scale, int[,] startingPos)
    {

        if (scale)
        {
            scaler1 = get.getScaler();

            gameObject1.transform.localScale = new Vector3(scaler1 * 10, scaler1 * 10, scaler1 * 10);

        }

        else
        {
            //has to be before assignment
            if (check1)
            {
                gameObject1.GetComponent<MeshFilter>().mesh.Clear();
            }

            //doesnt work in start
            gameObject1 = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer));

            scaler1 = get.getScaler(); // forgot to add so nothing appeared

            Mesh mesh1 = get4.createPlanet(length, map, amplitude, meshHeightCurve, startingPos);
            gameObject1.GetComponent<MeshFilter>().mesh = mesh1;
            gameObject1.transform.localScale = new Vector3(scaler1 * 10, scaler1 * 10, scaler1 * 10);

            gameObject1.transform.Rotate(180, 0, 0);
            gameObject1.transform.position = new Vector3(0, 0, 0);

            MeshCollider gameObjectsMeshCollider1 = gameObject1.AddComponent<MeshCollider>();
            gameObjectsMeshCollider1.sharedMesh = mesh1;

            check1 = true;

            addMaterials(length, map, amplitude, meshHeightCurve, scaler1, startingPos);
        }
    }



    public void addMaterials(int length, float[,] map, float amplitude, AnimationCurve meshHeightCurve, float scaler1, int[,] startingPos)
    {

        Material material = Resources.Load("mat", typeof(Material)) as Material;

        Texture2D texture1 = new Texture2D(length, length);

        texture1 = get3.draw(length, map, meshHeightCurve, startingPos);

        gameObject1.GetComponent<Renderer>().material = material;
        gameObject1.GetComponent<Renderer>().material.SetTexture("_MainTex", texture1);


    }





    public void createOcean(int length, float[,] map, float amplitude, AnimationCurve meshHeightCurve, float scaler1, bool scale, int[,] startingPos)
    {

        //had get scale here


        if (scale)
        {
            scaler1 = get.getH1() * 1.5f;

            gameObject2.transform.localScale = new Vector3(scaler1 * 10, scaler1 * 10, scaler1 * 10);

        }

        else
        {

            if (check)
            {
                gameObject2.GetComponent<MeshFilter>().mesh.Clear();
            }

            gameObject2 = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer));

            scaler1 = get.getH1() * 1.5f;

            Mesh mesh2 = get4.createOcean(length, map, amplitude, meshHeightCurve, startingPos);
            gameObject2.GetComponent<MeshFilter>().mesh = mesh2;

            gameObject2.transform.localScale = new Vector3(scaler1 * 10, scaler1 * 10, scaler1 * 10);

            gameObject2.transform.Rotate(180, 0, 0);
            gameObject2.transform.position = new Vector3(0, 0, 0);

            scaler1 *= get.getH1() * 1.5f;

            check = true;
        }
    }



    public void addOceanMaterial(int length, float[,] map, float amplitude, AnimationCurve meshHeightCurve, float scaler1, int[,] startingPos)
    {
        
        Material material = Resources.Load("ocean1", typeof(Material)) as Material;

        Texture2D texture2 = new Texture2D(length, length);

        texture2 = get2.draw(length, map, meshHeightCurve, startingPos);

        gameObject2.GetComponent<Renderer>().material = material;
        gameObject2.GetComponent<Renderer>().material.SetTexture("_MainTex", texture2);
    }


}

