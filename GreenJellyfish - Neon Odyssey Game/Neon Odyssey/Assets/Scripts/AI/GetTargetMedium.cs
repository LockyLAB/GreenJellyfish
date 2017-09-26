using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTargetMedium : BehaviourBase
{

    //--------------------------------------------------------------------------------------
    // Update behaviours - Get target
    // Aims for closest player which isnt same colour
    //
    // Return:
    //		Returns a enum BehaviourStatus, current status of behaviour, Success, failed, pending
    //--------------------------------------------------------------------------------------
    public override BehaviourBase.BehaviourStatus Execute()
    {
     
        return BehaviourStatus.SUCCESS;
    }
}
