﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeTarget : BehaviourBase
{

    public float m_fleeDistance = 0.0f;
    public float m_maxFleeDuration = 0.0f;

    private float m_time = 0.0f;

    private bool m_behaviourSetup = true;
    //--------------------------------------------------------------------------------------
    // Update behaviours - Flee target to set distance
    //
    // Return:
    //		Returns a enum BehaviourStatus, current status of behaviour, Success, failed, pending
    //--------------------------------------------------------------------------------------
    public override BehaviourBase.BehaviourStatus Execute()
    {
        //Set up basuc 
        if (m_behaviourSetup)
        {
            m_time = m_maxFleeDuration;
            m_behaviourSetup = false;
        }

        Debug.Log("Fleeing");

        //Ensure doesnt flee forever
        m_time -= Time.deltaTime;

        //While still too close
        if (Mathf.Abs(transform.position.x - GetComponent<Enemy>().m_target.transform.position.x) < m_fleeDistance && m_time > 0.0f)
        {
            Vector3 velocity = Vector3.left * Mathf.Sign(GetComponent<Enemy>().m_target.transform.position.x - transform.position.x) * GetComponent<Enemy>().m_forwardSpeed;
            GetComponent<Rigidbody>().velocity = velocity;
            return BehaviourStatus.PENDING;
        }
        m_behaviourSetup = true;
        return BehaviourStatus.SUCCESS;
    }
}
