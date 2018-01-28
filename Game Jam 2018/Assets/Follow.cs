using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour 
{


	GameObject player; 
    GameObject player2;


    public bool Player1sBitch = false;
    public bool Player2sBitch = false;
    public SteeringAgent steeringAgent;

	// Use this for initialization
	void Start () 
	{
        steeringAgent = this.GetComponent<SteeringAgent>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        player = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");

		//Follow target (player 1)
		if (Player2sBitch == true) 
		{

            steeringAgent.seekTarget = player;
            steeringAgent.seekWeight = 1;
            steeringAgent.wanderWeight = 0;
			
		}

		//Follow target 2 (player 2)
		if (Player1sBitch == true) 
		{
            steeringAgent.seekTarget = player2;
            steeringAgent.seekWeight = 1;
            steeringAgent.wanderWeight = 0;
        }
	}
    

    
}
