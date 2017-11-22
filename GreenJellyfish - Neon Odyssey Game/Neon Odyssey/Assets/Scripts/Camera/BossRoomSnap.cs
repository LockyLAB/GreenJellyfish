using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class BossRoomSnap : MonoBehaviour
{
    private CameraMove m_MainCameraScript = null;
    private PostProcessingProfile m_postProcess;

    // Use this for initialization
    void Start ()
    {
        m_MainCameraScript = GameObject.FindWithTag("MainCamera").GetComponent<CameraMove>();
        m_postProcess = m_MainCameraScript.GetComponent<PostProcessingBehaviour>().profile;
    }

    //-----------------------------------------------------
    // Tell main camera to lock to boss room
    //-----------------------------------------------------
    public void Activate()
    {
        m_MainCameraScript.m_cameraLocked = true;
        m_MainCameraScript.m_cameraLockPos = transform.position;

        //Set apature to be 13 for boss battle
        var postSetting = m_postProcess.depthOfField.settings;
        postSetting.aperture = 13.0f;
        m_postProcess.depthOfField.settings = postSetting;
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
    }
}
