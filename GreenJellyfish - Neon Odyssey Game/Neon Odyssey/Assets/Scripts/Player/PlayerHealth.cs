using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class PlayerHealth : MonoBehaviour
{
    private GameObject m_otherPlayer = null;

    public XboxController controller;

    public bool isReviving = false;

    public float reviveTime = 2;
    public float timer = 0;

    public int healthGivenByPickup = 3;

    public float deathTimer = 0;
    public float deathTime = 2;

    // Use this for initialization
    void Awake()
    {
        isReviving = false;

        if(!GameObject.FindWithTag("GameController").GetComponent<GameManager>().m_singlePlayer)
        {
            //Case first player
            if (GetComponent<Player>().isFirstPlayer)
                m_otherPlayer = GameObject.FindWithTag("GameController").GetComponent<GameManager>().m_player2;

            //Case second player
            if (!GetComponent<Player>().isFirstPlayer)
                m_otherPlayer = GameObject.FindWithTag("GameController").GetComponent<GameManager>().m_player1;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (isReviving && XCI.GetButton((XboxButton.B), controller) && !GetComponent<Player>().IsDead())
        {
            timer += Time.deltaTime;

            if (timer >= reviveTime)
            {
                timer = 0;
                m_otherPlayer.GetComponent<Player>().SetHealth(2);
            }
        }

        if (XCI.GetButtonUp((XboxButton.B), controller))
        {
            timer = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (m_otherPlayer != null)
        {
           
            if (other.gameObject.tag == "Player" && m_otherPlayer.GetComponent<Player>().IsDead())
            {
                Debug.Log("hitplayer");
                isReviving = true;
            }

            if (other.gameObject.tag == "HealthPickup")
            {
                Destroy(other.gameObject);
                this.GetComponent<Player>().ChangeHealth(healthGivenByPickup);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (m_otherPlayer != null)
        {
            if (other.gameObject.tag == "Player" && m_otherPlayer.GetComponent<Player>().IsDead())
            {
                isReviving = false;
                timer = 0;
            }
        }
    }
}
