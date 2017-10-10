using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPurpleBullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (gameObject.GetComponentInChildren<Renderer>().isVisible == false)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        //if BULLET is same colour as PLAYER, destroy BULLET
        if (col.gameObject.tag == "Player" && col.gameObject.layer == 9)
        {
            Destroy(gameObject);
        }

        //if BULLET collides with WALLS, destroy BULLET
        if (col.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }

        //if ENEMY is not BULLET colour, destroy BULLET
        else if (col.gameObject.tag == "Player" && (col.gameObject.layer == 10 || //pink
                                                    col.gameObject.layer == 11 || //orange
                                                    col.gameObject.layer == 12))  //green
        {
             //if collision with PLAYER 1, deal damage
             if (col.gameObject.GetComponentInChildren<Player1Health>() != null)
             {
                 col.gameObject.GetComponentInChildren<Player1Health>().health -= 1;
             }

            //if collision with PLAYER 2 deal damage
             if (col.gameObject.GetComponentInChildren<Player2Health>() != null)
             {
                 col.gameObject.GetComponentInChildren<Player2Health>().health -= 1;
             }

             Destroy(gameObject);
        }
    }

}
