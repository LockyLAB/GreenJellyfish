using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPickUp : Pickup {

    protected override void ActivatePickup(GameObject other)
    {
        other.GetComponent<PowerUp>().ChangeCharge(20.0f);
    }
}
