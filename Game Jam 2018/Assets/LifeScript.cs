using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LifeScript : MonoBehaviour {
    public int player1Lives = 3;
    public int player2Lives = 3;
    public int player1Health = 3;
    public int player2Health = 3;
    int maxHealth = 3;
    public float player1RespawnTimer;
    public float player2RespawnTimer;
    Transform player1Transform;
    Transform player2Transform;
    public Vector3 player1SpawnPoint = new Vector3(-8, 1.5f, 0);
    public Vector3 player2SpawnPoint = new Vector3(6.5f, 1.6f, 0);
    public GameObject player1;
    public GameObject player2;
    public float respawnTime = 3.0f;

    public bool chase1 = true;
    public bool chase2 = true;
    //public Text 
    

    // Use this for initialization
    void Start () {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
    }
	
	// Update is called once per frame
	void Update () {
    //player1RespawnTimer -= Time.deltaTime;
    //player2RespawnTimer -= Time.deltaTime;
    PlayerLivesManager();
    


    }

	

    void PlayerLivesManager()
    {
        if (player1Health <= 0)
        {
            player1RespawnTimer = respawnTime;
            player1Transform.position = player1SpawnPoint;
            player1Lives -= 1;
            player1Health = maxHealth;
        }

        if (player2Health <= 0)
        {
            player2RespawnTimer = respawnTime;
            player2Transform.position = player2SpawnPoint;
            player2Lives -= 1;
            player2Health = maxHealth;
        }
    
        if (player1RespawnTimer > 0)
        {
            //  player1.SetActive(false);
            player1RespawnTimer -= Time.deltaTime;
            player1.GetComponent<Collider>().enabled = false;
            player1.GetComponent<SpriteRenderer>().enabled = false;
            //chase1 = false;
        }

        if (player2RespawnTimer > 0)
        {
            // player2.SetActive(false);
            player2RespawnTimer -= Time.deltaTime;
            player2.GetComponent<Collider>().enabled = false;
        }

        if (player1RespawnTimer <= 0)
        {
            //player1.SetActive(true);
            player1.GetComponent<Collider>().enabled = true;
            player1.GetComponent<SpriteRenderer>().enabled = true;
        }

        if (player2RespawnTimer <= 0)
        {
            //player2.SetActive(true);
            player2.GetComponent<Collider>().enabled = true;
            player2.GetComponent<SpriteRenderer>().enabled = true;
        }


    }
    
}
