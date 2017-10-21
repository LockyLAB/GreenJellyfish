using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTargetEasy : BehaviourBase
{

    //Ankh and Flail
    private GameObject m_player1 = null;

    //Lotus and Shen
    private GameObject m_player2 = null;

    void Start()
    {
        //Assign players
        m_player1 = GameObject.FindWithTag("GameController").GetComponent<GameManager>().m_player1;
        m_player2 = GameObject.FindWithTag("GameController").GetComponent<GameManager>().m_player2;
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

        //Set target based off prefered target and distance
        float player1TargetRank = 1.0f;
        float player2TargetRank = 1.0f;

        float player1Distance = (transform.position - m_player1.transform.position).magnitude;
        float player2Distance = (transform.position - m_player2.transform.position).magnitude;

        if (gameObject.layer == LayerMask.NameToLayer("Purple") || gameObject.layer == LayerMask.NameToLayer("Orange"))
            player1TargetRank = 2.0f;
        if (gameObject.layer == LayerMask.NameToLayer("Pink") || gameObject.layer == LayerMask.NameToLayer("Green"))
            player2TargetRank = 2.0f;

        //Make sure enemy can see player
        if (Physics.Raycast(transform.position + transform.up * 0.5f, (m_player1.transform.position - transform.position).normalized, player1Distance, LayerMask.GetMask("Collisions")))
            player1TargetRank = -100.0f;

        //Make sure enemy can see player
        if (Physics.Raycast(transform.position + transform.up * 0.5f, (m_player2.transform.position - transform.position).normalized, player2Distance, LayerMask.GetMask("Collisions")))
            player2TargetRank = -100.0f;

        player1TargetRank = player1TargetRank / player1Distance;
        player2TargetRank = player2TargetRank / player2Distance;

        if (player1TargetRank > player2TargetRank)
            enemyClass.m_target = m_player1;
        else
            enemyClass.m_target = m_player2;

        if (player1TargetRank < 0 && player2TargetRank < 0)
            enemyClass.m_target = null;

        if (enemyClass.m_target != null)
            return BehaviourStatus.SUCCESS;

        return BehaviourStatus.FAILURE;
    }
}
