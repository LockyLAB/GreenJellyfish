using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDamage : MonoBehaviour
{
    /* 
    * ATTACH THIS SCRIPT ON THE TRAP OBJECTS "COLLIDER" CHILD
    * "COLLIDER" OB  
    */

    //store colour of trap
    int trapColour;

    // Use this for initialization
    void Start ()
    {
        //set current layer check to layer of current object
        trapColour = this.gameObject.layer;
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void OnTriggerEnter(Collider other)
    {
        //check if collided objects' parent is Player and is not same colour as trap
        if (other.transform.parent.gameObject.tag == "Player" && other.transform.parent.gameObject.layer != trapColour)
        {
            //Check player to damage
            if (other.gameObject.GetComponent<Player1Health>() != null)
            {
                 other.gameObject.GetComponent<Player1Health>().takeDamage(1);
            }

            if (other.gameObject.GetComponent<Player2Health>() != null)
            {
                 other.gameObject.GetComponent<Player2Health>().takeDamage(1);
            }
        }
    }

   

}
