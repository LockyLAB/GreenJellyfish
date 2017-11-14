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


    // Use this for initialization
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update ()
    {
        //detonates after time
        detonateTimer -= Time.deltaTime;
        if(detonateTimer <= 0)
        {
            Detonate(objectPos, homingRadius);
        }

        //destroy bullet if not visible on cameras
        if (gameObject.GetComponentInChildren<Renderer>().isVisible == false)
        {
            Detonate(objectPos, homingRadius);
        }

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Collisions"))
        {
            Detonate(transform.position, homingRadius);
        }
   
        if (other.gameObject.tag == "Enemy" && other.gameObject.GetComponent<Bullet>() != null)
        {
            Detonate(transform.position, homingRadius);
        }
    }

    private void Detonate(Vector3 pos, float homingRadius)
    {
        Collider[] enemiesInRange = Physics.OverlapSphere(transform.position, homingRadius);
        
        foreach (Collider enemy in enemiesInRange)
        {
            if (enemy.tag == "Enemy" && !enemy.GetComponent<Bullet>())
            {
                Vector3 targetDir = enemy.transform.position - transform.position;
                GameObject homingBullet = Instantiate(m_bullet1, transform.position, Quaternion.Euler(targetDir));
        
                homingBullet.GetComponent<Rigidbody>().AddForce(targetDir * bulletSpeed);
            }        
        }
        Destroy(gameObject);
    }
}
