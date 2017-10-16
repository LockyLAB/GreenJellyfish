using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapArc : TrapBase
{
    public float m_firingArc = 0.0f;

    public override void FireTrap()
    {
        Vector3 bulletDir = transform.up ;
        FireBullet(Quaternion.Euler(0, 0, m_firingArc) * bulletDir);
        FireBullet(bulletDir);
        FireBullet(Quaternion.Euler(0, 0, -m_firingArc) * bulletDir);
    }
}
