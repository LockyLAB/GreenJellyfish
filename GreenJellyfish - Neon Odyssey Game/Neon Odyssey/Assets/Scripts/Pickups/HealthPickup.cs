using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup
{
    protected override void ActivatePickup(GameObject other)
    {
        other.GetComponent<Player>().ChangeHealth(2);
    }
}
