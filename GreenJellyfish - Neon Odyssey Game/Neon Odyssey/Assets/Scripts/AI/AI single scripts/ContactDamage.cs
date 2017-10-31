using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamage : MonoBehaviour
{
    //-----------------------------------------------------------------
    //PLACE THIS SCRIPT ON OBJECT TO DEAL CONTACT DAMAGE
    //ENEMY OBJECT NEEDS: TRIGGER COLLIDER, RIGIDBODY 
    //-----------------------------------------------------------------

    //store colour of enemy
    private int enemyColour;

	// Use this for initialization
	void Start ()
    {
        //set colour of this object to object parents layer
        if (gameObject.GetComponent<ContactDamage>() == true)
        {
            enemyColour = this.gameObject.layer;
        }
	}
	
    private void OnTriggerEnter(Collider other)
    {
        //check if other object is Player and is different colour
        if (other.gameObject.tag == "Player" && other.gameObject.layer != enemyColour)
        {
            //Check player to damage
            if (other.gameObject.GetComponent<PlayerHealth>() != null)
            {
                other.gameObject.GetComponent<Player>().ChangeHealth(-1);
            }
        }
    }
}
