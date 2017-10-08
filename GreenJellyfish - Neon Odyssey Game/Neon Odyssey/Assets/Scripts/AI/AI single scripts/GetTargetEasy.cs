using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTargetEasy : BehaviourBase
{

    //Ankh and Flail
    private GameObject m_player1 = null;

    //Lotus and Shen
    private GameObject m_player2 = null;

    void Awake()
    {
        GameObject[] players;
        players = GameObject.FindGameObjectsWithTag("Player");

        //Assign player 1
        if (players[0].GetComponent<P1ColourController>() != null)
            m_player1 = players[0];
        else if(players[1].GetComponent<P1ColourController>() != null)
            m_player1 = players[1];

        //Assign player 1
        if (players[0].GetComponent<P2ColourController>() != null)
            m_player2 = players[0];
        else if (players[1].GetComponent<P2ColourController>() != null)
            m_player2 = players[1];
    }

    //--------------------------------------------------------------------------------------
    // Update behaviours - Get target
    // Will aim for a player which can block the bullet
    //
    // Return:
    //		Returns a enum BehaviourStatus, current status of behaviour, Success, failed, pending
    //--------------------------------------------------------------------------------------
    public override BehaviourBase.BehaviourStatus Execute()
    {
        Enemy enemyClass = GetComponent<Enemy>();
        if (enemyClass.CompareTag("EnemyPurple") || enemyClass.CompareTag("EnemyPink"))
            enemyClass.m_target = m_player1;
        if (enemyClass.CompareTag("EnemyOrange") || enemyClass.CompareTag("EnemyGreen"))
            enemyClass.m_target = m_player2;

        if (enemyClass.m_target != null)
            return BehaviourStatus.SUCCESS;
        return BehaviourStatus.FAILURE;
    }
}
