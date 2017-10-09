using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class Player2Health : MonoBehaviour {

    public int health = 4;

    public Player player;

    public Player1Health otherPlayerHealth;

    public bool isReviving = false;

    public float reviveTime = 2;

    public float timer = 0;

    // Use this for initialization
    void Start()
    {

        player = player.GetComponent<Player>();
        otherPlayerHealth = otherPlayerHealth.GetComponent<Player1Health>();

    }

    // Update is called once per frame
    void Update()
    {
    

        //if (health <= 0)
        //{
        //    player.isDead = true;
        //    player.gameObject.transform.GetChild(0).transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 90.0f));

        //}
        //else
        //{
        //    player.isDead = false;
        //    player.gameObject.transform.GetChild(0).transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f));
        //}



        if(isReviving && XCI.GetButton(XboxButton.A))
        {
            timer += Time.deltaTime;

            if(timer >= reviveTime)
            {
                otherPlayerHealth.health = 2;
            }



        }

        if(XCI.GetButtonUp(XboxButton.A))
        {
            timer = 0;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player1Revive" && otherPlayerHealth.health <= 0)
        {
            isReviving = true;
        }



    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player1Revive" && otherPlayerHealth.health <= 0)
        {
            isReviving = false;
            timer = 0;
        }
    }
}
