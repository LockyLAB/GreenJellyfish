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
        if (gameObject.GetComponentInChildren<Renderer>().isVisible == false)
        {
            Destroy(gameObject);
        }
    }

    //function called when object collides
    void OnTriggerEnter(Collider col)
    {
        //Bullet hits opposing team 
        if (col.gameObject.tag != gameObject.tag)
        {
            //Hits player check not same colour
            if(col.GetComponent<Player>() != null)//if ENEMY is not BULLET colour, destroy BULLET
            {
                if(col.gameObject.layer != gameObject.layer)
                    col.gameObject.GetComponent<PlayerHealth>().health -= 1;
                Destroy(gameObject);
            }
            if (col.GetComponent<Enemy>() != null) // different colour to enemy, rmeove health
            {
                if(col.gameObject.layer == gameObject.layer)
                    col.gameObject.GetComponent<Enemy>().m_health -= 1;
                Destroy(gameObject);
            }
        }

        if (col.gameObject.layer == LayerMask.NameToLayer("Collisions"))//if BULLET collides with WALLS, destroy BULLET
            Destroy(gameObject);
    }
}
