using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script not implemented
//---------------------------------------------------------
//-written by: Edward,
//-contributors:
//---------------------------------------------------------

//-----------------------------------------------------------------------------
// Attach script to enemy or trap gameObject (requires collider/rigidbody)
//-----------------------------------------------------------------------------
public class ContactDamage : MonoBehaviour
{
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
