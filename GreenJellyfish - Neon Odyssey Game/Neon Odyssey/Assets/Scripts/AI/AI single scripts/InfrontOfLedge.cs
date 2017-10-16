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

        Bounds bounds = GetComponent<SphereCollider>().bounds;

        Debug.DrawLine(transform.position + transform.forward * bounds.size.z / 2, transform.position + transform.forward * bounds.size.z / 2 + (-transform.up * (bounds.size.z / 2 + 0.1f)), Color.red);

        if (Physics.Raycast(transform.position + transform.forward * bounds.size.z/2, -transform.up, bounds.size.z /2 + 0.1f))
        {
            return BehaviourStatus.FAILURE;
        }
        return BehaviourStatus.SUCCESS;
    }
}
