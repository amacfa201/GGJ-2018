using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public Vector3 SpawnPoint1 = new Vector3(-8, 1.5f, 0);
    public Vector3 SpawnPoint2 = new Vector3(6.5f, 1.6f, 0);
    public GameObject player1;
    public GameObject player2;
    public float respawnTime = 3.0f;

    public bool chase1 = true;
    public bool chase2 = true;

    public Text p1Health;
    public Text p1Lives;

    public Text p2Health;
    public Text p2Lives;



    // Use this for initialization
    void Start () {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
       
    }
	
	// Update is called once per frame
	void Update () {
    //player1RespawnTimer -= Time.deltaTime;
    //player2RespawnTimer -= Time.deltaTime;
    //PlayerLivesManager();

       

        if (player1Health <= 0)
        {
            player1Lives--;
            player1Health = 3;
            FindObjectOfType<AudioManager>().Play("Died");
            StartCoroutine(Respawn1());
        }

        if (player2Health <= 0)
        {
            player2Lives--;
            player2Health = 3;
            FindObjectOfType<AudioManager>().Play("Died");
            StartCoroutine(Respawn2());
        }
        p1Health.text = ("Health: " + player1Health);
        p2Health.text = ("Health: " + player2Health);

        p1Lives.text = ("Lives: " + player1Lives);
        p2Lives.text = ("Lives: " + player2Lives);

        if (player1Lives == 0) {
            SceneManager.LoadScene("HateWinScene");
        }

        if (player2Lives == 0)
        {
            SceneManager.LoadScene("LoveWinScene");
        }

    }

    



    void OnCollisionEnter(Collision other)
    {
        print("Collision");
        if (other.gameObject.tag == "Player1sBitch" && this.gameObject.tag == "Player2")
        {
            FindObjectOfType<AudioManager>().Play("LoseHealth");
            player2Health--;
            print("P2 Hit");
        }
        if (other.gameObject.tag == "Player2sBitch" && this.gameObject.tag == "Player1")
        {
            FindObjectOfType<AudioManager>().Play("LoseHealth");
            player1Health--;
            print("P1 Hit");
        }
    }




    //void PlayerLivesManager()
    //{
    //    if (player1Health <= 0)
    //    {
    //        player1RespawnTimer = respawnTime;
    //        player1.transform.position = player1SpawnPoint;
    //        player1Lives -= 1;
    //        player1Health = maxHealth;
    //    }

    //    if (player2Health <= 0)
    //    {
    //        player2RespawnTimer = respawnTime;
    //        player2.transform.position = player2SpawnPoint;
    //        player2Lives -= 1;
    //        player2Health = maxHealth;
    //    }

    //    if (player1RespawnTimer > 0)
    //    {
    //        //  player1.SetActive(false);
    //        player1RespawnTimer -= Time.deltaTime;
    //        player1.GetComponent<Collider>().enabled = false;
    //        player1.GetComponent<SpriteRenderer>().enabled = false;
    //        //chase1 = false;
    //    }

    //    if (player2RespawnTimer > 0)
    //    {
    //        // player2.SetActive(false);
    //        player2RespawnTimer -= Time.deltaTime;
    //        player2.GetComponent<Collider>().enabled = false;
    //    }

    //    if (player1RespawnTimer <= 0)
    //    {
    //        //player1.SetActive(true);
    //        player1.GetComponent<Collider>().enabled = true;
    //        player1.GetComponent<SpriteRenderer>().enabled = true;
    //    }

    //    if (player2RespawnTimer <= 0)
    //    {
    //        //player2.SetActive(true);
    //        player2.GetComponent<Collider>().enabled = true;
    //        player2.GetComponent<SpriteRenderer>().enabled = true;
    //    }


    //}

    //void Respawn(GameObject player) {
    //    player.transform.position = new Vector3(0, 0, 0);
    //    player.GetComponent<Collider>().enabled = true;
    //}



    IEnumerator Respawn1()
    {
        player1.transform.position = new Vector3(0, 0, 0);
        player1.GetComponent<Collider>().enabled = false;
        player1.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(3f);
        player1.GetComponent<Collider>().enabled = true;
        player1.GetComponent<SpriteRenderer>().enabled = true;
    }


    IEnumerator Respawn2()
    {
        player2.transform.position = new Vector3(0, 0, 0);
        player2.GetComponent<Collider>().enabled = false;
        player2.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(3f);
        player2.GetComponent<Collider>().enabled = true;
        player2.GetComponent<SpriteRenderer>().enabled = true;
    }
}
