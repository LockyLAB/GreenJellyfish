﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private int m_health = 1;
    public int m_healthMax = 1;

    public float m_invicibleTime = 1.0f;
    private float m_invicibleTimer = 0.0f;

    public float m_flashSpeed = 5.0f;
    private float amp = 0.25f;
    private float vertShift = 0.25f;


    public SkinnedMeshRenderer m_characterRenderer = null;

    public void Update()
    {
        m_invicibleTimer -= Time.deltaTime;
        CharaterActions();
    }

    public bool IsDead()
    {
        return (m_health <= 0);
    }

    //Used to alter health
    public int GetHealth()
    {
        return m_health;
    }

    //Used to alter health
    public void SetHealth(int changeVal)
    {
        m_health = changeVal;
    }

    //Used to alter health
    public void ChangeHealth(int changeVal)
    {
        if (changeVal < 0) //Loosing health
        {
            if (m_invicibleTimer <= 0.0f)//take damage from other sources
            {
                m_health += changeVal;
                m_invicibleTimer = m_invicibleTime;
                if (m_health < 0)
                    m_health = 0;
                if (GetComponent<Player>() != null)
                    GetComponent<Player>().m_childRenderer.GetComponentInChildren<SkinnedMeshRenderer>().material.SetFloat("_Clipping", amp * Mathf.Sin(m_flashSpeed * Time.time) + vertShift);
            }
            else
            {
                if (GetComponent<Player>() != null)
                    GetComponent<Player>().m_childRenderer.GetComponentInChildren<SkinnedMeshRenderer>().material.SetFloat("_Clipping", 0);
            }

        }
        else // Gain health
        {
            m_health += changeVal;
        }

        //Keep health within bounds
        if (m_health > m_healthMax)
            m_health = m_healthMax;
    }

    public virtual void CharaterActions()
    {

    }
}
