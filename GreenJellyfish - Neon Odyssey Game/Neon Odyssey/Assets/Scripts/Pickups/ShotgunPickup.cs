using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunPickup : Pickup {

    protected override void ActivatePickup(GameObject other)
    {
        //set players current weapon to this weapon
        other.GetComponent<Weapon>().m_currentWeapon = Weapon.currentWeapon.Shotgun;

        //shot cooldown set to weapons fire rate so there is no delay on shooting when weapon picked up
        other.GetComponent<Weapon>().shotCooldown = GetComponent<Weapon>().shotgunFireRate; 
    }
}
