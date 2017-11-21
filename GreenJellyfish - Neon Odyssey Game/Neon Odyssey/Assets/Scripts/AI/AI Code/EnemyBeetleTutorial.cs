using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeetleTutorial : Enemy
{
    //Movement
    public float m_moveTowardsRange = 0.0f;

    //Nodes
    private BehaviourSequence m_sequenceTop;

    private BehaviourSequence m_sequenceMove;

    private IsTargetCloseEnough m_actionGetDisMovement;
    private MoveTowardsTarget m_actionMovetowards;

    private BehaviourBase m_actionGetTarget;

    //-----------------------------------------------------
    // Setting up all AI behaviour components
    //
    // Just move towards player 
    //-----------------------------------------------------
    void Start ()
    {

        //Set up varibles
        m_sequenceTop = gameObject.AddComponent<BehaviourSequence>();
        m_sequenceMove = gameObject.AddComponent<BehaviourSequence>();

        m_actionGetDisMovement = gameObject.AddComponent<IsTargetCloseEnough>();
        m_actionMovetowards = gameObject.AddComponent<MoveTowardsTarget>();

        m_actionGetTarget = gameObject.AddComponent<GetTargetSinglePlayer>();


        //Movement
        m_actionGetDisMovement.m_targetDistance = m_moveTowardsRange;

        //Set up branches
        m_sequenceTop.m_behaviourBranches.Add(m_actionGetTarget as BehaviourBase);
        m_sequenceTop.m_behaviourBranches.Add(m_sequenceMove);

        m_sequenceMove.m_behaviourBranches.Add(m_actionGetDisMovement);
        m_sequenceMove.m_behaviourBranches.Add(m_actionMovetowards);

        m_initalBehaviour = m_sequenceTop;
    }
}
