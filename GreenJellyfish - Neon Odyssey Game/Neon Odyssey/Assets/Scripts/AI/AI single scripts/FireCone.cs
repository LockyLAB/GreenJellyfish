using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCone : BehaviourBase
{

    public GameObject m_bullet;

    public int m_numberOfBullets = 0;
    private int m_bulletCount = 0;
    public float m_bulletSpeed = 0.0f;

    public float m_timeBetweenShots = 0.0f;
    private float m_time = 0.0f;

    public float m_fireCone = 0.0f;

    public float m_maxDis = 0.0f;

    public Vector3 m_bulletSpawnPos = Vector3.up * 0.5f;

    //--------------------------------------------------------------------------------------
    // Inital setup of behaviour, e.g. setting timer to 0.0f
    //--------------------------------------------------------------------------------------
    public override void BehaviourSetup()
    { 
        m_bulletCount = 0;
        m_time = m_timeBetweenShots;

        GetComponent<Rigidbody>().velocity = new Vector3(0.0f, GetComponent<Rigidbody>().velocity.y, 0.0f);
    }

    //--------------------------------------------------------------------------------------
    // Update behaviours - Cone Fire Towards target
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
            FireBullet(Quaternion.Euler(0, 0, m_fireCone) * bulletDir);
            FireBullet(bulletDir);
            FireBullet(Quaternion.Euler(0, 0, -m_fireCone) * bulletDir);

            //Firing animation
            //gameObject.GetComponent<Animator>().SetTrigger("Firing");
            gameObject.GetComponent<Animator>().SetBool("Firing", true);
        }

        gameObject.GetComponent<Animator>().SetBool("Firing", false);

        if (!CloseEnough())
            return BehaviourStatus.FAILURE;

        if (m_bulletCount < m_numberOfBullets)
            return BehaviourStatus.PENDING;

        //Reset all varibles
        return BehaviourStatus.SUCCESS;
    }

    bool CloseEnough()
    {
        return (Mathf.Abs(transform.position.x - GetComponent<Enemy>().m_target.transform.position.x) < m_maxDis);
    }

    void FireBullet(Vector3 bulletDir)
    {
        GameObject newBullet = Instantiate(m_bullet, transform.TransformPoint(m_bulletSpawnPos), Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().velocity = bulletDir * m_bulletSpeed;
        newBullet.GetComponent<Bullet>().SetTeam(Bullet.TEAM.ENEMY);
    }
}
