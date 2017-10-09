using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBullet : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void OnTriggerEnter(Collider col)
    {
        //if BULLET is same colour as ENEMY, destroy ENEMY and BULLET
        if (col.gameObject.tag == "Enemy" && col.gameObject.layer == 12)
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }

        //if BULLET collides with other coloured ENEMY, destroy bullet
        if (col.gameObject.tag == "Enemy" && (col.gameObject.layer == 9 ||  //purple )
                                              col.gameObject.layer == 10 || //pink
                                              col.gameObject.layer == 11))  //orange
        {
             Destroy(gameObject);
        }

        //if BULLET collides with WALLS, destroy bullet
        else if (col.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }


    }         
              
}      
