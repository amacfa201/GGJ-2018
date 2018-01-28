using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : SteeringBehaviour {
    
    public float circleRadius = 300f;
    public float wanderJitter = 100f;
    public float circleDistance = 1f;
    public float TurnChance = 0.05f;

    private float wanderAngle;

    Vector3 targetPosition;
    Vector3 wanderForce;
    private Vector3 velocity;

    // Use this for initialization
    void Start () {
        velocity = Random.insideUnitCircle;
    }
	
	// Update is called once per frame
	void Update () {
        
	}
    
    public override Vector3 UpdateBehaviour(SteeringAgent steeringAgent)
    {
        
      
        
        var desiredVelocity = GetWanderForce();
        desiredVelocity = desiredVelocity.normalized * steeringAgent.maxSpeed;

        steeringVelocity = desiredVelocity - velocity;
        steeringVelocity = Vector3.ClampMagnitude(steeringVelocity, steeringAgent.maxSteering) ;
        
        

         velocity = Vector3.ClampMagnitude(velocity + steeringVelocity, steeringAgent.maxSpeed);
        //transform.position += velocity * Time.deltaTime;
         transform.up = velocity.normalized;

        base.steeringVelocity = (desiredVelocity - steeringAgent.currentVelocity) * steeringAgent.wanderWeight;
        return base.steeringVelocity;


    }


    private Vector3 GetWanderForce()
    {
        
        if (transform.position.magnitude > circleRadius)
        {
            var directionToCenter = (targetPosition - transform.position).normalized;
            wanderForce = velocity.normalized + directionToCenter;
        }
        else if (Random.value < TurnChance)
        {
            wanderForce = GetRandomWanderForce();
        }

        return wanderForce;
    }

    private Vector3 GetRandomWanderForce()
    {
        var circleCenter = velocity.normalized;
        var randomPoint = Random.insideUnitCircle;

        var displacement = new Vector3(randomPoint.x, randomPoint.y, 0) * circleRadius;
        //displacement = Quaternion.LookRotation(velocity) * displacement;

        var wanderForce = circleCenter; //+ displacement;
        return wanderForce;
    }

}
