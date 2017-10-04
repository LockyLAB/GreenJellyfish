using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPinkBullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //function called when object collides
    void OnTriggerEnter(Collider col)
    {
        //if bullet is same colour as enemy, destroy enemy, destroy bullet
        if (col.gameObject.tag == "playerPink")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }

        //if bullet collides with objects under "collision" layer, destroy bullet
        if (col.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }

        //if enemy is not bullet colour, destroy bullet
        else if (col.gameObject.tag == "playerGreen")
        {
            Destroy(gameObject);
        }

        else if (col.gameObject.tag == "playerOrange")
        {
            Destroy(gameObject);
        }

        else if (col.gameObject.tag == "playerYellow")
        {
            Destroy(gameObject);
        }
    }
}
