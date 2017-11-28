using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---------------------------------------------------------
//-written by: Samuel
//-contributors:
//---------------------------------------------------------

public class TrapBase : MonoBehaviour {

    public bool m_triggered = false;

    public int m_numberOfBullets = 0;
    private int m_bulletCount = 0;
    public float m_bulletSpeed = 0.0f;

    public float m_timeBetweenShots = 0.0f;
    public float m_firingTimer = 0.0f;

    public float m_intialDelay = 0.0f;
    public float m_intialDelayTimer = 0.0f;

    public float m_cooldown = 0.0f;
    public float m_cooldownTimer = 0.0f;

    public Vector3 m_bulletSpawnPos = Vector3.up;

    public GameObject m_bullet = null;

    //--------------------------------------------------------------------------------------
    // Update
    // Run intial delay
    // Firing sequence
    //--------------------------------------------------------------------------------------
    void Update ()
    {
        //Do nothing till intial delay is gone 
        if(!m_triggered)
            return;

        m_intialDelayTimer += Time.deltaTime;

        //On trigger start firing trap
        if (m_intialDelayTimer >= m_intialDelay)
        {
            //Firing
            if (m_bulletCount < m_numberOfBullets)
            {
                m_firingTimer += Time.deltaTime;
                if (m_firingTimer > m_timeBetweenShots)
                {
                    //Fire bullet
                    FireTrap();
                    m_firingTimer = 0.0f;
                    m_bulletCount++;
                }
            }
            else
            {
                //Cooldown
                m_cooldownTimer += Time.deltaTime;
                if (m_cooldownTimer > m_cooldown)
                {
                    //Fire bullet
                    m_bulletCount = 0;
                    m_cooldownTimer = 0.0f;
                    m_firingTimer = 0.0f;
                }
            }
        }
    }

    //--------------------------------------------------------------------------------------
    // Set trap to be activated
    //--------------------------------------------------------------------------------------
    public void ActivateTrap()
    {
        m_triggered = true;
    }

    //--------------------------------------------------------------------------------------
    // Set trap to be deactivated
    //--------------------------------------------------------------------------------------
    public void DeactivateTrap()
    {
        m_triggered = false;
    }

    //--------------------------------------------------------------------------------------
    // Firing of a bullet
    //--------------------------------------------------------------------------------------
    public virtual void FireTrap()
    {

    }

    //--------------------------------------------------------------------------------------
    // Fire a bullet
    //
    // Param:
    //		bulletDir: direction bullet should travel
    //--------------------------------------------------------------------------------------
    public void FireBullet(Vector3 bulletDir)
    {
        GameObject newBullet = Instantiate(m_bullet, transform.TransformPoint(m_bulletSpawnPos), Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().velocity = bulletDir * m_bulletSpeed;
        if(gameObject.tag == "Player")
            newBullet.GetComponent<Bullet>().SetTeam(Bullet.TEAM.PLAYER);
        if (gameObject.tag == "Enemy")
            newBullet.GetComponent<Bullet>().SetTeam(Bullet.TEAM.ENEMY);
    }
}
