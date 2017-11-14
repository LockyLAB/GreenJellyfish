using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    public Vector3 m_player1HealthPos = Vector3.zero;
    public Vector3 m_player2HealthPos = Vector3.zero;
    public Vector3 m_player1HealthGap = Vector3.zero;
    public Vector3 m_player2HealthGap = Vector3.zero;

    public GameObject m_playerPurple;
    public GameObject m_playerOrange;

    public GameObject m_playerGreen;
    public GameObject m_playerPink;

    private GameObject[] m_player1HealthHolder = new GameObject[4];
    private GameObject[] m_player2HealthHolder = new GameObject[4];

    private GameManager m_gameManagerRef;

    // Use this for initialization
    void Start()
    {
        m_gameManagerRef = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        //Set up Health UI
        for (int i = 0; i < 4; i++)
        {
            m_player1HealthHolder[i] = Instantiate(m_playerPurple, m_player1HealthPos + m_player1HealthGap * i, Quaternion.identity, m_gameManagerRef.GetComponent<Canvas>().transform);
        }
        for (int i = 0; i < 4; i++)
        {
            m_player2HealthHolder[i] = Instantiate(m_playerGreen, m_player2HealthPos + m_player2HealthGap * i, Quaternion.identity, m_gameManagerRef.GetComponent<Canvas>().transform);
        }
    }

    //Update UI to show the right number of health bars
    public void UpdateHealthUI(int player1Health, int player2Health)
    {
        //Single player
        //Set correct number to be coloured
        Debug.Log(player1Health);
        for (int i = 0; i < player1Health; i++)
        {
            m_player1HealthHolder[i].GetComponent<CanvasRenderer>().SetAlpha(1.0f);
        }
        for (int i = player1Health; i < 4; i++)
        {
            m_player1HealthHolder[i].GetComponent<CanvasRenderer>().SetAlpha(0.0f);
        }

        if (!m_gameManagerRef.m_singlePlayer) // Only update 2nd player if its not single player
        {
            for (int i = 0; i < player2Health; i++)
            {
                m_player2HealthHolder[i].GetComponent<CanvasRenderer>().SetAlpha(1.0f);
            }
            for (int i = player2Health; i < 4; i++)
            {
                m_player2HealthHolder[i].GetComponent<CanvasRenderer>().SetAlpha(0.0f);
            }
        }
    }

    public void ChangeUIColour(bool firstPlayer, bool firstColour)
    {
        if(firstPlayer)
        {
            if (firstColour)
            {
                ColourFlip(m_player1HealthHolder, m_playerPurple);
            }
            else
            {
                ColourFlip(m_player1HealthHolder, m_playerOrange);
            }
        }
        else
        {
            if(firstColour)
            {
                ColourFlip(m_player2HealthHolder, m_playerGreen);
            }
            else
            {
                ColourFlip(m_player2HealthHolder, m_playerPink);
            }
        }
    }

    private void ColourFlip(GameObject[] ImageArray,GameObject UIImage)
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject newImg = Instantiate(UIImage, ImageArray[i].transform.position, Quaternion.identity, m_gameManagerRef.GetComponent<Canvas>().transform);
            Destroy(ImageArray[i]);
            ImageArray[i] = newImg;
        }
    }
}
