using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSingle : TrapBase
{
    public override void FireTrap()
    {
        Vector3 bulletDir = transform.up;

        GameObject newBullet = Instantiate(m_bullet, this.transform.position + new Vector3(transform.up.x * m_bulletSpawnPos.x, transform.up.y * m_bulletSpawnPos.y, transform.up.z * m_bulletSpawnPos.z), Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().velocity = bulletDir * m_bulletSpeed;
    }
}
