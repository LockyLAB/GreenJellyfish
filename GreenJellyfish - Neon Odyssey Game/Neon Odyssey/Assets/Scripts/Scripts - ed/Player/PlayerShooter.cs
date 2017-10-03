using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour {

    P1ColourController pcc1;
    P2ColourController pcc2;

    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject bullet3;
    public GameObject bullet4;

    public int bulletSpeed = 10;
    public Transform bulletSpawn1;



    // Use this for initialization
    void Start () {
        pcc1 = GetComponent<P1ColourController>();
        pcc2 = GetComponent<P2ColourController>();

        //pcc1.switchColour = 1;
        //pcc1.switchColour = 2;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
           //shootBullet();
            testShot(); 
        }
    }

    public void testShot()
    {
       //CHECK P1 COLOUR
        if (pcc1.switchColour == 1)
        {
            var bulletShot = (GameObject)Instantiate(
                bullet1,
                bulletSpawn1.position,
                bulletSpawn1.rotation) as GameObject;
            bulletShot.GetComponent<Rigidbody>().velocity = bulletShot.transform.forward * bulletSpeed;
            Destroy(bulletShot, 4.0f);
            Debug.Log("pink shot");
        }
        
        if (pcc1.switchColour == 2)
        {
            var bulletShot = (GameObject)Instantiate(
                bullet2,
                bulletSpawn1.position,
                bulletSpawn1.rotation) as GameObject;

            //bulletShot.GetComponent<Material>().mainTexture
        
            bulletShot.GetComponent<Rigidbody>().velocity = bulletShot.transform.forward * bulletSpeed;
            Destroy(bulletShot, 4.0f);
            Debug.Log("yellow shot");
        }

        //CHECK P2 COLOUR
      //if (pcc2.switchColour == 1)
      //{
      //    var bulletShot = (GameObject)Instantiate(
      //        bullet3,
      //        bulletSpawn1.position,
      //        bulletSpawn1.rotation) as GameObject;
      //    bulletShot.GetComponent<Rigidbody>().velocity = bulletShot.transform.forward * bulletSpeed;
      //    Destroy(bulletShot, 4.0f);
      //    Debug.Log("YELLOWSHOT");
      //}
      //
      //if (pcc2.switchColour == 2)
      //{
      //    var bulletShot = (GameObject)Instantiate(
      //        bullet4,
      //        bulletSpawn1.position,
      //        bulletSpawn1.rotation) as GameObject;
      //
      //    bulletShot.GetComponent<Rigidbody>().velocity = bulletShot.transform.forward * bulletSpeed;
      //    Destroy(bulletShot, 4.0f);
      //    Debug.Log("PURPLESHOT");
      //}

    }
}
