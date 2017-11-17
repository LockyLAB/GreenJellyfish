using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTargetHard : BehaviourBase
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

        float player1Distance = (transform.position - m_player1.transform.position).magnitude;
        float player2Distance = (transform.position - m_player2.transform.position).magnitude;

        if (gameObject.layer == LayerMask.NameToLayer("Purple") || gameObject.layer == LayerMask.NameToLayer("Orange"))
            player1TargetRank = 2.0f;
        if (gameObject.layer == LayerMask.NameToLayer("Pink") || gameObject.layer == LayerMask.NameToLayer("Green"))
            player2TargetRank = 2.0f;

        player1TargetRank = SetRank(m_player1, player1TargetRank, player1Distance);
        player2TargetRank = SetRank(m_player2, player2TargetRank, player2Distance);

        enemyClass.m_target = m_player1;
        if (player1TargetRank < player2TargetRank)
            enemyClass.m_target = m_player2;

        if (player1TargetRank < 0 && player2TargetRank < 0)
            enemyClass.m_target = null;

        if (enemyClass.m_target != null)
            return BehaviourStatus.SUCCESS;

        return BehaviourStatus.FAILURE;
    }

    private float SetRank(GameObject player, float playerRank, float playerDistance)
    {
        //Pick target it can see
        if (Physics.Raycast(transform.position + transform.up * 0.5f, (player.transform.position - transform.position).normalized, playerDistance, LayerMask.GetMask("Collisions")))
            playerRank -= 100.0f;

        //Pick target thats alive
        if (player.GetComponent<Player>().IsDead())
            playerRank -= 100.0f;

        //Pick closest target based off previous rank
        playerRank = playerRank / playerDistance;

        return playerRank;
    }
}
