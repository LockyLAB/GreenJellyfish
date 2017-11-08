using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : BehaviourBase
{

    public GameObject m_bullet;

    public int m_numberOfBullets = 0;
    private int m_bulletCount = 0;
    public float m_bulletSpeed = 0.0f;

    public float m_timeBetweenShots = 0.0f;
    private float m_time = 0.0f;

    public Vector3 m_bulletSpawnPos = Vector3.up * 0.5f;

    //--------------------------------------------------------------------------------------
    // Inital setup of behaviour, e.g. setting timer to 0.0f
    //--------------------------------------------------------------------------------------
    public override void BehaviourSetup()
    {
        m_bulletCount = 0;
        m_time = m_timeBetweenShots;

        GetComponent<Rigidbody>().velocity = new Vector3(0.0f, GetComponent<Rigidbody>().velocity.y, 0.0f);

        gameObject.GetComponent<Animator>().SetTrigger("Firing"); // Animation
        //TODO Add audio playing here

    }

    //--------------------------------------------------------------------------------------
    // Update behaviours - Fire Towards target
    //
    // Return:
    //		Returns a enum BehaviourStatus, current status of behaviour, Success, failed, pending
    //--------------------------------------------------------------------------------------
    public override BehaviourBase.BehaviourStatus Execute()
    {
        m_time -= Time.deltaTime;

        if (m_time < 0.0f)
        {
            m_time = m_timeBetweenShots;
            m_bulletCount++;

            //Fire bullet
            Vector3 bulletDir = (GetComponent<Enemy>().m_target.transform.position - transform.position).normalized;
            FireBullet(bulletDir);

            if (m_bulletCount < m_numberOfBullets)
                return BehaviourStatus.PENDING;
            else
                gameObject.GetComponent<Animator>().SetTrigger("Firing"); // Animation
        }

        if (m_bulletCount < m_numberOfBullets)
            return BehaviourStatus.PENDING;

        return BehaviourStatus.SUCCESS;
    }

    //--------------------------------------------------------------------------------------
    // Firing of bullet towards target
    //
    // Return:
    //		Returns a enum BehaviourStatus, current status of behaviour, Success, failed, pending
    //--------------------------------------------------------------------------------------
    void FireBullet(Vector3 bulletDir)
    {
        GameObject newBullet = Instantiate(m_bullet, transform.TransformPoint(m_bulletSpawnPos), Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().velocity = bulletDir * m_bulletSpeed;
        newBullet.GetComponent<Bullet>().SetTeam(Bullet.TEAM.ENEMY);
    }
}
