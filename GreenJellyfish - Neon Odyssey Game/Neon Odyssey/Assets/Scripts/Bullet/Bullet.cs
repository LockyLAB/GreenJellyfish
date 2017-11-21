using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //-----------------------------------------------------------------------------
    // Attach this script to bullet prefabs
    //-----------------------------------------------------------------------------

    public enum TEAM {PLAYER, ENEMY }

    public Vector3 m_hitMarkerSpawnPos = Vector3.up * 0.5f;
    public GameObject m_hitMarker = null;
    public GameObject explosionParticle;

    public bool isExplosive = false;
    private bool triggered = false;

    private float explosionRadius = 10.0f;
    private Weapon wep;

    private void Awake()
    {
       wep = GetComponent<Weapon>();
    }

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
                if (other.gameObject.GetComponent<Player>().IsDead()) //Dont allow bullets to hit dead players
                    return;

                //if BULLET and PLAYER are DIFFERENT colours, 
                if (other.gameObject.layer != gameObject.layer && other.gameObject.GetComponent<Player>() != null)
                {
                    if(m_hitMarker!= null)
                        Destroy(Instantiate(m_hitMarker, other.gameObject.transform.TransformPoint(m_hitMarkerSpawnPos), Quaternion.identity, other.gameObject.transform), 5.0f);

                    GameObject.FindGameObjectsWithTag("MainCamera")[0].GetComponent<CameraMove>().EnableCameraShake();
                    other.gameObject.GetComponent<Player>().ChangeHealth(-1);
                    Destroy(gameObject);
                }

                //if enemy BULLET hits PLAYER of SAME colour, destroy bullet
                else if (other.gameObject.layer == gameObject.layer && other.gameObject.GetComponent<Player>() != null)
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
                    other.gameObject.GetComponent<Enemy>().ChangeHealth(-1);

                    while (isExplosive && !triggered)
                    {
                        Destroy(Instantiate(explosionParticle.gameObject, gameObject.transform.position, Quaternion.identity), 2.5f);
                        ExplodeDamage(gameObject.transform.position, other.gameObject);
                        //isExplosive = false;
                    }

                    Destroy(gameObject);
                }

                //if BULLET and ENEMY are different colours, destroy player bullet
                if(other.gameObject.layer != gameObject.layer && other.gameObject.GetComponent<Bullet>() == null)
                {
                    while (isExplosive && !triggered)
                    {
                        Destroy(Instantiate(explosionParticle.gameObject, gameObject.transform.position, Quaternion.identity), 2.5f);
                        ExplodeDamage(gameObject.transform.position, other.gameObject);
                        //isExplosive = false;
                    }

                    Destroy(gameObject);
                }
            }
        }

        //Collision with shootable Triggers
        if (other.gameObject.GetComponent<ShootableEnviromentTrigger>() != null)
        {
            if (other.gameObject.layer == gameObject.layer)
            {
                other.gameObject.GetComponent<ShootableEnviromentTrigger>().TriggerDestroy();
            }
            Destroy(gameObject);
        }

        //check bullet - wall collisions
        if (other.gameObject.layer == LayerMask.NameToLayer("Collisions"))
        {

            while (isExplosive && !triggered)
            {
                Destroy(Instantiate(explosionParticle, gameObject.transform.position, Quaternion.identity), 2.5f);
                ExplodeDamage(gameObject.transform.position, other.gameObject);
                //isExplosive = false;
            }

            Destroy(gameObject);

        }
    }

    //void OnDestroy(GameObject other)
    //{
    //    ExplodeDamage(gameObject.transform.position, other.gameObject);
    //}
    //

    void ExplodeDamage(Vector3 center, GameObject enemyGO)
    {
        LayerMask layerMask = 1 << 8;
        LayerMask mask = ~(1 << 8);

        Collider[] hitTargets = Physics.OverlapSphere(center, explosionRadius, mask);

        for (int i = 0; i < hitTargets.Length; i++)
        {
            float dist = (gameObject.transform.position - hitTargets[i].gameObject.transform.position).sqrMagnitude;
            if (gameObject.layer == hitTargets[i].gameObject.layer && dist < explosionRadius && hitTargets[i].gameObject.activeInHierarchy)
            {
                if (i == hitTargets.Length - 1)
                {
                    triggered = true;
                    isExplosive = false;
                }

                hitTargets[i].gameObject.GetComponent<Enemy>().ChangeHealth(-1);  

            }
        }

    }

}
