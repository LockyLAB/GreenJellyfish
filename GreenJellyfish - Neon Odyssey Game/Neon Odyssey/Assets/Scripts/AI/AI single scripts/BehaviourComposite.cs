using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---------------------------------------------------------
//-written by: Samuel
//-contributors:
//---------------------------------------------------------

public class BehaviourComposite : BehaviourBase
{

    public List<BehaviourBase> m_behaviourBranches = new List<BehaviourBase>();
    [HideInInspector]
    public int m_branchNumber = 0;
    [HideInInspector]
    public bool m_pendingBranch = false;

    //--------------------------------------------------------------------------------------
    // Inital setup of behaviour, e.g. setting timer to 0.0f
    //--------------------------------------------------------------------------------------
    public override void BehaviourSetup()
    {
        m_branchNumber = 0;
    }


    public void AddBranch(BehaviourBase behaviour)
    {
        m_behaviourBranches.Add(behaviour);
    }
}
