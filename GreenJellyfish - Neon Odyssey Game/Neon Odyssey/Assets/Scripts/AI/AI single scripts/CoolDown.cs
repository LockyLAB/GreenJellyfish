using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolDown : BehaviourBase
{

    public float m_coolDown = 0.0f;
    private float m_time = 0.0f;

    private bool m_behaviourSetup = true;
    //--------------------------------------------------------------------------------------
    // Update behaviours - Do nothing till timer runs out
    //
    // Return:
    //		Returns a enum BehaviourStatus, current status of behaviour, Success, failed, pending
    //--------------------------------------------------------------------------------------
    public override BehaviourBase.BehaviourStatus Execute()
    {

        if (m_behaviourSetup)
        {
            m_time = m_coolDown;
            m_behaviourSetup = false;
        }

        m_time -= Time.deltaTime;

        if (m_time > 0.0f)
            return BehaviourStatus.PENDING;

        m_behaviourSetup = true;
        return BehaviourStatus.SUCCESS;
    }
}
