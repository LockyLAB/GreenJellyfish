using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomSnap : MonoBehaviour
{
    private CameraMove m_MainCameraScript = null;
	// Use this for initialization
	void Start ()
    {
        m_MainCameraScript = GameObject.FindWithTag("MainCamera").GetComponent<CameraMove>();
    }

    public void Activate()
    {
        m_MainCameraScript.m_cameraLocked = true;
        m_MainCameraScript.m_cameraLockPos = transform.position;
    }

    public void Deactivate()
    {
        m_MainCameraScript.m_cameraLocked = false;
    }
}
