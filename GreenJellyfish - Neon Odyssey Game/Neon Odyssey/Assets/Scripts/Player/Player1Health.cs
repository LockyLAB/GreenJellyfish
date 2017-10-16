using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;
public class Player1Health : MonoBehaviour {

    public int health = 4;
    int tempHealth;

    public Player player;

    public Player2Health otherPlayerHealth;

    public XboxController controller;

    public bool isReviving = false;

    public float reviveTime = 2;

    public float timer = 0;

    public int healthGivenByPickup = 3;

    public float deathTimer = 0;

    public float deathTime = 2;

    public bool isInvulnerable; 
    // Use this for initialization
    void Start ()
    {
        isReviving = false;
        player = player.GetComponent<Player>();
        otherPlayerHealth = otherPlayerHealth.GetComponent<Player2Health>();
        tempHealth = health;
	}
	
	// Update is called once per frame
	void Update ()
    {

        


        if(health > 4)
        {
            health = 4;
        }


	    if(health <= 0)
       {
           health = 0;
           player.isDead = true;
       }
       else
       {
           player.isDead = false;
       }


        if (isReviving && XCI.GetButton((XboxButton.A), controller) && !player.isDead)
        {
            timer += Time.deltaTime;

            if (timer >= reviveTime)
            {
                otherPlayerHealth.health = 2;
            }



        }

        if (XCI.GetButtonUp((XboxButton.A), controller))
        {
            timer = 0;
        }

        deathTimer += Time.deltaTime;
        if(tempHealth != health)
        {
            deathTimer = 0.0f;
            if(deathTimer <= deathTime)
            {
                isInvulnerable = true;
            }
            else
            {
                isInvulnerable = false;
            }
        }




        tempHealth = health;
    }
  
   void OnTriggerEnter(Collider other)
   {
        if (other.gameObject.tag == "Player2Revive" && otherPlayerHealth.health <= 0)
        {
            isReviving = true;
        }

        if (other.gameObject.tag == "HealthPickup")
        {
            Destroy(other.gameObject);
            health += healthGivenByPickup;
        }



    }

        void OnTriggerExit(Collider other)
    {
            if (other.gameObject.tag == "Player2Revive" && otherPlayerHealth.health <= 0)
            {
            isReviving = false;
            timer = 0;
            }
        }



    }




