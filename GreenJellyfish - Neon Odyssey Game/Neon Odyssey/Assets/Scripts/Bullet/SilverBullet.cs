using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverBullet : Bullet {

	// Use this for initialization
	void Start ()
    {
        this.SetTeam(Bullet.TEAM.PLAYER);

	}
	
	// Update is called once per frame
	void Update ()
    {
        //destroy bullet if not visible on cameras
        if (gameObject.GetComponentInChildren<Renderer>().isVisible == false)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && !other.gameObject.GetComponent<Bullet>())
        {
            other.gameObject.GetComponent<Enemy>().ChangeHealth(-1);
            Destroy(gameObject);
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Collisions") || other.gameObject.tag == "Door")
        {
            Destroy(gameObject);
        }
    }
}
