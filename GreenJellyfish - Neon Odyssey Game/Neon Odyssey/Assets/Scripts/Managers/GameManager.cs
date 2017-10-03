using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using XboxCtrlrInput;
public class GameManager : MonoBehaviour {

    public Canvas m_pauseCanvas;

    private bool m_menuVis = false;
	// Use this for initialization
	void Start ()
    {
        m_pauseCanvas.gameObject.SetActive(m_menuVis);
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Escape) || XCI.GetButtonDown(XboxButton.Start))
        {
            m_menuVis = !m_menuVis;
            m_pauseCanvas.gameObject.SetActive(m_menuVis);

            if (m_menuVis)
                Time.timeScale = 0.0f;
            else
                Time.timeScale = 1.0f;
        }
    }
}
