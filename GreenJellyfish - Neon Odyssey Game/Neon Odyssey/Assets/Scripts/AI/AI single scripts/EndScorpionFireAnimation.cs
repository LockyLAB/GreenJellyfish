using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---------------------------------------------------------
//-written by: Samuel
//-contributors:
//---------------------------------------------------------

public class EndScorpionFireAnimation : BehaviourBase
{

    //--------------------------------------------------------------------------------------
    // Update behaviours - Stop the animation triggers set during each firing stage
    //
    // Return:
    //		Returns a enum BehaviourStatus, current status of behaviour, Success, failed, pending
    //--------------------------------------------------------------------------------------
    public override BehaviourBase.BehaviourStatus Execute()
    {
        gameObject.GetComponent<Animator>().ResetTrigger("Firing"); // Animation
        return BehaviourStatus.SUCCESS;
    }
}
