using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSequence : MonoBehaviour
{
    //Players
    private GameObject m_player1 = null;
    private GameObject m_player2 = null;

    public float m_portalPlayer2ActivateTime = 1.0f;
    private bool m_portalPlayer2Activated = false;

    public float m_animationTime = 2.0f;
    public float m_sequenceTime = 3.0f;
    private float m_sequenceTimer = 0.0f;

    private void Start()
    {
        //Assign players
        if (GameObject.FindWithTag("GameController").GetComponent<GameManager>().m_singlePlayer)
        {
            m_player1 = GameObject.FindWithTag("GameController").GetComponent<GameManager>().m_player1;
        }
        else
        {
            m_player1 = GameObject.FindWithTag("GameController").GetComponent<GameManager>().m_player1;
            m_player2 = GameObject.FindWithTag("GameController").GetComponent<GameManager>().m_player2;
        }
    }

    private void OnEnable()
    {
        m_player1.gameObject.GetComponentInChildren<Animator>().SetTrigger("PortalJump");
    }

    private void Update()
    {
        m_sequenceTimer += Time.deltaTime;

        if (m_sequenceTimer > m_portalPlayer2ActivateTime && !m_portalPlayer2Activated)
        {
            m_portalPlayer2Activated = true;
            m_player2.gameObject.GetComponentInChildren<Animator>().SetTrigger("PortalJump");
        }else if (m_sequenceTimer > m_animationTime)//Enable camera and player input at end of timer
            GameObject.FindWithTag("MainCamera").GetComponent<CameraMove>().m_dynamicCamera = true;
        else if(m_sequenceTimer > m_sequenceTime)
        {
            GameObject.FindWithTag("GameController").GetComponent<GameManager>().m_inputOn = true;
            this.enabled = false;
        }
    }
}
