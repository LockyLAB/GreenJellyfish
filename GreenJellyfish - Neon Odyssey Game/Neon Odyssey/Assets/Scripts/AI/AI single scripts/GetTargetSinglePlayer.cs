using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---------------------------------------------------------
//-written by: Samuel
//-contributors:
//---------------------------------------------------------

public class GetTargetSinglePlayer : BehaviourBase
{

    //Ankh and Flail
    private GameObject m_player1 = null;

    void Start()
    {
        //Assign players
        m_player1 = GameObject.FindWithTag("GameController").GetComponent<GameManager>().m_player1;
    }

    //--------------------------------------------------------------------------------------
    // Update behaviours - Get target
    // Aims for closest player which isnt same colour
    //
    // Return:
    //		Returns a enum BehaviourStatus, current status of behaviour, Success, failed, pending
    //--------------------------------------------------------------------------------------
    public override BehaviourBase.BehaviourStatus Execute()
    {
        Enemy enemyClass = GetComponent<Enemy>();

        enemyClass.m_target = m_player1;

        if (enemyClass.m_target != null && !m_player1.GetComponent<Player>().IsDead())
            return BehaviourStatus.SUCCESS;

        return BehaviourStatus.FAILURE;
    }
}
