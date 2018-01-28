using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour {
    public GameObject player1;
    public Vector3 player1Direction;

    // Use this for initialization
    void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
        print(Input.GetAxisRaw("Cont1 Right Stick X"));
		player1Direction = Vector3.forward * Input.GetAxisRaw("Cont1 Right Stick X") + Vector3.forward * Input.GetAxisRaw("Cont1 Right Stick Y") ;

        player1.transform.Rotate(player1Direction);

    }
}
