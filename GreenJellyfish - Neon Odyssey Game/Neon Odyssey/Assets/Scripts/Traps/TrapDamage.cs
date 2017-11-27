using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script not implemented
//---------------------------------------------------------
//-written by: Edward,
//-contributors:
//---------------------------------------------------------

//-----------------------------------------------------------------------------
// Attach script to enemy or trap gameObject (requires collider)
//-----------------------------------------------------------------------------

public class TrapDamage : MonoBehaviour
{

    //store colour of trap
    int trapColour;

    // Use this for initialization
    void Start ()
    {
        //set current layer check to layer of current object
        trapColour = this.gameObject.layer;
	}
	
    private void OnTriggerEnter(Collider other) //If player touches trap/enemy of another colour, take damage
    {
        if (other.transform.parent.gameObject.tag == "Player" && other.transform.parent.gameObject.layer != trapColour)
        {
            if (other.gameObject.GetComponent<Player>() != null)
            {
                 other.gameObject.GetComponent<Player>().ChangeHealth(-1);
            }
        }
    }

   

}
