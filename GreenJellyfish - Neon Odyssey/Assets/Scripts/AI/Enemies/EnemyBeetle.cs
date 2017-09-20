using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeetle : Enemy
{

	// Use this for initialization
	void Awake ()
    {

        //Check distance
        IsTargetCloseEnough IsTargetCloseEnough5 = this.gameObject.AddComponent<IsTargetCloseEnough>() as IsTargetCloseEnough;
        IsTargetCloseEnough5.SetDistance(5);
        IsTargetCloseEnough IsTargetCloseEnough10 = this.gameObject.AddComponent<IsTargetCloseEnough>() as IsTargetCloseEnough;
        IsTargetCloseEnough5.SetDistance(10);

        //Move towards target
        MoveTowardsTarget MoveTowrads = this.gameObject.AddComponent<MoveTowardsTarget>() as MoveTowardsTarget;

        //Branches
        BehaviourSequence BehaviourSequenceMove = this.gameObject.AddComponent<BehaviourSequence>() as BehaviourSequence;

        BehaviourSequenceMove.AddBranch(IsTargetCloseEnough5);
        BehaviourSequenceMove.AddBranch(MoveTowrads);

        m_initalBehaviour = BehaviourSequenceMove;
    }
	
	// Update is called once per frame
	void Update ()
    {
        m_initalBehaviour.Execute();
    }
}
