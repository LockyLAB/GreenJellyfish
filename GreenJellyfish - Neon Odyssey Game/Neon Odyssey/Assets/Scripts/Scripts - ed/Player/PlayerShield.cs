using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour {

    P1ColourController pcc1;
    P2ColourController pcc2;

    public GameObject[] shield = new GameObject[2];

    public Transform shieldPos;
    private bool redShieldOn;
    private bool greenShieldOn;

    // Use this for initialization
    void Start () {
        pcc1 = GetComponent<P1ColourController>();
        pcc2 = GetComponent<P2ColourController>();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire2"))
        {
            playerShield();
        }
	}

    void playerShield()
    {
        //if (pcc1.switchColour == 1)
        //{
        //    var bulletShot = (GameObject)Instantiate(
        //        bullet1,
        //        bulletSpawn1.position,
        //        bulletSpawn1.rotation) as GameObject;
        //    bulletShot.GetComponent<Rigidbody>().velocity = bulletShot.transform.forward * bulletSpeed;
        //    Destroy(bulletShot, 4.0f);
        //    Debug.Log("REDSHOT");
        //}
        //
        //if (pcc1.switchColour == 2)
        //{
        //    var bulletShot = (GameObject)Instantiate(
        //        bullet1,
        //        bulletSpawn1.position,
        //        bulletSpawn1.rotation) as GameObject;
        //    bulletShot.GetComponent<Rigidbody>().velocity = bulletShot.transform.forward * bulletSpeed;
        //    Destroy(bulletShot, 4.0f);
        //    Debug.Log("REDSHOT");
        //}

        Debug.Log("SHIELD UP");
    }
}
