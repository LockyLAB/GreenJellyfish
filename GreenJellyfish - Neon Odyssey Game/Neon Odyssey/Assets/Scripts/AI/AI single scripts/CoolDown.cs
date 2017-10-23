using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolDown : BehaviourBase
{

    public float m_coolDown = 0.0f;
    private float m_time = 0.0f;


    //--------------------------------------------------------------------------------------
    // Inital setup of behaviour, e.g. setting timer to 0.0f
    //--------------------------------------------------------------------------------------
    public override void BehaviourSetup()
    {
        m_time = m_coolDown;
    }

    //--------------------------------------------------------------------------------------
    // Update behaviours - Do nothing till timer runs out
    //
    // Return:
    //		Returns a enum BehaviourStatus, current status of behaviour, Success, failed, pending
    //--------------------------------------------------------------------------------------
    public override BehaviourBase.BehaviourStatus Execute()
    {
        m_time -= Time.deltaTime;

        if (m_time < 0.0f)
            return BehaviourStatus.SUCCESS;
        return BehaviourStatus.PENDING;
    }
}
