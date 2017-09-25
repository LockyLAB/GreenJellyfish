﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsTargetX : BehaviourBase
{
    //--------------------------------------------------------------------------------------
    // Update behaviours - Move towards the chosen target
    //
    // Return:
    //		Returns a enum BehaviourStatus, current status of behaviour, Success, failed, pending
    //--------------------------------------------------------------------------------------
    public override BehaviourBase.BehaviourStatus Execute()
    {
        Debug.Log("Moving towards");
        Vector3 velocity = Vector3.right * Mathf.Sign(GetComponent<Enemy>().m_target.transform.position.x - transform.position.x) * GetComponent<Enemy>().m_forwardSpeed;
        GetComponent<Rigidbody>().velocity = velocity;

        return BehaviourStatus.SUCCESS;
    }
}
