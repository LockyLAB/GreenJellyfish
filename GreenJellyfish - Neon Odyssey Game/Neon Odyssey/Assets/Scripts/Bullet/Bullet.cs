using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public enum TEAM {PLAYER, ENEMY }

    public void SetTeam(TEAM team)
    {
        switch (team)
        {
            case TEAM.PLAYER:
                gameObject.tag = "Player";
                break;
            case TEAM.ENEMY:
                gameObject.tag = "Enemy";
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //destroy bullet if not visible on cameras
        if (gameObject.GetComponentInChildren<Renderer>().isVisible == false)
        {
            Destroy(gameObject);
        }
    }

    //function called when object collides with other
    void OnTriggerEnter(Collider other)
    { 
        //check if other object is ENEMY or PLAYER, ignore collision layer
        if (other.gameObject.tag != gameObject.tag && other.gameObject.layer != LayerMask.NameToLayer("Collisions"))
        {
            //if ENEMY bullet hits PLAYER, 
            if (other.gameObject.tag == "Player")
            {
                //if BULLET and PLAYER are DIFFERENT colours, 
                if (other.gameObject.layer != gameObject.layer && other.gameObject.GetComponent<Player>() == true)
                {
                    other.gameObject.GetComponent<PlayerHealth>().health -= 1;
                    Destroy(gameObject);
                }

                //if enemy BULLET hits PLAYER of SAME colour, destroy bullet
                else if (other.gameObject.layer == gameObject.layer && other.gameObject.GetComponent<Player>() == true)
                {
                    Destroy(gameObject);
                    // +power charge
                }
            }

            // if PLAYER bullet hits ENEMY
            if (other.gameObject.tag == "Enemy") 
            {
                // if BULLET and ENEMY are the same colour, deal damage (ignores enemy bullets)
                if(other.gameObject.layer == gameObject.layer && other.gameObject.GetComponent<Bullet>() == null)
                {
                    other.gameObject.GetComponent<Enemy>().m_health -= 1;
                    Destroy(gameObject);
                }
            }
        }

        if (gameObject.tag == "Player" && other.gameObject.tag == "Door")
        {
            if (other.gameObject.layer == gameObject.layer)
                other.gameObject.GetComponent<ShootableEnviromentTrigger>().OnDestruction();
            Destroy(gameObject);
        }

        //check bullet - wall collisions
        if (other.gameObject.layer == LayerMask.NameToLayer("Collisions"))
        {
            Destroy(gameObject);
        }
    }
}
