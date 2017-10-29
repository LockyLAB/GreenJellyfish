using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourSequence : BehaviourComposite
{
    //--------------------------------------------------------------------------------------
    //Update behaviours in tree - AND like
    //
    // Return:
    //		Returns a enum BehaviourStatus, current status of behaviour, Success, failed, pending
    //--------------------------------------------------------------------------------------
    public override BehaviourBase.BehaviourStatus Execute()
    {
        if (!m_pendingBranch)
            BehaviourSetup();

        //Requires only one child to succeed
        while (m_branchNumber < m_behaviourBranches.Count)
        {
            BehaviourBase currentBranch = m_behaviourBranches[m_branchNumber];

            if (!m_pendingBranch)
                currentBranch.BehaviourSetup();
            m_pendingBranch = false;
            BehaviourBase.BehaviourStatus branchStatus = currentBranch.Execute();

            if (branchStatus == BehaviourStatus.FAILURE)
            {
                return BehaviourStatus.FAILURE;
            }
            if (branchStatus == BehaviourStatus.PENDING)
            {
                m_pendingBranch = true;
                return BehaviourStatus.PENDING;
            }
            m_branchNumber++;
        }
        return BehaviourStatus.SUCCESS;
    }
}
