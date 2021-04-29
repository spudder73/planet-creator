using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

	// Update is called once per frame
	/*
    void Update()
    {
        float speed = 0.02f;

        transform.Translate(Input.GetAxisRaw("Horizontal") * speed, 0, Input.GetAxisRaw("Vertical") * speed);

        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, mask))
        {
            objectToPlace.position = hitInfo.point;
            objectToPlace.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
        }

        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        //transform.Rotate(v, h, 0);
    }
    

	public float mouseSensitivityX;
	public float mouseSensitivityY;
	public float jumpForce;
	public LayerMask groundedMask;

	// System vars
	bool grounded;
	Vector3 moveAmount;
	Vector3 smoothMoveVelocity;
	float verticalLookRotation;
	Transform cameraTransform;
	Rigidbody rigidbody;


	void Start()
	{
		cameraTransform = Camera.main.transform;
		rigidbody = GetComponent<Rigidbody>();
		mouseSensitivityX = 2f;
		mouseSensitivityY = 2f;
		jumpForce = 50;
	}

	void Update()
	{

		// Look rotation:
		transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivityX);
		verticalLookRotation += Input.GetAxis("Mouse Y") * mouseSensitivityY;
		verticalLookRotation = Mathf.Clamp(verticalLookRotation, -60, 60);
		cameraTransform.localEulerAngles = Vector3.left * verticalLookRotation;

		// Calculate movement:
		float inputX = Input.GetAxisRaw("Horizontal");
		float inputY = Input.GetAxisRaw("Vertical");

		Vector3 moveDir = new Vector3(inputX, 0, inputY).normalized;
		Vector3 targetMoveAmount = moveDir *2;
		moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);

		// Jump
		if (Input.GetKey("space"))
		{
			if (grounded)
			{
				rigidbody.AddForce(transform.up * jumpForce);
			}
		}

		// Grounded check
		Ray ray = new Ray(transform.position, -transform.up);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, 1 + 0.1f, groundedMask))
		{
			grounded = true;
		}
		else
		{
			grounded = false;
		}

	}

	void FixedUpdate()
	{
		// Apply movement to rigidbody
		Vector3 localMove = transform.TransformDirection(moveAmount) * Time.fixedDeltaTime;
		rigidbody.MovePosition(rigidbody.position + localMove);

	}

	*/
}

