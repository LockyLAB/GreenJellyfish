using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---------------------------------------------------------
//-written by: Samuel
//-contributors:
//---------------------------------------------------------

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
