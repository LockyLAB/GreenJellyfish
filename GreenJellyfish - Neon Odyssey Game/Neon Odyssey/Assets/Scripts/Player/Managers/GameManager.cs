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

    [HideInInspector]
    public GameObject m_player1;
    [HideInInspector]
    public GameObject m_player2;

    public List<Image> m_player1HealthImage;
    public List<Image> m_player2HealthImage;

    public int m_player1Health = 0;
    public int m_player2Health = 0;

    [HideInInspector]
    public bool m_singlePlayer = false;

    // Use this for initialization
    void Awake()
    {
        GameObject[] players;
        players = GameObject.FindGameObjectsWithTag("Player");

        //Assign player 1
        if (players.Length > 1)
        {
            //Assign player 1
            if (players[0].GetComponent<Player>().isFirstPlayer)
                m_player1 = players[0];
            else if (players[1].GetComponent<Player>().isFirstPlayer)
                m_player1 = players[1];

            //Assign player 2
            if (!players[0].GetComponent<Player>().isFirstPlayer)
                m_player2 = players[0];
            else if (!players[1].GetComponent<Player>().isFirstPlayer)
                m_player2 = players[1];
        }
        else
        {
            m_player1 = players[0];
            m_singlePlayer = true;
        }

        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //User interface updates
        //Player1

        //Single player
        if (m_player1Health != m_player1.GetComponent<Player>().GetHealth())
        {
            m_player1Health = m_player1.GetComponent<Player>().GetHealth();

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

        // 2 Player game
        if (!m_singlePlayer)
        {
            //Player2
            if (m_player2Health != m_player2.GetComponent<Player>().GetHealth())
            {
                m_player2Health = m_player2.GetComponent<Player>().GetHealth();

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

            //Gameover State
            if (m_player1.GetComponent<Player>().IsDead() && m_player2.GetComponent<Player>().IsDead())
            {
                m_gameoverPanel.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }
        else
        {
            //Gameover State
            if (m_player1.GetComponent<Player>().IsDead())
            {
                m_gameoverPanel.SetActive(true);
                Time.timeScale = 0.0f;
            }
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
