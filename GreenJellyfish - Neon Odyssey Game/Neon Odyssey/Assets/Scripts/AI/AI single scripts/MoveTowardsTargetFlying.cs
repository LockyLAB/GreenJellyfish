using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsTargetFlying : BehaviourBase
{

    //--------------------------------------------------------------------------------------
    // Inital setup of behaviour, Play audio
    //--------------------------------------------------------------------------------------
    public override void BehaviourSetup()
    {
        //GetComponent<Enemy>().m_movementAudio.Play();
    }

    //--------------------------------------------------------------------------------------
    // Update behaviours - Move towards the chosen target
    //
    // Return:
    //		Returns a enum BehaviourStatus, current status of behaviour, Success, failed, pending
    //--------------------------------------------------------------------------------------
    public override BehaviourBase.BehaviourStatus Execute()
    {
        float velocityX = Mathf.Sign(GetComponent<Enemy>().m_target.transform.position.x - transform.position.x) * GetComponent<Enemy>().m_forwardSpeed;
        Vector3 velocity = GetComponent<Rigidbody>().velocity;
        velocity.x = velocityX;
        GetComponent<Rigidbody>().velocity = velocity;
        return BehaviourStatus.SUCCESS;
    }
}
