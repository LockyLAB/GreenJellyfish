using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamage : MonoBehaviour
{
    /* 
    * PLACE THIS SCRIPT ON ENEMY OBJECT
    * ENEMY OBJECT NEEDS: RIGIDBODY, TRIGGER COLLIDER    
    */

    //store colour of enemy
    int enemyColour;

	// Use this for initialization
	void Start ()
    {
        enemyColour = this.gameObject.layer;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        //check if collided objects' parent is Player and is not same colour as trap
        if (other.transform.parent.gameObject.tag == "Player" && other.transform.parent.gameObject.layer != enemyColour)
        {
            //Check player to damage
            if (other.gameObject.GetComponent<PlayerHealth>() != null)
            {
                other.gameObject.GetComponent<Player>().ChangeHealth(-1);
            }
        }
    }
}
