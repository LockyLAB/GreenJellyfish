﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCone : BehaviourBase
{

    public GameObject m_bullet;

    public int m_numberOfBullets = 0;
    private int m_bulletCount = 0;
    public float m_bulletSpeed = 0.0f;

    public float m_rateOfFire = 0.0f;
    private float m_time = 0.0f;

    public float m_fireCone = 0.0f;

    private bool m_behaviourSetup = true;
    //--------------------------------------------------------------------------------------
    // Update behaviours - Cone Fire Towards target
    //
    // Return:
    //		Returns a enum BehaviourStatus, current status of behaviour, Success, failed, pending
    //--------------------------------------------------------------------------------------
    public override BehaviourBase.BehaviourStatus Execute()
    {
        Debug.Log("Firing");

        if (m_behaviourSetup)
        {
            //Start numbers of bullets to fire
            m_bulletCount = 0;
            m_time = m_rateOfFire;
            m_behaviourSetup = false;
        }

        m_time -= Time.deltaTime;

        if (m_time < 0.0f)
        {
            m_time = m_rateOfFire;
            m_bulletCount++;

            //Fire bullet
            Vector3 bulletDir = (GetComponent<Enemy>().m_target.transform.position - transform.position).normalized;
            FireBullet(Quaternion.Euler(0, 0, m_fireCone) * bulletDir);
            FireBullet(bulletDir);
            FireBullet(Quaternion.Euler(0, 0, -m_fireCone) * bulletDir);
        }

        if (m_bulletCount < m_numberOfBullets)
            return BehaviourStatus.PENDING;

        //Reset all varibles
        m_behaviourSetup = true;
        return BehaviourStatus.SUCCESS;
    }

    void FireBullet(Vector3 bulletDir)
    {
        GameObject newBullet = Instantiate(m_bullet, this.transform.position, Quaternion.Euler(bulletDir));
        newBullet.GetComponent<Rigidbody>().velocity = bulletDir * m_bulletSpeed;
    }
}
