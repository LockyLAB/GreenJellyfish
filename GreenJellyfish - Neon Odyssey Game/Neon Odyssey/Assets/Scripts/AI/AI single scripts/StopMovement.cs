using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---------------------------------------------------------
//-written by: Samuel
//-contributors:
//---------------------------------------------------------

public class StopMovement : BehaviourBase
{
    //--------------------------------------------------------------------------------------
    // Update behaviours - Stop moving animation, audio
    //
    // Return:
    //		Returns a enum BehaviourStatus, current status of behaviour, Success, failed, pending
    //--------------------------------------------------------------------------------------
    public override BehaviourBase.BehaviourStatus Execute()
    {
        gameObject.GetComponent<Animator>().SetBool("Moving", false);

        GetComponent<Rigidbody>().velocity = new Vector3(0.0f, GetComponent<Rigidbody>().velocity.y, 0.0f);

        //Stop movement audio
        if(GetComponent<Enemy>().m_movementAudio != null)
            GetComponent<Enemy>().m_movementAudio.GetComponent<AudioSource>().Stop();

        return BehaviourStatus.SUCCESS;
    }
}
