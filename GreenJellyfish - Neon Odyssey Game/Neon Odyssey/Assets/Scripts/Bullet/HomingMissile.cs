using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{

    //-----------------------------------------------------------------------------
    // Attach this script to homing missile prefabs
    //-----------------------------------------------------------------------------

    
    Vector3 objectPos;
    public float homingRadius = 7.5f;
    public float bulletSpeed = 300.0f;
    public float detonateTimer = 1.5f;
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
            Destroy(gameObject);
        }

        //destroy bullet if not visible on cameras
        //if (gameObject.GetComponentInChildren<Renderer>().isVisible == false)
        //{
        //    Detonate(objectPos, homingRadius);
        //}

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Collisions"))
        {
            Detonate(objectPos, homingRadius);
            Destroy(gameObject);
        }
   
        if (other.gameObject.tag == "Enemy" && !other.gameObject.GetComponent<Bullet>())
        {
            Detonate(objectPos, homingRadius);
            Destroy(gameObject);
        }
    }

    public void TimedDetonation(float detonateTimer)
    {
        Detonate(objectPos, homingRadius);
        Destroy(gameObject, detonateTimer);
    }

    private void Detonate(Vector3 pos, float homingRadius)
    {
        foreach (GameObject enemy in enemies)
        {
            float dist = Vector3.Distance(enemy.transform.position, gameObject.transform.position);
            
            if (dist <= homingRadius)
            {
                Vector3 targetDir = enemy.transform.position - transform.position;
                GameObject homers = Instantiate(m_bullet1, transform.position, Quaternion.Euler(targetDir));
        
                homers.GetComponent<Rigidbody>().AddForce(targetDir * bulletSpeed);
            }
        }

        //Collider[] enemiesInRange = Physics.OverlapSphere(transform.position, homingRadius);
        //
        //foreach (Collider enemy in enemiesInRange)
        //{
        //    if (enemy.tag == "Enemy" && !enemy.GetComponent<Bullet>())
        //    {
        //        Vector3 targetDir = enemy.transform.position - transform.position;
        //        GameObject homingBullet = Instantiate(m_bullet1, transform.position, Quaternion.Euler(targetDir));
        //
        //        homingBullet.GetComponent<Rigidbody>().AddForce(targetDir * bulletSpeed);
        //    }        
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
   //private void TimerCountdown()
   //{
   //    Detonate(objectPos, homingRadius);
   //}
}
