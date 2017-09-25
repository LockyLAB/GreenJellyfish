using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsTarget : BehaviourBase
{
    //--------------------------------------------------------------------------------------
    // Update behaviours - Move towards the chosen target
    //
    // Return:
    //		Returns a enum BehaviourStatus, current status of behaviour, Success, failed, pending
    //--------------------------------------------------------------------------------------
    public override BehaviourBase.BehaviourStatus Execute()
    {
        Vector3 velocity = GetComponent<Rigidbody>().velocity;
        velocity = (transform.position - GetComponent<Enemy>().m_target.transform.position).normalized * GetComponent<Enemy>().m_forwardSpeed;
        GetComponent<Rigidbody>().velocity = velocity;
        return BehaviourStatus.SUCCESS;
    }
}
