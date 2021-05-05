using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createMesh : MonoBehaviour
{
    noiseEditor get;
    formMeshes get14;
    drawMap get6;
    drawOcean get7;
    public Mesh mesh;
    public Mesh mesh2;
    public Mesh mesh3;
    public Mesh mesh4;
    public Mesh mesh5;
    public Mesh mesh6;
    bool check;
    bool check1;
    public Mesh mesh7;
    public Mesh mesh12;
    public Mesh mesh13;
    public Mesh mesh14;
    public Mesh mesh15;
    public Mesh mesh16;
    public Mesh mesh17;

    Texture2D texture1;
    Texture2D texture2;
    Texture2D texture3;
    Texture2D texture4;
    Texture2D texture5;
    Texture2D texture6;
    Texture2D texture11;
    Texture2D texture12;
    Texture2D texture13;
    Texture2D texture14;
    Texture2D texture15;
    Texture2D texture16;

    MeshCollider gameObjectsMeshCollider1;
    MeshCollider gameObjectsMeshCollider2;
    MeshCollider gameObjectsMeshCollider3;
    MeshCollider gameObjectsMeshCollider4;
    MeshCollider gameObjectsMeshCollider5;
    MeshCollider gameObjectsMeshCollider6;

    falloff get10;
    public GameObject gameObject2;
    public GameObject gameObject3;
    public GameObject gameObject4;
    public GameObject gameObject5;
    public GameObject gameObject6;
    public GameObject gameObject7;

    public GameObject gameObject12;
    public GameObject gameObject13;
    public GameObject gameObject14;
    public GameObject gameObject15;
    public GameObject gameObject16;
    int counter;
    public GameObject gameObject17;

    float[,] falloffMap;

    //forgot capital S
    void Start()
    {
        check = false;
        check1 = false;
        int counter = 0;
        get = gameObject.GetComponent<noiseEditor>();
        get7 = gameObject.GetComponent<drawOcean>();
        get6 = gameObject.GetComponent<drawMap>();
        get14 = gameObject.GetComponent<formMeshes>();


    }


    public void createMeshes(int gridSize, int frequency, float[,] noiseMap11, float[,] noiseMap12, float[,] noiseMap13, float[,] noiseMap14, float[,] noiseMap15, float[,] noiseMap16, float amplitude, AnimationCurve meshHeightCurve, float scaler1, bool scale)
    {

        if (scale)
        {
            scaler1 = get.getScaler();

            void resize(GameObject obj)
            {
                obj.transform.localScale = new Vector3(scaler1 * 10, scaler1 * 10, scaler1 * 10);
            }

            resize(gameObject2);
            resize(gameObject3);
            resize(gameObject4);
            resize(gameObject5);
            resize(gameObject6);
            resize(gameObject7);

        }

        else
        {
            //has to be before assignment
            if (check1 == true)
            {
                gameObject2.GetComponent<MeshFilter>().mesh.Clear();
                gameObject3.GetComponent<MeshFilter>().mesh.Clear();
                gameObject4.GetComponent<MeshFilter>().mesh.Clear();
                gameObject5.GetComponent<MeshFilter>().mesh.Clear();
                gameObject6.GetComponent<MeshFilter>().mesh.Clear();
                gameObject7.GetComponent<MeshFilter>().mesh.Clear();
            }

            //doesnt work in start
            gameObject2 = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer));
            gameObject3 = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer));
            gameObject4 = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer));
            gameObject5 = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer));
            gameObject6 = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer));
            gameObject7 = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer));


            scaler1 = get.getScaler(); // forgot to add so nothing appeared

            void meshSide(Mesh mesh, float[,] map, string side, GameObject obj, MeshCollider colObj)
            {
                


                //call mesh creator function on the noise map created
                mesh = get14.createPlanet(gridSize, frequency, map, amplitude, meshHeightCurve, side);
                //mesh = get8.assignMesh(gridSize, frequency, finalnoiseMap1, amplitude, meshHeightCurve);
                //create mesh from data created
                obj.GetComponent<MeshFilter>().mesh = mesh;

                //modify mesh
                //(int)((gridSize - frequency - 1) / 4f)

                obj.transform.localScale = new Vector3(scaler1 * 10, scaler1 * 10, scaler1 * 10);

                obj.transform.Rotate(180, 0, 0);
                obj.transform.position = new Vector3(0, 0, 0);

                colObj = obj.AddComponent<MeshCollider>(); // Add the rigidbody.
                colObj.sharedMesh = mesh;
            }

            meshSide(mesh2, noiseMap11, "top", gameObject2, gameObjectsMeshCollider1);
            meshSide(mesh3, noiseMap12, "bottom", gameObject3, gameObjectsMeshCollider2);
            meshSide(mesh4, noiseMap13, "right", gameObject4, gameObjectsMeshCollider3);
            meshSide(mesh5, noiseMap14, "left", gameObject5, gameObjectsMeshCollider4);
            meshSide(mesh6, noiseMap15, "front", gameObject6, gameObjectsMeshCollider5);
            meshSide(mesh7, noiseMap16, "back", gameObject7, gameObjectsMeshCollider6);

            check1 = true;

            addMaterials(gridSize, frequency, noiseMap11, noiseMap12, noiseMap13, noiseMap14, noiseMap15, noiseMap16, amplitude, meshHeightCurve, scaler1);
        }
    }



    public void addMaterials(int gridSize, int frequency, float[,] noiseMap11, float[,] noiseMap12, float[,] noiseMap13, float[,] noiseMap14, float[,] noiseMap15, float[,] noiseMap16, float amplitude, AnimationCurve meshHeightCurve, float scaler1)
    {
        

        void texSide(Material mat, Texture2D texture, GameObject obj, float[,] map)
        {
            //create texture object
            texture = new Texture2D(((int)(gridSize - frequency - 1) / 4) + 2, ((int)(gridSize - frequency - 1) / 4) + 2);
            //call texture creator from noise map created
            texture = get6.draw(gridSize, frequency, map, meshHeightCurve);

            //set no wrap
            //texture.wrapMode = TextureWrapMode.Clamp;
            //apply texture to mesh and render texture
            obj.GetComponent<Renderer>().material = mat;
            obj.GetComponent<Renderer>().material.SetTexture("_MainTex", texture);
        }

        //get blank material
        Material material = Resources.Load("mat", typeof(Material)) as Material;

        texSide(material, texture1, gameObject2, noiseMap11);
        texSide(material, texture2, gameObject3, noiseMap12);
        texSide(material, texture3, gameObject4, noiseMap13);
        texSide(material, texture4, gameObject5, noiseMap14);
        texSide(material, texture5, gameObject6, noiseMap15);
        texSide(material, texture6, gameObject7, noiseMap16);

    }





    public void createOcean(int gridSize, int frequency, float[,] noiseMap11, float[,] noiseMap12, float[,] noiseMap13, float[,] noiseMap14, float[,] noiseMap15, float[,] noiseMap16, float amplitude, AnimationCurve meshHeightCurve, float scaler1, bool scale)
    {

        //had get scale here


        if (scale)
        {
            scaler1 = get.getH1() * 1.5f;

            void resize(GameObject obj)
            {
                obj.transform.localScale = new Vector3(scaler1 * 10, scaler1 * 10, scaler1 * 10);
            }

            resize(gameObject12);
            resize(gameObject13);
            resize(gameObject14);
            resize(gameObject15);
            resize(gameObject16);
            resize(gameObject17);

        }

        else
        {

            if (check == true)
            {
                gameObject12.GetComponent<MeshFilter>().mesh.Clear();
                gameObject13.GetComponent<MeshFilter>().mesh.Clear();
                gameObject14.GetComponent<MeshFilter>().mesh.Clear();
                gameObject15.GetComponent<MeshFilter>().mesh.Clear();
                gameObject16.GetComponent<MeshFilter>().mesh.Clear();
                gameObject17.GetComponent<MeshFilter>().mesh.Clear();
            }

            gameObject12 = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer));
            gameObject13 = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer));
            gameObject14 = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer));
            gameObject15 = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer));
            gameObject16 = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer));
            gameObject17 = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer));

            scaler1 = get.getH1() * 1.5f;


            void oceanSide(Mesh mesh1, float[,] map, string side, GameObject obj)
            {

                //call mesh creator function on the noise map created
                mesh1 = (Mesh)get14.createOcean(gridSize, frequency, map, amplitude, meshHeightCurve, side);
                //mesh = get8.assignMesh(gridSize, frequency, finalnoiseMap1, amplitude, meshHeightCurve);
                //create mesh from data created
                obj.GetComponent<MeshFilter>().mesh = mesh1;

                //modify mesh

                //(int)((gridSize - frequency - 1) / 4f)

                obj.transform.localScale = new Vector3(scaler1 * 10, scaler1 * 10, scaler1 * 10);

                obj.transform.Rotate(180, 0, 0);
                obj.transform.position = new Vector3(0, 0, 0);

            }

            scaler1 *= get.getH1() * 1.5f;

            oceanSide(mesh12, noiseMap11, "top", gameObject12);
            oceanSide(mesh13, noiseMap12, "bottom", gameObject13);
            oceanSide(mesh14, noiseMap13, "left", gameObject14);
            oceanSide(mesh15, noiseMap14, "right", gameObject15);
            oceanSide(mesh16, noiseMap15, "front", gameObject16);
            oceanSide(mesh17, noiseMap16, "back", gameObject17);

            check = true;

            //didnt work in start
        }
    }



    public void addOceanMaterial(int gridSize, int frequency, float[,] noiseMap11, float[,] noiseMap12, float[,] noiseMap13, float[,] noiseMap14, float[,] noiseMap15, float[,] noiseMap16, float amplitude, AnimationCurve meshHeightCurve, float scaler1)
    {
        

        void texOcean(Material mat, Texture2D texture, GameObject obj, float[,] map, string side)
        {
            //create texture object
            texture = new Texture2D(((int)(gridSize - frequency - 1) / 4) + 2, ((int)(gridSize - frequency - 1) / 4) + 2);
            //call texture creator from noise map created
            texture = (Texture2D)get7.draw(gridSize, frequency, map, meshHeightCurve);

            //set no wrap
            //texture.wrapMode = TextureWrapMode.Clamp;
            //apply texture to mesh and render texture
            obj.GetComponent<Renderer>().material = mat;
            obj.GetComponent<Renderer>().material.SetTexture("_MainTex", texture);
        }

        //get blank material
        Material material1 = Resources.Load("ocean1", typeof(Material)) as Material;

        texOcean(material1, texture11, gameObject12, noiseMap11, "top");
        texOcean(material1, texture12, gameObject13, noiseMap12, "bottom");
        texOcean(material1, texture13, gameObject14, noiseMap14, "left");
        texOcean(material1, texture14, gameObject15, noiseMap13, "right");
        texOcean(material1, texture15, gameObject16, noiseMap15, "front");
        texOcean(material1, texture16, gameObject17, noiseMap16, "back");

        //used to have get color here
    }


}

