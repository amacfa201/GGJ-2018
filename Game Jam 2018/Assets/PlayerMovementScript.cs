using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour 
{
	private Vector3 movementVector;

	private CharacterController characterController;

	public float movementSpeed = 8;
	private float rotationSpeed;

	public float xfire;

	public float yfire;

	public int playerNo;

	public Transform bulletShot;

	public float shotDelay;

	float verticalRotate;
	float horizontalRotate;


	// Use this for initialization
	void Start () 
	{
		characterController = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (playerNo == 1) 
		{
			movementVector.x = Input.GetAxis ("xMove") * movementSpeed;

			movementVector.y = Input.GetAxis ("yMove") * movementSpeed;

			xfire = Input.GetAxis ("xShoot");

			yfire = Input.GetAxis ("yShoot");
			verticalRotate = Input.GetAxis ("yShoot") * Time.deltaTime * movementSpeed;
			horizontalRotate = Input.GetAxis ("xShoot") * Time.deltaTime * -movementSpeed;
		} 
		else 
		{
			movementVector.x = Input.GetAxis ("xMoveP2") * movementSpeed;

			movementVector.y = Input.GetAxis ("yMoveP2") * movementSpeed;

			xfire = Input.GetAxis ("xShootP2");

			yfire = Input.GetAxis ("yShootP2");

			verticalRotate = Input.GetAxis ("yShootP2") * Time.deltaTime * movementSpeed;
			horizontalRotate = Input.GetAxis ("xShootP2") * Time.deltaTime * -movementSpeed;
		}

		characterController.Move (movementVector * Time.deltaTime);
		Rigidbody rb = GetComponent<Rigidbody>();

		float rotationAngle = Mathf.Atan2 (horizontalRotate, verticalRotate) * Mathf.Rad2Deg;

		Quaternion rotation = Quaternion.Euler(new Vector3 (0, 0, rotationAngle));
		transform.rotation =  Quaternion.Lerp (transform.rotation, rotation, rotationSpeed * Time.deltaTime);

		if (xfire != 0 || yfire != 0) 
		{
			rotationSpeed = 8;
		}
		else
		{
			rotationSpeed = 0;
		}

		bulletShot.rotation = Quaternion.Euler(new Vector3 (0, 0, rotationAngle));


		if (((xfire > 0.8 || xfire < -0.8)) & (shotDelay == 0))
		{
			shotDelay = 1;
			Instantiate (bulletShot, transform.position, bulletShot.rotation);
			StartCoroutine(delayRest());
		}

		if (((yfire > 0.8 || yfire < -0.8)) & (shotDelay == 0))
		{
			shotDelay = 1;
			Instantiate (bulletShot, transform.position, bulletShot.rotation);
			StartCoroutine(delayRest());
		}
	}

	IEnumerator delayRest()
	{
		yield return new WaitForSeconds (0.45f);
		shotDelay = 0;
	}
}
