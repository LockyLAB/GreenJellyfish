using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeTarget : BehaviourBase
{

    public float m_fleeDistance = 0.0f;

    //--------------------------------------------------------------------------------------
    // Update behaviours - Flee target to set distance
    //
    // Return:
    //		Returns a enum BehaviourStatus, current status of behaviour, Success, failed, pending
    //--------------------------------------------------------------------------------------
    public override BehaviourBase.BehaviourStatus Execute()
    {
        Debug.Log("Fleeing");
        //While still too close
        if (Mathf.Abs(transform.position.x - GetComponent<Enemy>().m_target.transform.position.x) < m_fleeDistance)
        {
            Vector3 velocity = Vector3.left * Mathf.Sign(GetComponent<Enemy>().m_target.transform.position.x - transform.position.x) * GetComponent<Enemy>().m_forwardSpeed;
            GetComponent<Rigidbody>().velocity = velocity;
            return BehaviourStatus.PENDING;
        }
        return BehaviourStatus.SUCCESS;
    }
}
