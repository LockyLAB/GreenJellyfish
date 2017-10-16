using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourBase : MonoBehaviour
{
    //types of return status
    [HideInInspector]
    public enum BehaviourStatus {SUCCESS, FAILURE, PENDING };

    //--------------------------------------------------------------------------------------
    // Update behaviours in tree
    //
    // Param:
    //		deltaTime: change in time since last frame
    //
    // Return:
    //		Returns a enum BehaviourStatus, current status of behaviour, Success, failed, pending
    //--------------------------------------------------------------------------------------
    public virtual BehaviourStatus Execute()
    {
        return BehaviourStatus.FAILURE;
    }
}
