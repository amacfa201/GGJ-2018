using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : SteeringBehaviour
{
    public override Vector3 UpdateBehaviour(SteeringAgent steeringAgent)
    {

        Vector3 targetPosition = steeringAgent.seekTarget.transform.position;


        Vector3 leftRay = transform.position;
        Vector3 rightRay = transform.position;
        Vector3 direction = Vector3.Normalize(targetPosition - transform.position);
       
        

        desiredVelocity = direction * steeringAgent.maxSpeed;
        steeringVelocity = (desiredVelocity - steeringAgent.currentVelocity) * steeringAgent.seekWeight;
            return steeringVelocity;






        }
        
    

}
