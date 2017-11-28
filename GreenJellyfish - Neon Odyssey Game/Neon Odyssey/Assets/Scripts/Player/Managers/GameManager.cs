using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using XboxCtrlrInput;

//---------------------------------------------------------
//-written by: Samuel
//-contributors:
//---------------------------------------------------------

public class GameManager : MonoBehaviour
{
    public GameObject m_pausePanel;
    public GameObject m_controlsPanel; 
    public GameObject m_gameoverPanel;

    public GameObject m_player1 = null;
    public GameObject m_player2 = null;

    public int m_player1Health = 0;
    public int m_player2Health = 0;

    [HideInInspector]
    public bool m_singlePlayer = false;

    [HideInInspector]
    public bool m_inputOn = false;

    float gameOverTimer = 0;

    // Use this for initialization
    void Awake()
    {
        if (m_player2==null)
            m_singlePlayer = true;

        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Single Player
        if (m_singlePlayer)
        {
            //User interface updates
            if (m_player1Health != m_player1.GetComponent<Player>().GetHealth())
            {
                m_player1Health = m_player1.GetComponent<Player>().GetHealth();
                GetComponentInChildren<UI>().UpdateHealthUI(m_player1Health, m_player2Health);
            }

            if (m_player1.GetComponent<Player>().IsDead())
            {
                //Gameover State
                gameOverTimer += Time.deltaTime;
                if (gameOverTimer >= 3)
                {
                    m_gameoverPanel.SetActive(true);
                    Time.timeScale = 0.0f;
                    gameOverTimer = 0;
                }
            }
        }
        else //Two player
        {
            //User interface updates
            if (m_player1Health != m_player1.GetComponent<Player>().GetHealth())
            {
                m_player1Health = m_player1.GetComponent<Player>().GetHealth();
                GetComponentInChildren<UI>().UpdateHealthUI(m_player1Health, m_player2Health);
            }

            if (m_player2Health != m_player2.GetComponent<Player>().GetHealth())
            {
                m_player2Health = m_player2.GetComponent<Player>().GetHealth();
                GetComponentInChildren<UI>().UpdateHealthUI(m_player1Health, m_player2Health);
            }

            //Gameover State
            if (m_player1.GetComponent<Player>().IsDead() && m_player2.GetComponent<Player>().IsDead()) //Game over two player
            {
                gameOverTimer += Time.deltaTime;
                if (gameOverTimer >= 3)
                {
                    m_gameoverPanel.SetActive(true);
                    Time.timeScale = 0.0f;
                    gameOverTimer = 0;
                }
            }
        }

        if(m_singlePlayer)
        {
            //Pausing Screen
            if (XCI.GetButtonDown(XboxButton.Start, m_player1.GetComponent<Player>().controller))
            {
                m_pausePanel.SetActive(true);
                Time.timeScale = 0.0f;
            }

            //Show controls
            if (XCI.GetButtonDown(XboxButton.Back, m_player1.GetComponent<Player>().controller))
            {
                m_controlsPanel.SetActive(true);
            }
        }
        else
        {
            //Pausing Screen
            if (XCI.GetButtonDown(XboxButton.Start, m_player1.GetComponent<Player>().controller) || XCI.GetButtonDown(XboxButton.Start, m_player2.GetComponent<Player>().controller))
            {
                m_pausePanel.SetActive(true);
                Time.timeScale = 0.0f;
            }

            //Show controls
            if (XCI.GetButtonDown(XboxButton.Back, m_player1.GetComponent<Player>().controller) || XCI.GetButtonDown(XboxButton.Back, m_player2.GetComponent<Player>().controller))
            {
                m_controlsPanel.SetActive(true);
            }
        }
    }
}
