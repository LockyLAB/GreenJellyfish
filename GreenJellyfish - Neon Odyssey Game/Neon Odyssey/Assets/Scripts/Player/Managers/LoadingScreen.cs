using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    public float m_splashScreenTimer = 2.0f;

    //--------------------------------------------------------------------------------------
    // False loading screen runiing for predetermined time
    //--------------------------------------------------------------------------------------
    void Start ()
    {
        Invoke("EndLoadScreen", m_splashScreenTimer);
    }

    //--------------------------------------------------------------------------------------
    // after timer disable loading screen
    //--------------------------------------------------------------------------------------
    void EndLoadScreen()
    {
        GameObject.FindWithTag("GameManager").GetComponent<IntroSequence>().enabled = true;
        gameObject.SetActive(false);
    }
}
