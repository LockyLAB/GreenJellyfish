using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSequence : MonoBehaviour
{
    //Players
    private GameObject m_player1 = null;
    private GameObject m_player2 = null;

    private GameObject m_mainCamera = null;

    public GameObject m_portalWaterEffect = null;

    public float m_portalPlayer2ActivateTime = 1.0f; //Time to start player 2 animation
    private bool m_portalPlayer2Activated = false;

    private bool m_cameraEnabled = false;

    public float m_portalWaterTime = 1.0f;
    private bool m_portalWaterActivated = false;

    public float m_animationTime = 2.0f;
    public float m_sequenceTime = 3.0f;
    private float m_sequenceTimer = 0.0f;

    //--------------------------------------------------------------------------------------
    // Get players and camera refs
    //--------------------------------------------------------------------------------------
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

        m_mainCamera = GameObject.FindWithTag("MainCamera");
    }

    //--------------------------------------------------------------------------------------
    // Start opening sequence
    //--------------------------------------------------------------------------------------
    private void OnEnable()
    {
        //m_player1.GetComponentInChildren<Animator>().SetTrigger("PortalJump");
        //m_mainCamera.GetComponentInChildren<Animator>().SetTrigger("IntroPortal");
    }

    //--------------------------------------------------------------------------------------
    // Play different animations at different times
    //--------------------------------------------------------------------------------------
    private void Update()
    {
        m_sequenceTimer += Time.deltaTime;
        if (m_sequenceTimer > m_portalWaterTime && !m_portalWaterActivated) // Activate portal water
        {
            m_portalWaterEffect.SetActive(true);
            m_portalWaterActivated = true;
        }

        if (m_sequenceTimer > m_portalPlayer2ActivateTime && !m_portalPlayer2Activated) // playing player 2 jumping animation
        {
            m_portalPlayer2Activated = true;
            m_player2.gameObject.GetComponentInChildren<Animator>().SetTrigger("PortalJump");
        }
        else if (m_sequenceTimer > m_animationTime && !m_cameraEnabled)//Enable camera and player input at end of timer
        {
            m_cameraEnabled = true;
            GameObject.FindWithTag("MainCamera").GetComponent<CameraMove>().m_dynamicCamera = true;
        }
        else if(m_sequenceTimer > m_sequenceTime) //Enable player montion at end of opening animation
        {
            GameObject.FindWithTag("GameController").GetComponent<GameManager>().m_inputOn = true;
            this.enabled = false;
        }
    }
}
