using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTargetHard : BehaviourBase
{

    //--------------------------------------------------------------------------------------
    // Update behaviours - Get target
    //  Targets player which cannot block attack
    //
    // Return:
    //		Returns a enum BehaviourStatus, current status of behaviour, Success, failed, pending
    //--------------------------------------------------------------------------------------
    public override BehaviourBase.BehaviourStatus Execute()
    {
       
        return BehaviourStatus.SUCCESS;
    }
}
