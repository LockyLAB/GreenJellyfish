using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourSelector : BehaviourComposite
{

    //--------------------------------------------------------------------------------------
    // Update behaviours in tree - OR like
    //
    // Return:
    //		Returns a enum BehaviourStatus, current status of behaviour, Success, failed, pending
    //--------------------------------------------------------------------------------------
    public override BehaviourBase.BehaviourStatus Execute()
    {
        //Run through each child, similar to OR operation.
        if (!m_pendingBranch)
            m_branchNumber = 0;
        m_pendingBranch = false;

        //Requires only one child to succeed
        while (m_branchNumber < m_behaviourBranches.Count)
        {
            BehaviourBase currentBranch = m_behaviourBranches[m_branchNumber];

            BehaviourBase.BehaviourStatus branchStatus = currentBranch.Execute();

            if (branchStatus == BehaviourStatus.SUCCESS)
                return BehaviourStatus.SUCCESS;
            if (branchStatus == BehaviourStatus.PENDING)
            {
                m_pendingBranch = true;
                return BehaviourStatus.PENDING;
            }
            m_branchNumber++;
        }
        return BehaviourStatus.FAILURE;
    }
}
