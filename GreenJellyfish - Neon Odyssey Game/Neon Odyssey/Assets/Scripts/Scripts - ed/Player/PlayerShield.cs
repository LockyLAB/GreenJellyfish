using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour {

    P1ColourController pcc1;
    P2ColourController pcc2;

    public GameObject[] shield = new GameObject[2];

    public Transform shieldPos;
    private bool shieldOn = false;
    //private bool greenShieldOn;

    private float shieldTimer;

    // Use this for initialization
    void Start () {
        pcc1 = GetComponent<P1ColourController>();
        pcc2 = GetComponent<P2ColourController>();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire2") && shieldOn == false)
        {
            shieldOn = true;
            playerShield();
            shieldTimer = 5.0f;
        }

        while(shieldOn == true)
        {
            shieldTimer -= Time.deltaTime;
            if (shieldTimer <= 0)
            {
                shieldOn = false;
                break;
            }
        }
        

	}

    void playerShield()
    {
        if (pcc1.switchColour == 1)
        {
            Instantiate(shield[Random.Range(0, shield.Length - 1)],
            shieldPos.position,
            shieldPos.rotation,
            transform);
        }

     //if (pcc2.switchColour == 2)
     //{
     //    Instantiate(shield[Random.Range(0, shield.Length - 1)],
     //    shieldPos.position,
     //    shieldPos.rotation);s
     //}
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
