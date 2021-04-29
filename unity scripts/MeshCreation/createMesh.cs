using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createMesh : MonoBehaviour
{
    noiseEditor get;
    SMRight get14;
    drawMap get6;
    

    Mesh mesh;
    Mesh mesh2;
    Mesh mesh3;
    Mesh mesh4;
    Mesh mesh5;
    Mesh mesh6;
    bool check;
    bool check1;
    Mesh mesh7;

    Mesh mesh12;
    Mesh mesh13;
    Mesh mesh14;
    Mesh mesh15;
    Mesh mesh16;
    Mesh mesh17;


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
        get6 = gameObject.GetComponent<drawMap>();
        get14 = gameObject.GetComponent<SMRight>();

        gameObject2 = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer));
        gameObject3 = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer));
        gameObject4 = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer));
        gameObject5 = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer));
        gameObject6 = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer));
        gameObject7 = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer));

        gameObject2.gameObject.tag = "Planet";

        string ScriptName = "move2";
        System.Type MyScriptType = System.Type.GetType(ScriptName + ",Assembly-CSharp");
        gameObject2.AddComponent(MyScriptType);

    }


    public void createMeshes(int gridSize, int frequency, float[,] noiseMap11, float[,] noiseMap12, float[,] noiseMap13, float[,] noiseMap14, float[,] noiseMap15, float[,] noiseMap16, float amplitude, AnimationCurve meshHeightCurve, float scaler1, bool scale)
    {
        if (scale)
        {
            gameObject2.transform.localScale = new Vector3(scaler1 * 10, scaler1 * 10, scaler1 * 10);
            gameObject3.transform.localScale = new Vector3(scaler1 * 10, scaler1 * 10, scaler1 * 10);
            gameObject4.transform.localScale = new Vector3(scaler1 * 10, scaler1 * 10, scaler1 * 10);
            gameObject5.transform.localScale = new Vector3(scaler1 * 10, scaler1 * 10, scaler1 * 10);
            gameObject6.transform.localScale = new Vector3(scaler1 * 10, scaler1 * 10, scaler1 * 10);
            gameObject7.transform.localScale = new Vector3(scaler1 * 10, scaler1 * 10, scaler1 * 10);
            createOcean(gridSize, frequency, noiseMap11, noiseMap12, noiseMap13, noiseMap14, noiseMap15, noiseMap16, amplitude, meshHeightCurve, scaler1, true);
        }

        else
        {

            if (check == true)
            {
                mesh2.Clear();
                mesh3.Clear();
                mesh4.Clear();
                mesh5.Clear();
                mesh6.Clear();
                mesh7.Clear();
            }
            check = true;

            
            /*
            Rigidbody gameObjectsRigidBody1 = gameObject2.AddComponent<Rigidbody>(); // Add the rigidbody.
            gameObjectsRigidBody1.mass = 5;
            Rigidbody gameObjectsRigidBody2 = gameObject3.AddComponent<Rigidbody>(); // Add the rigidbody.
            gameObjectsRigidBody2.mass = 5;
            Rigidbody gameObjectsRigidBody3 = gameObject4.AddComponent<Rigidbody>(); // Add the rigidbody.
            gameObjectsRigidBody3.mass = 5;
            Rigidbody gameObjectsRigidBody4 = gameObject5.AddComponent<Rigidbody>(); // Add the rigidbody.
            gameObjectsRigidBody4.mass = 5;
            Rigidbody gameObjectsRigidBody5 = gameObject6.AddComponent<Rigidbody>(); // Add the rigidbody.
            gameObjectsRigidBody5.mass = 5;
            Rigidbody gameObjectsRigidBody6 = gameObject7.AddComponent<Rigidbody>(); // Add the rigidbody.
            gameObjectsRigidBody6.mass = 5;
            */
            gameObject2.layer = 8;
            gameObject3.layer = 8;
            gameObject4.layer = 8;
            gameObject5.layer = 8;
            gameObject6.layer = 8;
            gameObject7.layer = 8;

            


            //call mesh creator function on the noise map created
            mesh2 = (Mesh)get14.createCubeRight(gridSize, frequency, noiseMap11, amplitude, meshHeightCurve, false, "top", false);
            //mesh = get8.assignMesh(gridSize, frequency, finalnoiseMap1, amplitude, meshHeightCurve);
            //create mesh from data created
            gameObject2.GetComponent<MeshFilter>().mesh = mesh2;

            //modify mesh

            //(int)((gridSize - frequency - 1) / 4f)

            gameObject2.transform.localScale = new Vector3(scaler1 * 10, scaler1 * 10, scaler1 * 10);

            gameObject2.transform.Rotate(180, 0, 0);
            gameObject2.transform.position = new Vector3(0, 0, 0);





            //call mesh creator function on the noise map created
            mesh3 = (Mesh)get14.createCubeRight(gridSize, frequency, noiseMap12, amplitude, meshHeightCurve, false, "bottom", false);
            //mesh = get8.assignMesh(gridSize, frequency, finalnoiseMap1, amplitude, meshHeightCurve);
            //create mesh from data created
            gameObject3.GetComponent<MeshFilter>().mesh = mesh3;

            //modify mesh

            //(int)((gridSize - frequency - 1) / 4f)

            gameObject3.transform.localScale = new Vector3(scaler1 * 10, scaler1 * 10, scaler1 * 10);

            gameObject3.transform.Rotate(180, 0, 0);
            gameObject3.transform.position = new Vector3(0, 0, 0);





            //call mesh creator function on the noise map created
            mesh4 = (Mesh)get14.createCubeRight(gridSize, frequency, noiseMap13, amplitude, meshHeightCurve, false, "left", false);
            //mesh = get8.assignMesh(gridSize, frequency, finalnoiseMap1, amplitude, meshHeightCurve);
            //create mesh from data created
            gameObject4.GetComponent<MeshFilter>().mesh = mesh4;

            //modify mesh

            //(int)((gridSize - frequency - 1) / 4f)

            gameObject4.transform.localScale = new Vector3(scaler1 * 10, scaler1 * 10, scaler1 * 10);

            gameObject4.transform.Rotate(180, 0, 0);
            gameObject4.transform.position = new Vector3(0, 0, 0);





            //call mesh creator function on the noise map created
            mesh5 = (Mesh)get14.createCubeRight(gridSize, frequency, noiseMap14, amplitude, meshHeightCurve, false, "right", false);
            //mesh = get8.assignMesh(gridSize, frequency, finalnoiseMap1, amplitude, meshHeightCurve);
            //create mesh from data created
            gameObject5.GetComponent<MeshFilter>().mesh = mesh5;

            //modify mesh

            //(int)((gridSize - frequency - 1) / 4f)

            gameObject5.transform.localScale = new Vector3(scaler1 * 10, scaler1 * 10, scaler1 * 10);

            gameObject5.transform.Rotate(180, 0, 0);
            gameObject5.transform.position = new Vector3(0, 0, 0);





            //call mesh creator function on the noise map created
            mesh6 = (Mesh)get14.createCubeRight(gridSize, frequency, noiseMap15, amplitude, meshHeightCurve, false, "front", false);
            //mesh = get8.assignMesh(gridSize, frequency, finalnoiseMap1, amplitude, meshHeightCurve);
            //create mesh from data created
            gameObject6.GetComponent<MeshFilter>().mesh = mesh6;

            //modify mesh

            //(int)((gridSize - frequency - 1) / 4f)

            gameObject6.transform.localScale = new Vector3(scaler1 * 10, scaler1 * 10, scaler1 * 10);

            gameObject6.transform.Rotate(180, 0, 0);
            gameObject6.transform.position = new Vector3(0, 0, 0);






            //call mesh creator function on the noise map created
            mesh7 = (Mesh)get14.createCubeRight(gridSize, frequency, noiseMap16, amplitude, meshHeightCurve, false, "back", false);
            //mesh = get8.assignMesh(gridSize, frequency, finalnoiseMap1, amplitude, meshHeightCurve);
            //create mesh from data created
            gameObject7.GetComponent<MeshFilter>().mesh = mesh7; //missed

            //modify mesh

            //(int)((gridSize - frequency - 1) / 4f)

            gameObject7.transform.localScale = new Vector3(scaler1 * 10, scaler1 * 10, scaler1 * 10);

            gameObject7.transform.Rotate(180, 0, 0);
            gameObject7.transform.position = new Vector3(0, 0, 0);


            MeshCollider gameObjectsMeshCollider1 = gameObject2.AddComponent<MeshCollider>(); // Add the rigidbody.
            gameObjectsMeshCollider1.sharedMesh = mesh2;
            MeshCollider gameObjectsMeshCollider2 = gameObject3.AddComponent<MeshCollider>(); // Add the rigidbody.
            gameObjectsMeshCollider2.sharedMesh = mesh3;
            MeshCollider gameObjectsMeshCollider3 = gameObject4.AddComponent<MeshCollider>(); // Add the rigidbody.
            gameObjectsMeshCollider3.sharedMesh = mesh4;
            MeshCollider gameObjectsMeshCollider4 = gameObject5.AddComponent<MeshCollider>(); // Add the rigidbody.
            gameObjectsMeshCollider4.sharedMesh = mesh5;
            MeshCollider gameObjectsMeshCollider5 = gameObject6.AddComponent<MeshCollider>(); // Add the rigidbody.
            gameObjectsMeshCollider5.sharedMesh = mesh6;
            MeshCollider gameObjectsMeshCollider6 = gameObject7.AddComponent<MeshCollider>(); // Add the rigidbody.
            gameObjectsMeshCollider6.sharedMesh = mesh7;
            /*
            gameObjectsRigidBody1.useGravity = false;
            gameObjectsRigidBody2.useGravity = false;
            gameObjectsRigidBody3.useGravity = false;
            gameObjectsRigidBody4.useGravity = false;
            gameObjectsRigidBody5.useGravity = false;
            gameObjectsRigidBody6.useGravity = false;

            gameObjectsRigidBody1.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX ;
            gameObjectsRigidBody2.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX;
            gameObjectsRigidBody3.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX;
            gameObjectsRigidBody4.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX;
            gameObjectsRigidBody5.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX;
            gameObjectsRigidBody6.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX;
            */
            addMaterials(gridSize, frequency, noiseMap11, noiseMap12, noiseMap13, noiseMap14, noiseMap15, noiseMap16, amplitude, meshHeightCurve, scaler1);
        }
    }





    public void addMaterials(int gridSize, int frequency, float[,] noiseMap11, float[,] noiseMap12, float[,] noiseMap13, float[,] noiseMap14, float[,] noiseMap15, float[,] noiseMap16, float amplitude, AnimationCurve meshHeightCurve, float scaler1)
    {


        //get blank material
        Material material1 = Resources.Load("mat", typeof(Material)) as Material;

        //create texture object
        Texture2D texture1 = new Texture2D(((int)(gridSize - frequency - 1) / 4) + 2, ((int)(gridSize - frequency - 1) / 4) + 2);
        //call texture creator from noise map created
        texture1 = get6.draw(gridSize, frequency, noiseMap11, meshHeightCurve);

        //set no wrap
        texture1.wrapMode = TextureWrapMode.Clamp;
        //apply texture to mesh and render texture
        gameObject2.GetComponent<Renderer>().material = material1;
        gameObject2.GetComponent<Renderer>().material.SetTexture("_MainTex", texture1);

        //get blank material
        Material material2 = Resources.Load("mat", typeof(Material)) as Material;

        //create texture object
        Texture2D texture2 = new Texture2D(((int)(gridSize - frequency - 1) / 4) + 2, ((int)(gridSize - frequency - 1) / 4) + 2);
        //call texture creator from noise map created
        texture2 = get6.draw(gridSize, frequency, noiseMap12, meshHeightCurve);

        //set no wrap
        texture2.wrapMode = TextureWrapMode.Clamp;
        //apply texture to mesh and render texture
        gameObject3.GetComponent<Renderer>().material = material2;
        gameObject3.GetComponent<Renderer>().material.SetTexture("_MainTex", texture2);


        //get blank material
        Material material3 = Resources.Load("mat", typeof(Material)) as Material;

        //create texture object
        Texture2D texture3 = new Texture2D(((int)(gridSize - frequency - 1) / 4) + 2, ((int)(gridSize - frequency - 1) / 4) + 2);
        //call texture creator from noise map created
        texture3 = get6.draw(gridSize, frequency, noiseMap13, meshHeightCurve);

        //set no wrap
        texture3.wrapMode = TextureWrapMode.Clamp;
        //apply texture to mesh and render texture
        gameObject4.GetComponent<Renderer>().material = material3;
        gameObject4.GetComponent<Renderer>().material.SetTexture("_MainTex", texture3);


        //get blank material
        Material material4 = Resources.Load("mat", typeof(Material)) as Material;

        //create texture object
        Texture2D texture4 = new Texture2D(((int)(gridSize - frequency - 1) / 4) + 2, ((int)(gridSize - frequency - 1) / 4) + 2);
        //call texture creator from noise map created
        texture4 = get6.draw(gridSize, frequency, noiseMap14, meshHeightCurve);

        //set no wrap
        texture4.wrapMode = TextureWrapMode.Clamp;
        //apply texture to mesh and render texture
        gameObject5.GetComponent<Renderer>().material = material4;
        gameObject5.GetComponent<Renderer>().material.SetTexture("_MainTex", texture4);


        //get blank material
        Material material5 = Resources.Load("mat", typeof(Material)) as Material;

        //create texture object
        Texture2D texture5 = new Texture2D(((int)(gridSize - frequency - 1) / 4) + 2, ((int)(gridSize - frequency - 1) / 4) + 2);
        //call texture creator from noise map created
        texture5 = get6.draw(gridSize, frequency, noiseMap15, meshHeightCurve);

        //set no wrap
        texture5.wrapMode = TextureWrapMode.Clamp;
        //apply texture to mesh and render texture
        gameObject6.GetComponent<Renderer>().material = material5;
        gameObject6.GetComponent<Renderer>().material.SetTexture("_MainTex", texture5);


        //get blank material
        Material material6 = Resources.Load("mat", typeof(Material)) as Material;

        //create texture object
        Texture2D texture6 = new Texture2D(((int)(gridSize - frequency - 1) / 4) + 2, ((int)(gridSize - frequency - 1) / 4) + 2);
        //call texture creator from noise map created
        texture6 = get6.draw(gridSize, frequency, noiseMap16, meshHeightCurve);

        //set no wrap
        texture6.wrapMode = TextureWrapMode.Clamp;
        //apply texture to mesh and render texture
        gameObject7.GetComponent<Renderer>().material = material6;
        gameObject7.GetComponent<Renderer>().material.SetTexture("_MainTex", texture6);
    }





    public void createOcean(int gridSize, int frequency, float[,] noiseMap11, float[,] noiseMap12, float[,] noiseMap13, float[,] noiseMap14, float[,] noiseMap15, float[,] noiseMap16, float amplitude, AnimationCurve meshHeightCurve, float scaler1, bool scale)
    {

        //hade get scale here
        if (scale == true)
        {
            
            scaler1 *= get.getH1() * 1.5f;
            gameObject12.transform.localScale = new Vector3(scaler1 * 10, scaler1 * 10, scaler1 * 10);
            gameObject13.transform.localScale = new Vector3(scaler1 * 10, scaler1 * 10, scaler1 * 10);
            gameObject14.transform.localScale = new Vector3(scaler1 * 10, scaler1 * 10, scaler1 * 10);
            gameObject15.transform.localScale = new Vector3(scaler1 * 10, scaler1 * 10, scaler1 * 10);
            gameObject16.transform.localScale = new Vector3(scaler1 * 10, scaler1 * 10, scaler1 * 10);
            gameObject17.transform.localScale = new Vector3(scaler1 * 10, scaler1 * 10, scaler1 * 10);

        }
        else
        {
            gameObject12 = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer));
            gameObject13 = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer));
            gameObject14 = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer));
            gameObject15 = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer));
            gameObject16 = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer));
            gameObject17 = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer));
            //didnt work in start

            scaler1 *= get.getH1() * 1.5f;
            if (check1 == true)
            {
                mesh12.Clear();
                mesh13.Clear();
                mesh14.Clear();
                mesh15.Clear();
                mesh16.Clear();
                mesh17.Clear();
            }
            check1 = true;



            //call mesh creator function on the noise map created
            mesh12 = (Mesh)get14.createCubeRight(gridSize, frequency, noiseMap11, amplitude, meshHeightCurve, true, "top", false);
            //mesh = get8.assignMesh(gridSize, frequency, finalnoiseMap1, amplitude, meshHeightCurve);
            //create mesh from data created
            gameObject12.GetComponent<MeshFilter>().mesh = mesh12;

            //modify mesh

            //(int)((gridSize - frequency - 1) / 4f)

            gameObject12.transform.localScale = new Vector3(scaler1 * 10, scaler1 * 10, scaler1 * 10);

            gameObject12.transform.Rotate(180, 0, 0);
            gameObject12.transform.position = new Vector3(0, 0, 0);





            //call mesh creator function on the noise map created
            mesh13 = (Mesh)get14.createCubeRight(gridSize, frequency, noiseMap12, amplitude, meshHeightCurve, true, "bottom", false);
            //mesh = get8.assignMesh(gridSize, frequency, finalnoiseMap1, amplitude, meshHeightCurve);
            //create mesh from data created
            gameObject13.GetComponent<MeshFilter>().mesh = mesh13;

            //modify mesh

            //(int)((gridSize - frequency - 1) / 4f)

            gameObject13.transform.localScale = new Vector3(scaler1 * 10, scaler1 * 10, scaler1 * 10);

            gameObject13.transform.Rotate(180, 0, 0);
            gameObject13.transform.position = new Vector3(0, 0, 0);





            //call mesh creator function on the noise map created
            mesh14 = (Mesh)get14.createCubeRight(gridSize, frequency, noiseMap13, amplitude, meshHeightCurve, true, "left", false);
            //mesh = get8.assignMesh(gridSize, frequency, finalnoiseMap1, amplitude, meshHeightCurve);
            //create mesh from data created
            gameObject14.GetComponent<MeshFilter>().mesh = mesh14;

            //modify mesh

            //(int)((gridSize - frequency - 1) / 4f)

            gameObject14.transform.localScale = new Vector3(scaler1 * 10, scaler1 * 10, scaler1 * 10);

            gameObject14.transform.Rotate(180, 0, 0);
            gameObject14.transform.position = new Vector3(0, 0, 0);





            //call mesh creator function on the noise map created
            mesh15 = (Mesh)get14.createCubeRight(gridSize, frequency, noiseMap14, amplitude, meshHeightCurve, true, "right", false);
            //mesh = get8.assignMesh(gridSize, frequency, finalnoiseMap1, amplitude, meshHeightCurve);
            //create mesh from data created
            gameObject15.GetComponent<MeshFilter>().mesh = mesh15;

            //modify mesh

            //(int)((gridSize - frequency - 1) / 4f)

            gameObject15.transform.localScale = new Vector3(scaler1 * 10, scaler1 * 10, scaler1 * 10);

            gameObject15.transform.Rotate(180, 0, 0);
            gameObject15.transform.position = new Vector3(0, 0, 0);





            //call mesh creator function on the noise map created
            mesh16 = (Mesh)get14.createCubeRight(gridSize, frequency, noiseMap15, amplitude, meshHeightCurve, true, "front", false);
            //mesh = get8.assignMesh(gridSize, frequency, finalnoiseMap1, amplitude, meshHeightCurve);
            //create mesh from data created
            gameObject16.GetComponent<MeshFilter>().mesh = mesh16;

            //modify mesh

            //(int)((gridSize - frequency - 1) / 4f)

            gameObject16.transform.localScale = new Vector3(scaler1 * 10, scaler1 * 10, scaler1 * 10);

            gameObject16.transform.Rotate(180, 0, 0);
            gameObject16.transform.position = new Vector3(0, 0, 0);






            //call mesh creator function on the noise map created
            mesh17 = (Mesh)get14.createCubeRight(gridSize, frequency, noiseMap16, amplitude, meshHeightCurve, true, "back", false);
            //mesh = get8.assignMesh(gridSize, frequency, finalnoiseMap1, amplitude, meshHeightCurve);
            //create mesh from data created
            gameObject17.GetComponent<MeshFilter>().mesh = mesh17; //missed

            //modify mesh

            //(int)((gridSize - frequency - 1) / 4f)

            gameObject17.transform.localScale = new Vector3(scaler1 * 10, scaler1 * 10, scaler1 * 10);

            gameObject17.transform.Rotate(180, 0, 0);
            gameObject17.transform.position = new Vector3(0, 0, 0);

            addOceanMaterial(gridSize, frequency, noiseMap11, noiseMap12, noiseMap13, noiseMap14, noiseMap15, noiseMap16, amplitude, meshHeightCurve, scaler1);
        }
    }



    public void addOceanMaterial(int gridSize, int frequency, float[,] noiseMap11, float[,] noiseMap12, float[,] noiseMap13, float[,] noiseMap14, float[,] noiseMap15, float[,] noiseMap16, float amplitude, AnimationCurve meshHeightCurve, float scaler1)
    {

        counter++;

        if (counter % 2 == 0)
        {

            //used to have get color here

            //get blank material
            Material material11 = Resources.Load("ocean1", typeof(Material)) as Material;
            Texture2D texture11 = new Texture2D(((int)(gridSize - frequency - 1) / 4) + 2, ((int)(gridSize - frequency - 1) / 4) + 2);
            texture11 = (Texture2D)get14.createCubeRight(gridSize, frequency, noiseMap11, amplitude, meshHeightCurve, false, "top", true);

            //set no wrap
            texture11.wrapMode = TextureWrapMode.Clamp;
            //apply texture to mesh and render texture
            gameObject12.GetComponent<Renderer>().material = material11;
            gameObject12.GetComponent<Renderer>().material.SetTexture("_MainTex", texture11);



            //get blank material
            Material material12 = Resources.Load("ocean2", typeof(Material)) as Material;
            Texture2D texture12 = new Texture2D(((int)(gridSize - frequency - 1) / 4) + 2, ((int)(gridSize - frequency - 1) / 4) + 2);
            texture12 = (Texture2D)get14.createCubeRight(gridSize, frequency, noiseMap12, amplitude, meshHeightCurve, false, "bottom", true);

            //set no wrap
            texture12.wrapMode = TextureWrapMode.Clamp;
            //apply texture to mesh and render texture
            gameObject13.GetComponent<Renderer>().material = material12;
            gameObject13.GetComponent<Renderer>().material.SetTexture("_MainTex", texture12);


            //get blank material
            Material material13 = Resources.Load("ocean3", typeof(Material)) as Material;
            Texture2D texture13 = new Texture2D(((int)(gridSize - frequency - 1) / 4) + 2, ((int)(gridSize - frequency - 1) / 4) + 2);
            texture13 = (Texture2D)get14.createCubeRight(gridSize, frequency, noiseMap13, amplitude, meshHeightCurve, false, "left", true);

            //set no wrap
            texture13.wrapMode = TextureWrapMode.Clamp;
            //apply texture to mesh and render texture
            gameObject14.GetComponent<Renderer>().material = material13;
            gameObject14.GetComponent<Renderer>().material.SetTexture("_MainTex", texture13);


            //get blank material
            Material material14 = Resources.Load("ocean4", typeof(Material)) as Material;
            Texture2D texture14 = new Texture2D(((int)(gridSize - frequency - 1) / 4) + 2, ((int)(gridSize - frequency - 1) / 4) + 2);
            texture14 = (Texture2D)get14.createCubeRight(gridSize, frequency, noiseMap14, amplitude, meshHeightCurve, false, "right", true);

            //set no wrap
            texture14.wrapMode = TextureWrapMode.Clamp;
            //apply texture to mesh and render texture
            gameObject15.GetComponent<Renderer>().material = material14;
            gameObject15.GetComponent<Renderer>().material.SetTexture("_MainTex", texture14);


            //get blank material
            Material material15 = Resources.Load("ocean5", typeof(Material)) as Material;
            Texture2D texture15 = new Texture2D(((int)(gridSize - frequency - 1) / 4) + 2, ((int)(gridSize - frequency - 1) / 4) + 2);
            texture15 = (Texture2D)get14.createCubeRight(gridSize, frequency, noiseMap15, amplitude, meshHeightCurve, false, "front", true);

            //set no wrap
            texture15.wrapMode = TextureWrapMode.Clamp;
            //apply texture to mesh and render texture
            gameObject16.GetComponent<Renderer>().material = material15;
            gameObject16.GetComponent<Renderer>().material.SetTexture("_MainTex", texture15);


            //get blank material
            Material material16 = Resources.Load("ocean6", typeof(Material)) as Material;
            Texture2D texture16 = new Texture2D(((int)(gridSize - frequency - 1) / 4) + 2, ((int)(gridSize - frequency - 1) / 4) + 2);
            texture16 = (Texture2D)get14.createCubeRight(gridSize, frequency, noiseMap16, amplitude, meshHeightCurve, false, "back", true);

            //set no wrap
            texture16.wrapMode = TextureWrapMode.Clamp;
            //apply texture to mesh and render texture
            gameObject17.GetComponent<Renderer>().material = material16;
            gameObject17.GetComponent<Renderer>().material.SetTexture("_MainTex", texture16);
        }

        else
        {

            //used to have get color here

            //get blank material
            Material material11 = Resources.Load("ocean1", typeof(Material)) as Material;
            Texture2D texture11 = new Texture2D(((int)(gridSize - frequency - 1) / 4) + 2, ((int)(gridSize - frequency - 1) / 4) + 2);
            texture11 = (Texture2D)get14.createCubeRight(gridSize, frequency, noiseMap11, amplitude, meshHeightCurve, false, "top", true);

            //set no wrap
            texture11.wrapMode = TextureWrapMode.Clamp;
            //apply texture to mesh and render texture
            gameObject12.GetComponent<Renderer>().material = material11;
            gameObject12.GetComponent<Renderer>().material.SetTexture("_MainTex", texture11);



            //get blank material
            Material material12 = Resources.Load("ocean2", typeof(Material)) as Material;
            Texture2D texture12 = new Texture2D(((int)(gridSize - frequency - 1) / 4) + 2, ((int)(gridSize - frequency - 1) / 4) + 2);
            texture12 = (Texture2D)get14.createCubeRight(gridSize, frequency, noiseMap12, amplitude, meshHeightCurve, false, "bottom", true);

            //set no wrap
            texture12.wrapMode = TextureWrapMode.Clamp;
            //apply texture to mesh and render texture
            gameObject13.GetComponent<Renderer>().material = material12;
            gameObject13.GetComponent<Renderer>().material.SetTexture("_MainTex", texture12);


            //get blank material
            Material material13 = Resources.Load("ocean3", typeof(Material)) as Material;
            Texture2D texture13 = new Texture2D(((int)(gridSize - frequency - 1) / 4) + 2, ((int)(gridSize - frequency - 1) / 4) + 2);
            texture13 = (Texture2D)get14.createCubeRight(gridSize, frequency, noiseMap13, amplitude, meshHeightCurve, false, "left", true);

            //set no wrap
            texture13.wrapMode = TextureWrapMode.Clamp;
            //apply texture to mesh and render texture
            gameObject14.GetComponent<Renderer>().material = material13;
            gameObject14.GetComponent<Renderer>().material.SetTexture("_MainTex", texture13);


            //get blank material
            Material material14 = Resources.Load("ocean4", typeof(Material)) as Material;
            Texture2D texture14 = new Texture2D(((int)(gridSize - frequency - 1) / 4) + 2, ((int)(gridSize - frequency - 1) / 4) + 2);
            texture14 = (Texture2D)get14.createCubeRight(gridSize, frequency, noiseMap14, amplitude, meshHeightCurve, false, "right", true);

            //set no wrap
            texture14.wrapMode = TextureWrapMode.Clamp;
            //apply texture to mesh and render texture
            gameObject15.GetComponent<Renderer>().material = material14;
            gameObject15.GetComponent<Renderer>().material.SetTexture("_MainTex", texture14);


            //get blank material
            Material material15 = Resources.Load("ocean5", typeof(Material)) as Material;
            Texture2D texture15 = new Texture2D(((int)(gridSize - frequency - 1) / 4) + 2, ((int)(gridSize - frequency - 1) / 4) + 2);
            texture15 = (Texture2D)get14.createCubeRight(gridSize, frequency, noiseMap15, amplitude, meshHeightCurve, false, "front", true);

            //set no wrap
            texture15.wrapMode = TextureWrapMode.Clamp;
            //apply texture to mesh and render texture
            gameObject16.GetComponent<Renderer>().material = material15;
            gameObject16.GetComponent<Renderer>().material.SetTexture("_MainTex", texture15);


            //get blank material
            Material material16 = Resources.Load("ocean6", typeof(Material)) as Material;
            Texture2D texture16 = new Texture2D(((int)(gridSize - frequency - 1) / 4) + 2, ((int)(gridSize - frequency - 1) / 4) + 2);
            texture16 = (Texture2D)get14.createCubeRight(gridSize, frequency, noiseMap16, amplitude, meshHeightCurve, false, "back", true);

            //set no wrap
            texture16.wrapMode = TextureWrapMode.Clamp;
            //apply texture to mesh and render texture
            gameObject17.GetComponent<Renderer>().material = material16;
            gameObject17.GetComponent<Renderer>().material.SetTexture("_MainTex", texture16);
        }
    }


}

