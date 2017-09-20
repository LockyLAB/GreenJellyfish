using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsTargetCloseEnough : BehaviourBase
{
    private float m_targetDistance = 0.0f;

    public void SetDistance(float targetDistance)
    {
        m_targetDistance = targetDistance;
    }

    //--------------------------------------------------------------------------------------
    // Update behaviours - Get the distance to an object
    //
    // Return:
    //		Returns a enum BehaviourStatus, current status of behaviour, Success, failed, pending
    //--------------------------------------------------------------------------------------
    public override BehaviourBase.BehaviourStatus Execute()
    {
        if ((transform.position - GetComponent<Enemy>().m_target.transform.position).magnitude < m_targetDistance)
            return BehaviourStatus.SUCCESS;
        return BehaviourStatus.FAILURE;
    }
}
