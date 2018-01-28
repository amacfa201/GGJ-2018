using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour {

    public List<GameObject> powerUpHolder;
    public float spawnTimer = 30.0f;
    GameObject spawnedItem;
    Vector3 spawnPoint = new Vector3(20, 25, 0);

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        spawnTimer -= Time.deltaTime;
        SpawnPowerUp();

    }

    void SpawnPowerUp()
    {
        if (spawnTimer<=0)
        {
            spawnedItem = powerUpHolder[Random.Range(0, powerUpHolder.Count)];
            Instantiate<GameObject>(spawnedItem);
            spawnedItem.transform.position = spawnPoint;
            spawnTimer = 30;
        }
    }

}
