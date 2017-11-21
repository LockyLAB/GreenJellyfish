using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsTarget : BehaviourBase
{

    //--------------------------------------------------------------------------------------
    // Inital setup of behaviour, Play audio
    //--------------------------------------------------------------------------------------
    public override void BehaviourSetup()
    {
        if (!GetComponent<Enemy>().m_movementAudio.GetComponent<AudioSource>().isPlaying)
            GetComponent<Enemy>().m_movementAudio.GetComponent<AudioSource>().Play();

        gameObject.GetComponent<Animator>().SetBool("Moving", true);
    }

    //--------------------------------------------------------------------------------------
    // Update behaviours - Move towards the chosen target
    //
    // Return:
    //		Returns a enum BehaviourStatus, current status of behaviour, Success, failed, pending
    //--------------------------------------------------------------------------------------
    public override BehaviourBase.BehaviourStatus Execute()
    {
        Vector3 velocity = (GetComponent<Enemy>().m_target.transform.position - transform.position).normalized * GetComponent<Enemy>().m_forwardSpeed;
        GetComponent<Rigidbody>().velocity = velocity;

        return BehaviourStatus.SUCCESS;
    }
}
