using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Health : MonoBehaviour {

    public int health = 4;

    public Player player;

    public Player1Health otherPlayerHealth;

    // Use this for initialization
    void Start()
    {

        player = player.GetComponent<Player>();
        otherPlayerHealth = otherPlayerHealth.GetComponent<Player1Health>();

    }

    // Update is called once per frame
    void Update()
    {
    

        if (health <= 0)
        {
            player.isDead = true;
        }
        else
        {
            player.isDead = false;
        }


    }
}
