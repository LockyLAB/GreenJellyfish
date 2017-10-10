using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharController : MonoBehaviour {

    //BulletController bc;
   
    //PLAYER SPEED
    public float speed = 10.0f;
    

   //public Sprite redSprite;
   //Image img;

    //GameObject bullet2;
    //public Transform bulletSpawn1;
    //public int bulletSpeed = 5;


    // Use this for initialization
    void Start ()
    {
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

    }


}
