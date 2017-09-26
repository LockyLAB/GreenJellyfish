using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBullet : MonoBehaviour {

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
        //if bullet is same colour as enemy, destroy enemy, destroy bullet
        if (col.gameObject.tag == "yellow")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }

        //if enemy is not bullet colour, destroy bullet
        else if (col.gameObject.tag == "purple")
        {
            Destroy(gameObject);
        }

        else if (col.gameObject.tag == "red")
        {
            Destroy(gameObject);
        }

        else if (col.gameObject.tag == "green")
        {
            Destroy(gameObject);
        }
    }
}