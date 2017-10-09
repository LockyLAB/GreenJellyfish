using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBase : MonoBehaviour {

    private bool m_triggered = false;

    public int m_numberOfBullets = 0;
    private int m_bulletCount = 0;
    public float m_bulletSpeed = 0.0f;

    public float m_timeBetweenShots = 0.0f;
    private float m_firingTimer = 0.0f;

    public float m_cooldown = 0.0f;
    private float m_cooldownTimer = 0.0f;

    public Vector3 m_bulletOffset = Vector3.zero;

    public GameObject m_bullet = null;

    private void Awake()
    {
        m_bulletOffset = transform.up * 0.5f;
    }

    // Update is called once per frame
    void Update ()
    {
        if(m_triggered)
        {
            //Firing
            if (m_bulletCount > 0)
            {
                m_firingTimer -= Time.deltaTime;
                if (m_firingTimer < 0.0f)
                {
                    //Fire bullet
                    FireTrap();
                    Debug.Log("Firing Trap");
                    m_firingTimer = m_timeBetweenShots;
                    m_bulletCount--;
                }
            }
            //Cooldown
            m_cooldownTimer -= Time.deltaTime;
            if (m_cooldownTimer < 0.0f)
            {
                //Fire bullet
                m_bulletCount = m_numberOfBullets;
                m_cooldownTimer = m_cooldown;
            }
        }
    }

    public void ActivateTrap()
    {
        m_triggered = true;
    }

    public virtual void FireTrap()
    {

    }
}
