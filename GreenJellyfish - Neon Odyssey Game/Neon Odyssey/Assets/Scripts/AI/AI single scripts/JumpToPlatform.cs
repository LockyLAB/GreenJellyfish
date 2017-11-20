using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpToPlatform : BehaviourBase
{
    GameObject m_currentPlatform = null;

    //Math class
    MathFunctions m_math;

    public float m_jumpTime = 0.0f;
    private float m_time = 0.0f;

    public float m_jumpHeight = 0.0f;

    private Vector3 m_currentPos;
    private Vector3 m_nextPos;
    private Vector3 m_middleLerpPos;

    //--------------------------------------------------------------------------------------
    // Inital setup of behaviour, e.g. setting timer to 0.0f
    //--------------------------------------------------------------------------------------
    public override void BehaviourSetup()
    {
        m_math = new MathFunctions();

        //Create new list not including current platform
        if (m_currentPlatform == null)
            m_currentPlatform = GetComponent<EnemySphinx>().m_jumpPoints[0];
        m_currentPos = m_currentPlatform.transform.position;
        List<GameObject> possibleJumpPlatforms = new List<GameObject>(GetComponent<EnemySphinx>().m_jumpPoints);

        if (possibleJumpPlatforms.Count > 2) //Jumping between 3 platforms at min
        {
            int index = possibleJumpPlatforms.IndexOf(m_currentPlatform);
            possibleJumpPlatforms.RemoveAt(index);

            m_currentPlatform = possibleJumpPlatforms[Random.Range(0, possibleJumpPlatforms.Count)];
            m_nextPos = m_currentPlatform.transform.position;

            m_middleLerpPos = m_currentPos + (m_nextPos - m_currentPos) / 2 + (Vector3.up * m_jumpHeight); // Smooth jumping
        }
        else
            m_currentPlatform = null;
        m_time = 0.0f;

        //Animation
        gameObject.GetComponent<Animator>().SetTrigger("Jumping"); // Animation
    }

    //--------------------------------------------------------------------------------------
    // Update behaviours - Move towards the next platform
    //
    // Return:
    //		Returns a enum BehaviourStatus, current status of behaviour, Success, failed, pending
    //--------------------------------------------------------------------------------------
    public override BehaviourBase.BehaviourStatus Execute()
    {
        m_time += Time.deltaTime;
        if (m_time<=m_jumpTime)
        {
            gameObject.transform.position = m_math.QuadraticBezier(m_currentPos, m_middleLerpPos, m_nextPos, m_time / m_jumpTime);
            return BehaviourStatus.PENDING;
        }
        gameObject.transform.position = m_currentPlatform.transform.position;
        gameObject.GetComponent<Animator>().SetTrigger("Landing"); // Animation
        return BehaviourStatus.SUCCESS;
    }
}
