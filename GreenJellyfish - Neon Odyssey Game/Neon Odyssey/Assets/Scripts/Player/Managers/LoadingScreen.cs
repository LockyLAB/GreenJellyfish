using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen : MonoBehaviour {
    public float m_splashScreenTimer = 2.0f;

	// Use this for initialization
	void Start ()
    {
        Invoke("EndLoadScreen", m_splashScreenTimer);
    }
	
    void EndLoadScreen()
    {
        gameObject.SetActive(false);
    }
}
