using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//---------------------------------------------------------
//-written by: Samuel
//-contributors:
//---------------------------------------------------------

public class UI : MonoBehaviour
{
    //health bar
    public GameObject m_playerPurpleBar;
    public GameObject m_playerOrangeBar;

    public GameObject m_playerGreenBar;
    public GameObject m_playerPinkBar;

    public GameObject[] m_player1HealthHolder = new GameObject[4];
    public GameObject[] m_player2HealthHolder = new GameObject[4];

    public GameObject[] m_player1HealthBarHolder = new GameObject[1];
    public GameObject[] m_player2HealthBarHolder = new GameObject[1];

    private GameManager m_gameManagerRef;

    // Use this for initialization
    void Start()
    {
        m_gameManagerRef = GameObject.FindWithTag("GameController").GetComponent<GameManager>();

        //Run first time
        ChangeUIColour(true, false);
        ChangeUIColour(false, false);
    }

    //--------------------------------------------------------------------------------------
    //Update UI to show the right number of health bars
    //
    // Param:
    //		player1Health: current player1 health
    //		player2Health: current player2 health
    //--------------------------------------------------------------------------------------
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

    //--------------------------------------------------------------------------------------
    //Update UI to show the right number of health bars
    //
    // Param:
    //		firstPlayer: which player helaht to update
    //		firstColour: what colour is player for update
    //--------------------------------------------------------------------------------------
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

    //--------------------------------------------------------------------------------------
    //change health bar colour
    //
    // Param:
    //		healthBarImageHolder: Current holder of health bar
    //		healthBarImage: the new health bar image
    //--------------------------------------------------------------------------------------
    private void ColourFlip(GameObject[] healthBarImageHolder, GameObject healthBarImage)
    {
        //Create new bar in flipped colour in location of old bar
        GameObject newBar = Instantiate(healthBarImage, healthBarImageHolder[0].transform.position, Quaternion.identity, gameObject.transform);

        Destroy(healthBarImageHolder[0]);
        healthBarImageHolder[0] = newBar;
    }
}
