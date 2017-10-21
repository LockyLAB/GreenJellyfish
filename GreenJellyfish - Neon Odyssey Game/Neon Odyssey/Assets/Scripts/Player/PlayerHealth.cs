using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class PlayerHealth : MonoBehaviour
{
    public int health = 4;
    int tempHealth = 0;

    private GameObject m_otherPlayer = null;

    public XboxController controller;

    public bool isReviving = false;

    public float reviveTime = 2;
    public float timer = 0;

    public int healthGivenByPickup = 3;

    public float deathTimer = 0;
    public float deathTime = 2;

    public bool isInvulnerable;

    // Use this for initialization
    void Awake()
    {
        isReviving = false;
        tempHealth = health;

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
        //Keep health in bounds
        if (health > 4)
            health = 4;

        if (health <= 0)
        {
            health = 0;
            GetComponent<Player>().isDead = true;
        }
        else
            GetComponent<Player>().isDead = false;


        if (isReviving && XCI.GetButton((XboxButton.B), controller) && !GetComponent<Player>().isDead)
        {
            timer += Time.deltaTime;

            if (timer >= reviveTime)
            {
                timer = 0;
                m_otherPlayer.GetComponent<PlayerHealth>().health = 2;
            }
        }

        if (XCI.GetButtonUp((XboxButton.B), controller))
        {
            timer = 0;
        }

        deathTimer += Time.deltaTime;
        if (tempHealth != health)
        {
            deathTimer = 0.0f;
            if (deathTimer <= deathTime)
            {
                isInvulnerable = true;
            }
            else
            {
                isInvulnerable = false;
            }
        }
        tempHealth = health;
    }

    void OnTriggerEnter(Collider other)
    {
        if (m_otherPlayer != null)
        {
           
            if (other.gameObject.tag == "Player" && m_otherPlayer.GetComponent<PlayerHealth>().health <= 0)
            {
                Debug.Log("hitplayer");
                isReviving = true;
            }

            if (other.gameObject.tag == "HealthPickup")
            {
                Destroy(other.gameObject);
                health += healthGivenByPickup;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (m_otherPlayer != null)
        {
            if (other.gameObject.tag == "Player" && m_otherPlayer.GetComponent<PlayerHealth>().health <= 0)
            {
                isReviving = false;
                timer = 0;
            }
        }
    }

    //USE THIS FUNCTION TO DEAL DAMAGE TO PLAYER FROM OTHER SCRIPTS
    public void takeDamage(int dmg)
    {
        //take damage from other sources
        health -= dmg;

        //turn temporarily invulnerable here
    }

}
