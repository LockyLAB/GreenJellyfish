using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTargetSinglePlayer : BehaviourBase
{

    //Ankh and Flail
    private GameObject m_player1 = null;

    void Awake()
    {
        GameObject[] players;
        players = GameObject.FindGameObjectsWithTag("Player");

        //Assign player 1
        m_player1 = players[0];
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

        if (enemyClass.m_target != null)
            return BehaviourStatus.SUCCESS;
        Debug.Log("No player found");
        return BehaviourStatus.FAILURE;
    }
}
