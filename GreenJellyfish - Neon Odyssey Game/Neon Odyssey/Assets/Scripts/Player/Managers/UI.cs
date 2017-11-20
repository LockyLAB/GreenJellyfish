using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    public Vector3 m_player1HealthPos = Vector3.zero;
    public Vector3 m_player2HealthPos = Vector3.zero;
    public Vector3 m_player1HealthGap = Vector3.zero;
    public Vector3 m_player2HealthGap = Vector3.zero;

    public Vector3 m_player1HealthBarPos = Vector3.zero;
    public Vector3 m_player2HealthBarPos = Vector3.zero;

    //Individual icons
    public GameObject m_playerHealthIcon;

    //health bar
    public GameObject m_playerPurpleBar;
    public GameObject m_playerOrangeBar;

    public GameObject m_playerGreenBar;
    public GameObject m_playerPinkBar;

    private GameObject[] m_player1HealthHolder = new GameObject[4];
    private GameObject[] m_player2HealthHolder = new GameObject[4];

    private GameObject[] m_player1HealthBarHolder = new GameObject[1];
    private GameObject[] m_player2HealthBarHolder = new GameObject[1];

    private GameManager m_gameManagerRef;

    // Use this for initialization
    void Start()
    {
        m_gameManagerRef = GameObject.FindWithTag("GameController").GetComponent<GameManager>();

        //Set up Health UI Bars
        m_player1HealthBarHolder[0] = Instantiate(m_playerPurpleBar, m_player1HealthBarPos, Quaternion.identity, m_gameManagerRef.GetComponent<Canvas>().transform);
        m_player2HealthBarHolder[0] = Instantiate(m_playerGreenBar, m_player2HealthBarPos, Quaternion.identity, m_gameManagerRef.GetComponent<Canvas>().transform);

        //Set up Health UI icons
        for (int i = 0; i < 4; i++)
        {
            m_player1HealthHolder[i] = Instantiate(m_playerHealthIcon, m_player1HealthPos + m_player1HealthGap * i, Quaternion.identity, m_gameManagerRef.GetComponent<Canvas>().transform);
        }
        for (int i = 0; i < 4; i++)
        {
            m_player2HealthHolder[i] = Instantiate(m_playerHealthIcon, m_player2HealthPos + m_player2HealthGap * i, Quaternion.identity, m_gameManagerRef.GetComponent<Canvas>().transform);
        }

        //Run first time
        ChangeUIColour(true, false);
        ChangeUIColour(false, false);
    }

    //Update UI to show the right number of health bars
    public void UpdateHealthUI(int player1Health, int player2Health)
    {
        //Set correct number to be coloured
        for (int i = 0; i < player1Health; i++)
            m_player1HealthHolder[i].GetComponent<CanvasRenderer>().SetAlpha(1.0f);

        for (int i = player1Health; i < 4; i++)
            m_player1HealthHolder[i].GetComponent<CanvasRenderer>().SetAlpha(0.0f);

        if (!m_gameManagerRef.m_singlePlayer) // Only update 2nd player if its not single player
        {
            for (int i = 0; i < player2Health; i++)
                m_player2HealthHolder[i].GetComponent<CanvasRenderer>().SetAlpha(1.0f);

            for (int i = player2Health; i < 4; i++)
                m_player2HealthHolder[i].GetComponent<CanvasRenderer>().SetAlpha(0.0f);
        }
    }

    public void ChangeUIColour(bool firstPlayer, bool firstColour)
    {
        //Decide what colours to change to/which bar
        if (firstPlayer)
        {
            if (firstColour)
                ColourFlip(m_player1HealthBarHolder, m_playerPurpleBar);
            else
                ColourFlip(m_player1HealthBarHolder, m_playerOrangeBar);
        }
        else
        {
            if (firstColour)
                ColourFlip(m_player2HealthBarHolder, m_playerGreenBar);
            else
                ColourFlip(m_player2HealthBarHolder, m_playerPinkBar);
        }
    }

    private void ColourFlip(GameObject[] healthBarImageHolder, GameObject healthBarImage)
    {
        //Create new bar in flipped colour in location of old bar
        GameObject newBar = Instantiate(healthBarImage, healthBarImageHolder[0].transform.position, Quaternion.identity, m_gameManagerRef.GetComponent<Canvas>().transform);

        Destroy(healthBarImageHolder[0]);
        healthBarImageHolder[0] = newBar;
    }
}
