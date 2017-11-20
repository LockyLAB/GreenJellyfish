﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSingle : TrapBase
{
    //--------------------------------------------------------------------------------------
    // Fire trap upwards in local space
    //--------------------------------------------------------------------------------------
    public override void FireTrap()
    {
        Vector3 bulletDir = transform.up;

        FireBullet(bulletDir);
    }
}
