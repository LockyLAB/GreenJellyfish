using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class Player1Shoot : MonoBehaviour {

    public bool isFiring;

    public float bulletSpeed = 1000;
    private float timeBetweenShots = 0;
    public float fireRate = 0.2f;

    private float shotCounter;


    public Player player;

    public Vector3 Aim;

    P1ColourController pcc1;

    public GameObject bullet1;
    public GameObject bullet2;
 
    public XboxController controller;


    // Use this for initialization
    void Start ()
    {
        pcc1 = GetComponent<P1ColourController>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!player.isDead)
        {
            Vector2 rightInput = new Vector2(XCI.GetAxisRaw(XboxAxis.RightStickX, controller), XCI.GetAxisRaw(XboxAxis.RightStickY, controller));


            if (rightInput.x != 0 || rightInput.y != 0)
            {
                isFiring = true;
                Aim.x = rightInput.x;
                Aim.y = rightInput.y;
                Aim.z = 0;
                Aim.Normalize();


                Vector3 up = new Vector3(0, 0.9f);

                Debug.DrawRay(this.transform.position + up, Aim);

                timeBetweenShots += Time.deltaTime;

                if (isFiring)
                {
                    if (pcc1.switchColour == 1)
                    {
                        if (timeBetweenShots >= fireRate)
                        {
                            GameObject newBullet = Instantiate(bullet1, Aim + player.transform.position + up, Quaternion.Euler(Aim)) as GameObject;
                            newBullet.GetComponent<Rigidbody>().AddForce(Aim * bulletSpeed);

                            timeBetweenShots = 0;

                        }

                    }
                    if (pcc1.switchColour == 2)
                    {
                        if (timeBetweenShots >= fireRate)
                        {

                            GameObject newBullet = Instantiate(bullet2, Aim + player.transform.position + up, Quaternion.Euler(Aim)) as GameObject;

                            newBullet.GetComponent<Rigidbody>().AddForce(Aim * bulletSpeed);
                            timeBetweenShots = 0;
                        }

                    }
                }


            }
            if (rightInput.x == 0 || rightInput.y == 0)
            {
                isFiring = false;
            }








        }
    }
}
