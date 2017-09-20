using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourComposite : BehaviourBase
{
    public List<BehaviourBase> m_behaviourBranches;
    public int m_branchNumber = 0;
    public bool m_pendingBranch = false;

    public void AddBranch(BehaviourBase behaviour)
    {
        m_behaviourBranches.Add(behaviour);
    }
}
