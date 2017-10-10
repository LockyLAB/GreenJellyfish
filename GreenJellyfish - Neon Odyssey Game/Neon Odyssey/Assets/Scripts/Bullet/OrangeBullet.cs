using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeBullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (gameObject.GetComponentInChildren<Renderer>().isVisible == false)
        {
            Destroy(gameObject);
        }
    }

    //function called when object collides
    void OnTriggerEnter(Collider col)
    {
        //if bullet is same colour as enemy, destroy enemy, destroy bullet
        if (col.gameObject.tag == "Enemy" && col.gameObject.layer == 11)
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }

        //if BULLET collides with other coloured ENEMY, destroy bullet
        if (col.gameObject.tag == "Enemy" && (col.gameObject.layer == 9 ||  //purple
                                              col.gameObject.layer == 10 || //pink
                                              col.gameObject.layer == 12))  //green
        {
            Destroy(gameObject);
        }

        //if bullet collides with objects under "collision" layer, destroy bullet
        if (col.gameObject.layer == 8 && col.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }

    }

}
