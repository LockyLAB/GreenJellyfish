using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherPickup : Pickup {

    protected override void ActivatePickup(GameObject other)
    {
        //shot cooldown set to weapons fire rate so there is no delay on shooting when weapon pickedup
        other.GetComponent<Weapon>().m_currentWeapon = Weapon.currentWeapon.Launcher;

        //shot cooldown set to weapons fire rate so there is no delay on shooting when weapon picked up
        other.GetComponent<Weapon>().shotCooldown = GetComponent<Weapon>().launcherFireRate;
    }
}
