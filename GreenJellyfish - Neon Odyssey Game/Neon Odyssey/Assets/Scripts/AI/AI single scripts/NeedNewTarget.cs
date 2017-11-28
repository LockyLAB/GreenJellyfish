using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---------------------------------------------------------
//-written by: Samuel
//-contributors:
//---------------------------------------------------------

public class NeedNewTarget : BehaviourBase
{

    //--------------------------------------------------------------------------------------
    // Update behaviours - Decide if a new target is needed
    //
    // Return:
    //		Returns a enum BehaviourStatus, current status of behaviour, Success, failed, pending
    //--------------------------------------------------------------------------------------
    public override BehaviourBase.BehaviourStatus Execute()
    {
        if(GetComponent<Enemy>().m_target == null)
            return BehaviourStatus.SUCCESS;
        return BehaviourStatus.FAILURE;
    }
}
