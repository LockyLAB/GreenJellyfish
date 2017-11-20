using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup
{
    //--------------------------------------------------------------------------------------
    // Action that pickup should do
    // Add 2 health to object
    //
    // Param:
    //		other: Object that pickup has collided up
    //--------------------------------------------------------------------------------------
    protected override void ActivatePickup(GameObject other)
    {
        other.GetComponent<Player>().ChangeHealth(2);
    }
}
