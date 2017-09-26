using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourComposite : BehaviourBase
{
    public string m_nameOfComponent = "";

    public List<BehaviourBase> m_behaviourBranches;
    [HideInInspector]
    public int m_branchNumber = 0;
    [HideInInspector]
    public bool m_pendingBranch = false;

    public void AddBranch(BehaviourBase behaviour)
    {
        m_behaviourBranches.Add(behaviour);
    }
}
