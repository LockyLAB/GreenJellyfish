using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script not implemented
//---------------------------------------------------------
//-written by: Edward,
//-contributors:
//---------------------------------------------------------

public class DefaultWeaponPickup : Pickup {

    protected override void ActivatePickup(GameObject other)
    {
        //set players current weapon to this weapon
        other.GetComponent<Weapon>().m_currentWeapon = Weapon.currentWeapon.Launcher;

        //shot cooldown set to weapons fire rate so there is no delay on shooting when weapon pickedup
        other.GetComponent<Weapon>().shotCooldown = GetComponent<Weapon>().defaultFireRate;
    }
}
