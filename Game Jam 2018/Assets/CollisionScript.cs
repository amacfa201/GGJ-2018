using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour {
    public LifeScript playerLifeScript;
    public LifeScript playerLifeScript2;
    bool auraBuffP1 = false;
    bool auraBuffP2 = false;

    public float auraBuffTimerP1;// = 10;
    public float auraBuffTimerP2;// = 10;

    public float immuneTimerP1;// = 10;
    public float immuneTimerP2;// = 10;

    bool p1Immune = false;
    bool p2Immune = false;

    public Follow follow;
    // Use this for initialization
    void Start()
    {
        playerLifeScript = GameObject.FindGameObjectWithTag("Player1").GetComponent<LifeScript>();
        playerLifeScript2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<LifeScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //auraBuffTimerP1 -= Time.deltaTime;
        //auraBuffTimerP2 -= Time.deltaTime;
        PowerupDecay();
    }
    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player1sBitch":
                if (this.tag == "Player2")
                {
                    if (auraBuffP2 == true)
                    {

                        follow.Player2sBitch = true;
                        follow.Player1sBitch = false;
                    }
                    else
                    {
                        if (!p2Immune)
                        {
                            
                            playerLifeScript.player2Health -= 1;
                        }
                    }
                }
                break;
            case "Player2sBitch":
                if (auraBuffP1 == true)
                {

                    follow.Player1sBitch = true;
                    follow.Player2sBitch = false;
                }
                else
                {
                    if (!p1Immune)
                    {
                        playerLifeScript2.player1Health -= 1;
                    }
                }
                break;
            case "AuraBuff":
                if (this.tag == "Player1")
                {
                    auraBuffP1 = true;
                    auraBuffTimerP1 = 10;
                }
                else if (this.tag == "Player2")
                {
                    auraBuffP2 = true;
                    auraBuffTimerP2 = 10;
                }
                break;
            case "ImmunityBuff":
                if (this.tag == "Player1")
                {
                    p1Immune = true;
                    immuneTimerP1 = 10f;
                }
                else if (this.tag == "Player2")
                {
                    p2Immune = true;
                    immuneTimerP2 = 10f;
                }
                break;

        }


        if (p1Immune)
        {
        }


        //if (this.tag == "Player2" && collision.gameObject.tag == "Player1sBitch")
        //{
        //    playerLifeScript.player2Health -= 1;
        //}

        //if (this.tag == "Player1" && collision.gameObject.tag == "Player2sBitch")
        //{
        //    playerLifeScript2.player1Health -= 1;
        //}

    }

    //Needs optimized - this is shite / andrew
    void PowerupDecay()


    {
        if (p1Immune && immuneTimerP1 > 0)
        {
            immuneTimerP1 -= Time.deltaTime;
        }

        if (p2Immune && immuneTimerP2 > 0)
        {
            immuneTimerP2 -= Time.deltaTime;
        }

        if (auraBuffP1 && auraBuffTimerP1 > 0)
        {
            auraBuffTimerP1 -= Time.deltaTime;
        }
        if (auraBuffP2 && auraBuffTimerP2 > 0)
        {
            auraBuffTimerP2 -= Time.deltaTime;
        }

        if (immuneTimerP1 == 0)
        {
            p1Immune = false;
        }
        if (immuneTimerP2 == 0)
        {
            p2Immune = false;
        }
        if (auraBuffTimerP1 == 0)
        {
            auraBuffP1 = false;
        }
        if (auraBuffTimerP2 == 0)
        {
            auraBuffP2 = false;
        }


    }
}
