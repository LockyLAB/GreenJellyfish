using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTargetHard : BehaviourBase
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
        else if (players[1].GetComponent<P1ColourController>() != null)
            m_player1 = players[1];

        //Assign player 1
        if (players[0].GetComponent<P2ColourController>() != null)
            m_player2 = players[0];
        else if (players[1].GetComponent<P2ColourController>() != null)
            m_player2 = players[1];
    }
    //--------------------------------------------------------------------------------------
    // Update behaviours - Get target
    //  Targets player which cannot block attack
    //
    // Return:
    //		Returns a enum BehaviourStatus, current status of behaviour, Success, failed, pending
    //--------------------------------------------------------------------------------------
    public override BehaviourBase.BehaviourStatus Execute()
    {
        Enemy enemyClass = GetComponent<Enemy>();

        //Set target based off prefered target and distance
        float player1TargetRank = 1.0f;
        float player2TargetRank = 1.0f;

        if (gameObject.layer == LayerMask.NameToLayer("Purple") || gameObject.layer == LayerMask.NameToLayer("Orange"))
            player2TargetRank = 2.0f;
        if (gameObject.layer == LayerMask.NameToLayer("Pink") || gameObject.layer == LayerMask.NameToLayer("Green"))
            player1TargetRank = 2.0f;

        player1TargetRank = 1 / Mathf.Abs(transform.position.x - m_player1.transform.position.x) * player1TargetRank;
        player2TargetRank = 1 / Mathf.Abs(transform.position.x - m_player2.transform.position.x) * player2TargetRank;

        if (player1TargetRank > player2TargetRank)
            enemyClass.m_target = m_player1;
        else
            enemyClass.m_target = m_player2;

        if (enemyClass.m_target != null)
            return BehaviourStatus.SUCCESS;

        Debug.Log("Cant find a target");
        return BehaviourStatus.FAILURE;
    }
}
