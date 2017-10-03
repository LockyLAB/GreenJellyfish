using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour {

    P1ColourController pcc1;
    P2ColourController pcc2;

    public GameObject[] shield = new GameObject[2];
    protected GameObject currentShield;

    public Transform shieldPos;

    private bool P1shieldOn;
    //private bool P2shieldOn;
    
    //private float shieldTimer;

    // Use this for initialization
    void Start () {
        pcc1 = GetComponent<P1ColourController>();
        pcc2 = GetComponent<P2ColourController>();

       
        toggleShield();
    }
	
	// Update is called once per frame
	void Update () {

        if (gameObject.GetComponent<P1ColourController>().isToggled == true)
        {
            toggleShield();
        }

        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    toggleShield();
        //}

        //if (pcc2.switchColour == 1)
        //{
        //    Instantiate(shield[1],
        //    shieldPos.position,
        //    shieldPos.rotation,
        //    transform);
        //}
    
        //if (pcc2.switchColour == 2)
        //{
        //    Instantiate(shield[2],
        //    shieldPos.position,
        //    shieldPos.rotation,
        //    transform);
        //}

        //toggle shield
        //if (Input.GetButtonDown("Fire2") && shieldOn == false)
        //{
        //    shieldOn = true;
        //    playerShield();
        //    shieldTimer = 5.0f;
        //}

        //while(shieldOn == true)
        //{
        //    shieldTimer -= Time.deltaTime;
        //    if (shieldTimer <= 0)
        //    {
        //        shieldOn = false;
        //        break;
        //    }
        //}

    }

    void toggleShield()
    {
        Destroy(currentShield);
        if (pcc1.switchColour == 1)
        {
            currentShield = (GameObject)Instantiate(
            shield[0],
            shieldPos.position,
            shieldPos.rotation,
            transform);
            Debug.Log("player shielded pink");
        }
    
        else if (pcc1.switchColour == 2 )
        {
            currentShield = (GameObject)Instantiate(
            shield[1],
            shieldPos.position,
            shieldPos.rotation,
            transform);
            Debug.Log("player shielded yellow");
        }


        //{
        //    var bulletShot = (GameObject)Instantiate(
        //        bullet1,
        //        bulletSpawn1.position,
        //        bulletSpawn1.rotation) as GameObject;
        //    bulletShot.GetComponent<Rigidbody>().velocity = bulletShot.transform.forward * bulletSpeed;
        //    Destroy(bulletShot, 4.0f);
        //    Debug.Log("REDSHOT");
        //}
        
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
