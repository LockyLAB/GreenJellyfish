using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTargetEasy : BehaviourBase
{

    //--------------------------------------------------------------------------------------
    // Update behaviours - Get target
    // Will aim for a player which can block the bullet
    //
    // Return:
    //		Returns a enum BehaviourStatus, current status of behaviour, Success, failed, pending
    //--------------------------------------------------------------------------------------
    public override BehaviourBase.BehaviourStatus Execute()
    {
       
        return BehaviourStatus.SUCCESS;
    }
}
