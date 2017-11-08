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
    public float bulletSpeed = 15.0f;
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
        }

        //destroy bullet if not visible on cameras
        //if (gameObject.GetComponentInChildren<Renderer>().isVisible == false)
        //{
        //    Detonate(objectPos, homingRadius);
        //}

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Collisions"))
        {
            Detonate(objectPos, homingRadius);
        }
   
        if (other.gameObject.tag == "Enemy" && other.gameObject.GetComponent<Bullet>() != null)
        {
            Detonate(objectPos, homingRadius);
        }
    }

    //public void TimedDetonation(float detonateTimer)
    //{
    //    Detonate(objectPos, homingRadius);
    //    Destroy(gameObject, detonateTimer);
    //}

    private void Detonate(Vector3 pos, float homingRadius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(pos, homingRadius);
        foreach (Collider other in hitColliders)
        {
            if (other.gameObject.tag == "Enemy" && other.gameObject.GetComponent<Bullet>() != null)
            {
                Vector3 targetDir = other.gameObject.transform.position - transform.position;
                targetDir.Normalize();
                //GameObject homers = Instantiate(m_bullet1, transform.position, Quaternion.Euler(targetDir));
                GameObject newHomer = Instantiate(m_bullet1, transform.position, Quaternion.identity);
                newHomer.GetComponent<Rigidbody>().velocity = targetDir * bulletSpeed;
            }
        }

        //foreach (GameObject enemy in enemies)
        //{
        //    float dist = Vector3.Distance(enemy.transform.position, gameObject.transform.position);
            
        //    if (dist <= homingRadius)
        //    {
        //        Vector3 targetDir = enemy.transform.position - transform.position;
        //        targetDir.Normalize();
        //        GameObject newBullet = Instantiate(m_bullet1, transform.position, Quaternion.Euler(targetDir));
        //        newBullet.GetComponent<Rigidbody>().velocity = targetDir * bulletSpeed;
        //    }
        //}

        Destroy(this.gameObject);

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
