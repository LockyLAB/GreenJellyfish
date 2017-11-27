using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script not implemented
//---------------------------------------------------------
//-written by: Edward,
//-contributors:
//---------------------------------------------------------

//-----------------------------------------------------------------------------
// Attach script to powerup gameobject
//-----------------------------------------------------------------------------

public class ChargePickup : Pickup {

    //add powerup charge on pickup
    protected override void ActivatePickup(GameObject other) 
    {
        other.GetComponent<PlayerSuper>().ChangeCharge(20.0f);
    }
}
