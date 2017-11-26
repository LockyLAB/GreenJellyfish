using System.Collections;
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

    public GameObject m_childRenderer = null; // gets renderer for child

    public void Update()
    {
        //As shared by enemy and player, Character actions is used for custom update functionality
        CharaterActions();

        //Invicibility 
        m_invicibleTimer -= Time.deltaTime;
        if (m_invicibleTimer > 0.0f)//take damage from other sources
        {
            if (GetComponent<Player>() != null)
                GetComponent<Player>().m_childRenderer.GetComponentInChildren<SkinnedMeshRenderer>().material.SetFloat("_Clipping", amp * Mathf.Sin(m_flashSpeed * Time.time) + vertShift);
        }
        else
        {
            if (GetComponent<Player>() != null)
                GetComponent<Player>().m_childRenderer.GetComponentInChildren<SkinnedMeshRenderer>().material.SetFloat("_Clipping", 0);
        }
    }

    //--------------------------------------------------------------------------------------
    // Determine if character is dead 
    //
    // Return:
    //		bool - true when health is equal or less than 0
    //--------------------------------------------------------------------------------------
    public bool IsDead()
    {
        return (m_health <= 0);
    }

    //--------------------------------------------------------------------------------------
    // get characters health
    //
    // Return:
    //		int - characters health
    //--------------------------------------------------------------------------------------
    public int GetHealth()
    {
        return m_health;
    }

    //--------------------------------------------------------------------------------------
    // Set characters health
    //
    // Param:
    //		changeVal: how much health chaacter should have
    //--------------------------------------------------------------------------------------
    public void SetHealth(int changeVal)
    {
        m_health = changeVal;
    }

    //--------------------------------------------------------------------------------------
    // Add health to character, negitve values for dmaage
    //
    // Param:
    //		changeVal: how much to change health by
    //--------------------------------------------------------------------------------------
    public void ChangeHealth(int changeVal)
    {
        if (changeVal < 0) //Loosing health
        {
            if (m_invicibleTimer <= 0.0f)//take damage from other sources
            {
                m_invicibleTimer = m_invicibleTime;
                m_health += changeVal;

                //Keep health within bounds
                if (m_health < 0)
                    m_health = 0;
            }

        }
        else // Gain health
        {
            m_health += changeVal;

            //Keep health within bounds
            if (m_health > m_healthMax)
                m_health = m_healthMax;
        }
    }

    //--------------------------------------------------------------------------------------
    // Actions charater should perform in update
    //--------------------------------------------------------------------------------------
    public virtual void CharaterActions()
    {

    }
}
