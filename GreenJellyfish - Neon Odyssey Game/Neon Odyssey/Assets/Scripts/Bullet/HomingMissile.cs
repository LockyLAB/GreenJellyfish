using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{

    //-----------------------------------------------------------------------------
    // Attach this script to homing missile prefabs
    //-----------------------------------------------------------------------------

    
    Vector3 objectPos;
    public float homingRadius = 1.0f;
    public float detonateTimer = 2.0f;
    public float bulletSpeed = 200.0f;
    public int burstAmount = 3;
    public GameObject m_bullet1;
    public GameObject[] enemies;

    //float distanceToPlayer = 5;

    // Use this for initialization
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        //Destroy(gameObject, detonateTimer);
    }

    // Update is called once per frame
    void Update ()
    {
        objectPos = this.transform.position;
    
        //detonates after time
        detonateTimer -= Time.deltaTime;
        if(detonateTimer <= 0)
        {
            Detonate(objectPos, homingRadius);
        }
    
        //destroy bullet if not visible on cameras
        //if (gameObject.GetComponentInChildren<Renderer>().isVisible == false)
        //{
        //    Detonate(objectPos, homingRadius);
        //}
    
    }

    //private void OnDestroy()
    //{
    //    Detonate(objectPos, homingRadius);
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.layer == LayerMask.NameToLayer("Collisions"))
    //    {
    //        Detonate(objectPos, homingRadius);
    //    }
    //
    //    if (other.gameObject.tag == "Enemy" && !other.gameObject.GetComponent<Bullet>())
    //    {
    //        Detonate(objectPos, homingRadius);
    //    }
    //
    //}

    private void Detonate(Vector3 pos, float homingRadius)
    {     
        Collider[] enemiesInRange = Physics.OverlapSphere(transform.position, homingRadius);
        
        int i = 0;

        //for (int j = 0; j < enemies.Length; j++)
        //{
            while (i < enemiesInRange.Length)
            {
   
                Vector3 curTarget = enemiesInRange[i].transform.position;

                if ( enemiesInRange[i].tag == "Enemy" && !enemiesInRange[i].GetComponent<Bullet>())
                {
                    Vector3 targetDir = curTarget - transform.position;
                    GameObject homingBullet = Instantiate(m_bullet1, objectPos, Quaternion.Euler(targetDir));

                    homingBullet.GetComponent<Rigidbody>().AddForce(targetDir * bulletSpeed);
                }
                

                i++;
               Destroy(gameObject);
            }

        //}
    }

            //Vector3 target = enemiesInRange[i].transform.position;
            //if(enemiesInRange[i].tag == "Enemy" && !enemiesInRange[i].GetComponent<Bullet>())
            //{
            //    Vector3 targetDir = target - transform.position;
            //    GameObject homingBullet = Instantiate(m_bullet1, objectPos, Quaternion.Euler(targetDir));
            //
            //    homingBullet.GetComponent<Rigidbody>().AddForce(targetDir * bulletSpeed);
            //
            //    //homingBullet.GetComponent<Rigidbody>().velocity
            //}

    //private void Explode()
    //{
    //    foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemies"))
    //    {
    //        if (Vector3.Distance(transform.position, enemy.transform.position) < distanceToPlayer)
    //        {
    //
    //        }
    //    }
    //}

}
