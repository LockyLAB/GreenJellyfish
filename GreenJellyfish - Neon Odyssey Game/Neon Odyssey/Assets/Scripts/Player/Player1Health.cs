using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;
public class Player1Health : MonoBehaviour {

    public int health = 4;

    public Player player;

    public Player2Health otherPlayerHealth; 

    public bool isReviving = false;

    public float reviveTime = 2;

    public float timer = 0;

    public int healthGivenByPickup = 3;


    // Use this for initialization
    void Start ()
    {
        isReviving = false;
        player = player.GetComponent<Player>();
        otherPlayerHealth = otherPlayerHealth.GetComponent<Player2Health>();

	}
	
	// Update is called once per frame
	void Update ()
    {
   
        if(health > 4)
        {
            health = 4;
        }
        if(health < 0)
        {
            health = 0;
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


        if (isReviving && XCI.GetButton(XboxButton.A) && !player.isDead)
        {
            timer += Time.deltaTime;

            if (timer >= reviveTime)
            {
                otherPlayerHealth.health = 2;
            }



        }

        if (XCI.GetButtonUp(XboxButton.A))
        {
            timer = 0;
        }



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




