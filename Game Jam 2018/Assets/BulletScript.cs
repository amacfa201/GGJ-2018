using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour 
{
	public float xfire;
	public float yfire;
	public float shotSpeed = 5;
	public int playerNo;

	// Use this for initialization
	void Start () 
	{

		if (playerNo == 1) {
			xfire = Input.GetAxis ("xShoot") * shotSpeed;
			yfire = Input.GetAxis ("yShoot") * shotSpeed;
		} else {
			xfire = Input.GetAxis ("xShootP2") * shotSpeed;
			yfire = Input.GetAxis ("yShootP2") * shotSpeed;
		}
				
	}
	
	// Update is called once per frame
	void Update () 
	{
        BulletFire();

    }

   void BulletFire()
    {
       
        GetComponent<Rigidbody>().velocity = new Vector3(xfire, yfire, 0);
    }
}
