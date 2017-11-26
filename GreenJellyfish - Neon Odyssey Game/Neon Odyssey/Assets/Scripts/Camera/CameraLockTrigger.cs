using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class CameraLockTrigger : MonoBehaviour
{

    public GameObject m_cameraLockPos = null;
    public float m_maxHorizontalDistanceLocked = 20.0f;
    public float m_maxVerticalDistanceLocked = 14.0f;

    private CameraMove m_MainCameraScript = null;
    private PostProcessingProfile m_postProcess;

    private bool m_Activated = false;

    private GameObject m_player1 = null;
    private GameObject m_player2 = null;

    private bool m_player1Inside = false;
    private bool m_player2Inside = false;

    // Use this for initialization
    void Start()
    {
        m_MainCameraScript = GameObject.FindWithTag("MainCamera").GetComponent<CameraMove>();
        m_postProcess = m_MainCameraScript.GetComponent<PostProcessingBehaviour>().profile;

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

    //-----------------------------------------------------
    // Activating or deactivating camera
    //-----------------------------------------------------
    private void Update()
    {
        //Activating trigger for camera lock
        if(!m_Activated)
        {
            if(m_player1Inside && m_player2Inside)
            {
                m_Activated = true;
                Activate();
            }
        }
        else//Deactivating trigger for camera lock
        { 
            if (!m_player1Inside && !m_player2Inside)
            {
                m_Activated = true;
                Activate();
            }
        }
    }

    //-----------------------------------------------------
    //Detecting players entering trigger
    //-----------------------------------------------------
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == m_player1)
            m_player1Inside = true;
        if (other.gameObject == m_player2)
            m_player2Inside = true;
    }

    //-----------------------------------------------------
    //Detecting players leaving trigger
    //-----------------------------------------------------
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == m_player1)
            m_player1Inside = false;
        if (other.gameObject == m_player2)
            m_player2Inside = false;
    }

    //-----------------------------------------------------
    // Tell main camera to lock to boss room
    //-----------------------------------------------------
    public void Activate()
    {
        //Lock camera
        m_MainCameraScript.m_cameraLocked = true;
        m_MainCameraScript.m_cameraLockPos = m_cameraLockPos.transform.position;

        //Set apature to be 13 for boss battle
        var postSetting = m_postProcess.depthOfField.settings;
        postSetting.aperture = 13.0f;
        m_postProcess.depthOfField.settings = postSetting;

        //Set player constraints
        m_MainCameraScript.m_maxHorizontalDistance = m_maxHorizontalDistanceLocked;
        m_MainCameraScript.m_maxVerticalDistance = m_maxVerticalDistanceLocked;
    }

    //-----------------------------------------------------
    // Tell main camera to follow players as normal
    //-----------------------------------------------------
    public void Deactivate()
    {
        m_MainCameraScript.m_cameraLocked = false;

        //Set apature to be default
        var postSetting = m_postProcess.depthOfField.settings;
        postSetting.aperture = 4.0f;
        m_postProcess.depthOfField.settings = postSetting;

        //Reset player constraints
        m_MainCameraScript.m_maxHorizontalDistance = m_MainCameraScript.m_maxHorizontalDistanceDefault;
        m_MainCameraScript.m_maxVerticalDistance = m_MainCameraScript.m_maxVerticalDistanceDefault;
    }
}
