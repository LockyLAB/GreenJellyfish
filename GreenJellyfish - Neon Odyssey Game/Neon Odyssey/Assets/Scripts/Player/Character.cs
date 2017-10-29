﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private int m_health = 1;

    private float m_invicibleTime = 1.0f;
    private float m_invicibleTimer = 0.0f;

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
        if(m_invicibleTimer <= 0.0f)//take damage from other sources
        {
            m_health += changeVal;
            m_invicibleTimer = m_invicibleTime;
        }
    }

    public virtual void CharaterActions()
    {

    }
}
