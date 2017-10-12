using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using XboxCtrlrInput;

public class GameManager : MonoBehaviour
{
    public GameObject m_pausePanel;
    public GameObject m_gameoverPanel;

    private Player1Health m_playerRef;

    public List<Image> m_player1HealthImage;
    public List<Image> m_player2HealthImage;

    private int m_player1Health = 0;
    private int m_player2Health = 0;

    private bool m_singlePlayer = false;
    // Use this for initialization
    void Awake()
    {
        GameObject[] players;
        players = GameObject.FindGameObjectsWithTag("Player");

        //Assign player 1
        if (players.Length > 1)
        {
            if (players[0].GetComponentInChildren<Player1Health>() != null)
                m_playerRef = players[0].GetComponentInChildren<Player1Health>();
            else if (players[1].GetComponentInChildren<Player1Health>() != null)
                m_playerRef = players[1].GetComponentInChildren<Player1Health>();
        }
        else
        {
            m_playerRef = players[0].GetComponentInChildren<Player1Health>();
            m_singlePlayer = true;
        }

        m_pausePanel.SetActive(false);
        m_gameoverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //User interface updates
        //Player1
        if (m_player1Health != m_playerRef.health)
        {
            m_player1Health = m_playerRef.health;

            //Set all to be blacked out
            foreach (Image healthBar in m_player1HealthImage)
            {
                healthBar.GetComponent<CanvasRenderer>().SetAlpha(0.0f);
            }


            //Set correct number to be coloured
            for (int i = 0; i < m_player1Health; i++)
            {
                m_player1HealthImage[i].GetComponent<CanvasRenderer>().SetAlpha(1.0f);
            }
        }

        if (!m_singlePlayer)
        {
            //Player2
            if (m_player2Health != m_playerRef.otherPlayerHealth.health)
            {
                m_player2Health = m_playerRef.otherPlayerHealth.health;

                //Set all to be blacked out
                foreach (Image healthBar in m_player2HealthImage)
                {
                    healthBar.GetComponent<CanvasRenderer>().SetAlpha(0.0f);
                }


                //Set correct number to be coloured
                for (int i = 0; i < m_player2Health; i++)
                {
                    m_player2HealthImage[i].GetComponent<CanvasRenderer>().SetAlpha(1.0f);
                }
            }
        }

        //Gameover State
        if(m_player1Health <=0.0f && m_player2Health <=0.0f)
        {
            m_gameoverPanel.SetActive(true);
            Time.timeScale = 0.0f;
        }

        //Pausing Screen
        if (Input.GetKeyDown(KeyCode.Escape) || XCI.GetButtonDown(XboxButton.Start))
        {
            m_pausePanel.SetActive(true);
            Time.timeScale = 0.0f;
        }

        //Reset Scene
        if (XCI.GetButtonDown(XboxButton.Back))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
