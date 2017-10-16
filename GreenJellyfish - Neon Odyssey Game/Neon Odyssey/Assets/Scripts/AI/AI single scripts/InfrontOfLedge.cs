using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfrontOfLedge : BehaviourBase
{

    public float m_targetDistance = 0.0f;

    //--------------------------------------------------------------------------------------
    // Update behaviours - Is there a ledge in front 
    //
    // Return:
    //		Returns a enum BehaviourStatus, current status of behaviour, Success, failed, pending
    //--------------------------------------------------------------------------------------
    public override BehaviourBase.BehaviourStatus Execute()
    {
        if (Physics.Raycast(transform.position + transform.forward * 2 + transform.up * 0.1f, Vector3.down, 0.5f, LayerMask.NameToLayer("Ground")))
            return BehaviourStatus.FAILURE;
        return BehaviourStatus.SUCCESS;
    }
}
