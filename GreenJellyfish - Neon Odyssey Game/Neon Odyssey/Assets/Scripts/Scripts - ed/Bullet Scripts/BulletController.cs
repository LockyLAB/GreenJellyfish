using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    //public enum Colours
    //{
    //    Red = 1,
    //    Green = 2,
    //    Yellow = 3,
    //    Purple = 4
    //}

    //BULLET COLOURS
    //public GameObject bullet1;
    //public GameObject bullet2;
    //public GameObject bullet3;
    //public GameObject bullet4;
    
    //public int bulletSpeed = 5;
    //public int switchColour;
    //public Transform bulletSpawn1;

    // Use this for initialization
    void Start () {
      
	}
	
	// Update is called once per frame
	//void Update ()
    //{
    //    if (Input.GetKeyDown(KeyCode.Alpha1))
    //    {
    //        switchColour = (int)Colours.Red;
    //    }
    //
    //    if (Input.GetKeyDown(KeyCode.Alpha2))
    //    {
    //        switchColour = (int)Colours.Green;
    //    }
    //
    //    if (Input.GetKeyDown(KeyCode.Alpha3))
    //    {
    //        switchColour = (int)Colours.Yellow;
    //    }
    //
    //    if (Input.GetKeyDown(KeyCode.Alpha4))
    //    {
    //        switchColour = (int)Colours.Purple;
    //    }
    //
    //}

    //public void testShot()
    //{
    //
    //    if (switchColour == (int)Colours.Red)
    //    {
    //        var bulletShot = (GameObject)Instantiate(
    //            bullet1,
    //            bulletSpawn1.position,
    //            bulletSpawn1.rotation) as GameObject;
    //        //bulletShot.GetComponent<BulletController>().testShot(); //call func. from other 
    //        bulletShot.GetComponent<Rigidbody>().velocity = bulletShot.transform.forward * bulletSpeed;
    //        Destroy(bulletShot, 4.0f);
    //    }
    //    Debug.Log("REDSHO");
    //
    //    if (switchColour == (int)Colours.Green)
    //    {
    //        var bulletShot = (GameObject)Instantiate(
    //            bullet2,
    //            bulletSpawn1.position,
    //            bulletSpawn1.rotation) as GameObject;
    //
    //        bulletShot.GetComponent<Rigidbody>().velocity = bulletShot.transform.forward * bulletSpeed;
    //        Destroy(bulletShot, 4.0f);
    //        Debug.Log("GREENSHOT")
    //    }
    //}
}
