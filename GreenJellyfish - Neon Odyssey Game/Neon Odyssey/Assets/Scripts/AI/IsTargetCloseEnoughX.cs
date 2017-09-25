using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsTargetCloseEnoughX : BehaviourBase
{
    public float m_targetDistance = 0.0f;

    //--------------------------------------------------------------------------------------
    // Update behaviours - Get the distance to an object in X-axis only
    //
    // Return:
    //		Returns a enum BehaviourStatus, current status of behaviour, Success, failed, pending
    //--------------------------------------------------------------------------------------
    public override BehaviourBase.BehaviourStatus Execute()
    {
        Debug.Log("Checking if its close enough" + m_targetDistance);
        if (Mathf.Abs(transform.position.x - GetComponent<Enemy>().m_target.transform.position.x) < m_targetDistance)
            return BehaviourStatus.SUCCESS;
        return BehaviourStatus.FAILURE;

    }
}
