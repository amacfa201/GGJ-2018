using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringAgent : MonoBehaviour {
    
    public float maxSpeed = .1f;

    public Vector3 playerVelocity = Vector3.zero;

    public float maxSteering = 2.0f;

    public List<SteeringBehaviour> steeringBehvaiours = new List<SteeringBehaviour>();

     public Vector3 currentVelocity;

    
    public GameObject seekTarget;
    

    public float seekWeight = 0, wanderWeight = 1f, arrivalWeight = 0f;

    public RaycastHit hit;



    // Use this for initialization
    void Start () {
        seekTarget = GameObject.FindGameObjectWithTag("SeekTarget");
	}
	
	// Update is called once per frame
	void Update () {
        UpdateDirection();
        UpdatePosition();
        CooperativeArbitration();
	}

    public void CooperativeArbitration()
    {
        Vector3 steeringVelocity = Vector3.zero;
        
        GetComponents<SteeringBehaviour>(steeringBehvaiours);
        foreach (SteeringBehaviour currentBehaviour in steeringBehvaiours)
        {
            if (currentBehaviour.enabled)
            {
                Vector3 nextSteering = currentBehaviour.UpdateBehaviour(this);
                float distanceSoFar = steeringVelocity.magnitude;
                float distanceRemaining = maxSteering - distanceSoFar;

                if (distanceRemaining <= 0)
                {
                    steeringVelocity = steeringVelocity;
                    break;
                }
                else
                {
                    steeringVelocity += currentBehaviour.UpdateBehaviour(this);

                }

                float steerubgToAdd = nextSteering.magnitude;
                if (steerubgToAdd < distanceRemaining)
                {
                    steeringVelocity += nextSteering;
                }
                else
                {
                    steeringVelocity += (Vector3.Normalize(nextSteering) * distanceRemaining);
                }

            }
            
        }
        
        currentVelocity += LimitSteering(steeringVelocity, maxSteering);
        currentVelocity = LimitVelocity(currentVelocity, maxSpeed);
    }

    


        public void UpdateDirection()
    {
        if (currentVelocity.sqrMagnitude > 0.0f)
        {
            transform.up = Vector3.Normalize(new Vector3(currentVelocity.x, currentVelocity.y, 0.0f));
        }
    }
   void UpdatePosition()
    {
        transform.position += currentVelocity * Time.deltaTime;

        
        Vector3 position = transform.position;
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(position);

        while (viewportPosition.x < 0.0f)
        {
            viewportPosition.x += 1.0f;
        }
        while (viewportPosition.x > 1.0f)
        {
            viewportPosition.x -= 1.0f;
        }
        while (viewportPosition.y < 0.0f)
        {
            viewportPosition.y += 1.0f;
        }
        while (viewportPosition.y > 1.0f)
        {
            viewportPosition.y -= 1.0f;
        }

        position = Camera.main.ViewportToWorldPoint(viewportPosition);
        position.z = 0.0f;
        transform.position = position;
    }

        public Vector3 LimitSteering (Vector3 playerVelocity, float maxSteering)
    {
        if (playerVelocity.sqrMagnitude > maxSpeed * maxSpeed)
        {
            playerVelocity.Normalize();
            playerVelocity *= maxSteering;
        }
        return playerVelocity;
    }

     public Vector3 LimitVelocity(Vector3 velocity, float maxSpeed)
    {
        if (velocity.sqrMagnitude > maxSpeed * maxSpeed)
        {
            velocity.Normalize();
            velocity *= maxSpeed;
        }
        return velocity;
    }

}
