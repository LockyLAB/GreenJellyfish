using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    public float m_splashScreenTimer = 2.0f;
    public Animation m_portalAnimation;

    //--------------------------------------------------------------------------------------
    // False loading screen runiing for predetermined time
    //--------------------------------------------------------------------------------------
    void Start ()
    {
        Invoke("EndLoadScreen", m_splashScreenTimer);
        m_portalAnimation = GetComponent<Animation>();
    }

    private void Update()
    {
        //if(!m_portalAnimation.isPlaying)

            //GameObject.FindWithTag("MainCamera").GetComponent<CameraMove>().m_dynamicCamera = true;
    }

    //--------------------------------------------------------------------------------------
    // after timer disable loading screen
    //--------------------------------------------------------------------------------------
    void EndLoadScreen()
    {
        gameObject.SetActive(false);
        //m_portalAnimation = true;
        //GameObject.FindWithTag("MainCamera").GetComponent<CameraMove>().m_dynamicCamera = true;
    }
}
