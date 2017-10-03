using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSingle : TrapBase
{
    public override void FireTrap()
    {
        Vector3 bulletDir = transform.up;

        GameObject newBullet = Instantiate(m_bullet, this.transform.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().velocity = bulletDir * m_bulletSpeed;
    }
}
