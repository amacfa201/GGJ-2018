using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupScript : MonoBehaviour 
{
	private PlayerMovementScript movementScript;

	void Start()
	{
		movementScript = GetComponent<PlayerMovementScript> ();
	}
	
	//powerups
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "coffee") 
		{
			Destroy (other.gameObject);
			StartCoroutine(coffeePower());
		}
	}

	IEnumerator coffeePower()
	{
		//this movementSpeed canges what the powerup speed is
		movementScript.movementSpeed = 16;
		yield return new WaitForSeconds (5);
	}
}