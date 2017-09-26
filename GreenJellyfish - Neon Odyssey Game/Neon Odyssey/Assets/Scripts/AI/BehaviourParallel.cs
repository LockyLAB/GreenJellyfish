using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourParallel : BehaviourComposite
{
    [HideInInspector]
    public List<BehaviourBase> m_behaviourBranchesPending;

    //--------------------------------------------------------------------------------------
    //Update behaviours in tree - All children run regardless of result.
    //  Any children that return pending will be ran again next frame, Sucesses will not
    //
    // Return:
    //		Returns a enum BehaviourStatus, current status of behaviour, Success, failed, pending
    //--------------------------------------------------------------------------------------
    public override BehaviourBase.BehaviourStatus Execute()
    {
        BehaviourStatus state = BehaviourStatus.SUCCESS;

        //Run pending states
        if(m_behaviourBranchesPending.Count>0)
        {

            for (int i = 0; i < m_behaviourBranchesPending.Count; i++)
            {
                BehaviourStatus branchState = m_behaviourBranchesPending[i].Execute();

                if(branchState != BehaviourStatus.PENDING)
                {
                    m_behaviourBranchesPending.RemoveAt(i);
                    i--;
                }
            }
        }
        else
        {
            //Run all 
            for (int i = 0; i < m_behaviourBranches.Count; i++)
            {
                BehaviourStatus branchState = m_behaviourBranches[i].Execute();

                if (branchState == BehaviourStatus.PENDING)
                {
                    m_behaviourBranchesPending.Add(m_behaviourBranches[i]);
                    state = BehaviourStatus.PENDING;
                }
            }
        }
        return state;
    }
}
