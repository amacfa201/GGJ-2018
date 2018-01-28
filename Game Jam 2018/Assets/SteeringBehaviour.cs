using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SteeringBehaviour : MonoBehaviour {
    public Vector3 desiredVelocity;

    public Vector3 steeringVelocity;

    public abstract Vector3 UpdateBehaviour(SteeringAgent steeringAgent);
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
