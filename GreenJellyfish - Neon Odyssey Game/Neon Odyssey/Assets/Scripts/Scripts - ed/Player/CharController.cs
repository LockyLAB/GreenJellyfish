using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharController : MonoBehaviour {

    BulletController bc;

    //COLOUR SWITCHING


    

    //PLAYER SPEED
    public float speed = 10.0f;

    //SHOOT
    //public GameObject bullet1;
    //public GameObject bullet2;
    //public GameObject bullet3;
    //public GameObject bullet4;

    

   //public Sprite redSprite;
   //Image img;

    //GameObject bullet2;
    //public Transform bulletSpawn1;
    //public int bulletSpeed = 5;


    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        //bc = GetComponentInChildren<BulletController>();
        //img = GameObject.FindGameObjectWithTag("Crosshair").GetComponent<Image>();
       
        //for private
        //bullet2 = GameObject.FindGameObjectWithTag("Blue");
	}
	
	// Update is called once per frame
	void Update () {
        float translation = Input.GetAxis("Vertical") * speed;
        float strafe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        strafe *= Time.deltaTime;

        transform.Translate(strafe, 0, translation);

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

       // if (Input.GetButtonDown("Fire1"))
       // {
       //    //shootBullet();
       //    bc.testShot(); //call func. from other 
       // }

    }

    //void shootBullet()
    //{

        /*
        if (switchColour == (int)Colours.Red)
        {
            var bulletShot = (GameObject)Instantiate(
                bullet1,
                bulletSpawn1.position,
                bulletSpawn1.rotation) as GameObject;
                bulletShot.GetComponent<BulletController>().testShot(); //call func. from other 
            bulletShot.GetComponent<Rigidbody>().velocity = bulletShot.transform.forward * bulletSpeed;
            Destroy(bulletShot, 4.0f);
        }
    
        if (switchColour == (int)Colours.Green)
        {
            var bulletShot = (GameObject)Instantiate(
                bullet2,
                bulletSpawn1.position,
                bulletSpawn1.rotation) as GameObject;
    
            bulletShot.GetComponent<Rigidbody>().velocity = bulletShot.transform.forward * bulletSpeed;
            Destroy(bulletShot, 4.0f);
        }
    
        if (switchColour == (int)Colours.Yellow)
        {
            var bulletShot = (GameObject)Instantiate(
                bullet3,
                bulletSpawn1.position,
                bulletSpawn1.rotation) as GameObject;
    
            bulletShot.GetComponent<Rigidbody>().velocity = bulletShot.transform.forward * bulletSpeed;
            Destroy(bulletShot, 4.0f);
        }
    
        if (switchColour == (int)Colours.Purple)
        {
            var bulletShot = (GameObject)Instantiate(
                bullet4,
                bulletSpawn1.position,
                bulletSpawn1.rotation) as GameObject;
    
            bulletShot.GetComponent<Rigidbody>().velocity = bulletShot.transform.forward * bulletSpeed;
            Destroy(bulletShot, 4.0f);
        }
        */
    
    //}

    //
    //public void getColour()
    //{
    //    if (switchColour == (int)Colours.Red)
    //    {
    //        return (int)Colours.Red;
    //    }
    //
    //    if (switchColour == (int)Colours.Green)
    //    {
    //        return (int)Colours.Green;
    //    }
    //
    //    if (switchColour == (int)Colours.Yellow)
    //    {
    //        return (int)Colours.Yellow;
    //    }
    //
    //    if (switchColour == (int)Colours.Purple)
    //    {
    //        return (int)Colours.Purple;
    //    }
    //}

}
