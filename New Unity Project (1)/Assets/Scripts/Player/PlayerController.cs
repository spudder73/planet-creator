using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float FBdirection;
    public float LRdirection;
    public float roll;
    public float move1;
    public float boost;
    public float up;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.visible = true;

    }

    // Update is called once per frame
    void Update()
    {
        
        FBdirection = 0;
        LRdirection = 0;
        up = 0;
        roll = 0;
        boost = 2;

        if (Input.GetKey("w"))
        {
            FBdirection += 10;
        }
        if (Input.GetKey("s"))
        {
            FBdirection -= 10;
        }
        if (Input.GetKey("d"))
        {
            LRdirection += 10;
        }
        if (Input.GetKey("a"))
        {
            LRdirection -= 10;
        }
        if (Input.GetKey("q"))
        {
            roll += 10;
        }
        if (Input.GetKey("e"))
        {
            roll -= 10;
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            boost = 2;
        }
        if (Input.GetKey("space"))
        {
            up += 11f;
        }



        rb.AddRelativeForce(new Vector3(boost* LRdirection, boost * up, boost* FBdirection), ForceMode.Force);
        move1 = 6f;
        if (Input.GetKey(KeyCode.Mouse1))
        {
            move1 /= 10;
            roll /= 10;
            rb.AddRelativeTorque(move1 * Input.GetAxis("Mouse Y"), move1 * Input.GetAxis("Mouse X"), roll / 15, ForceMode.Force);
        }
        
        float speed = 0.002f;
        transform.Translate(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed, 0);

        
        Vector3 grav = transform.position;
        float mult = grav.magnitude / 100;
        if (mult < 1)
        {
            rb.AddForce(grav * (-1f + mult) * 0.7f, ForceMode.Force);
        }
        

    }
}
