using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class Weapon : MonoBehaviour
{   
    //XBOX INPUT
    public XboxController controller;


    public Vector3 m_aim;
    public float m_bulletSpeed = 0;
    public float m_timeBetweenShots = 0;
    public float m_fireRate = 0;

    //BOOST/SPECIAL PROPERTIES
    public float powerCharge = 0;


    //LAUNCHER PROPERTIES (for testing)
    public float launcherSpeed = 1000.0f;
    public float launcherDrag = 0.15f;
    public float launcherReload = 0;

    public GameObject m_bullet1;
    public GameObject m_bullet2;


    //protected GameObject m_projectilePrefab;

    //implement later
    //protected float m_projectiltDamage = 0;

    public enum currentWeapon
    {
        Default = 1,
        Shotgun = 2,
        Launcher = 3,
        Laser = 4
    }

    public currentWeapon m_currentWeapon;

    // Use this for initialization
    void Start()
    {
        m_currentWeapon = currentWeapon.Default;
        toggleWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<Player>().isDead)
        {
             Vector2 rightInput = new Vector2(XCI.GetAxisRaw(XboxAxis.RightStickX, controller), XCI.GetAxisRaw(XboxAxis.RightStickY, controller));

            if (rightInput.x != 0 || rightInput.y != 0)
            {
                m_aim.x = rightInput.x;
                m_aim.y = rightInput.y;
                m_aim.z = 0;
                m_aim.Normalize();

                Vector3 up = new Vector3(0, 0.9f);

                Debug.DrawRay(this.transform.position + up, m_aim);

                m_timeBetweenShots += Time.deltaTime;
                fireWeapon(up);

            }
        }
    }

    private void toggleWeapon()
    {
        if ((int)m_currentWeapon == 1) //Default Weapon
        {
            m_timeBetweenShots = 0.2f;
            m_bulletSpeed = 1000.0f;
            m_fireRate = 0.2f;
        }

        if ((int)m_currentWeapon == 2) //Shotgun upgrade
        {
            m_timeBetweenShots = 0.2f; 
            m_bulletSpeed = 1000.0f;
            m_fireRate = 0.5f;
        }

        if ((int)m_currentWeapon == 3) //Launcher upgrade
        {
            m_timeBetweenShots = 0.75f;
            launcherSpeed = 1000.0f;
            launcherReload = 0.75f;
            launcherDrag = 0.15f;
        }

        if ((int)m_currentWeapon == 4) //Laser upgrade
        {

        }


    }

    private void fireWeapon(Vector3 up)
    {

        //DEFAULT 
        if ((int)m_currentWeapon == 1)
        {
            if (GetComponent<ColourController>().m_firstBulletSlot && m_timeBetweenShots >= m_fireRate)
            {
                GameObject newBullet = Instantiate(m_bullet1, m_aim + transform.position + up, Quaternion.Euler(m_aim)) as GameObject;

                newBullet.GetComponent<Rigidbody>().AddForce(m_aim * m_bulletSpeed);
                newBullet.GetComponent<Bullet>().SetTeam(Bullet.TEAM.PLAYER);
                m_timeBetweenShots = 0;
            }

            if (!GetComponent<ColourController>().m_firstBulletSlot && m_timeBetweenShots >= m_fireRate)
            {
                GameObject newBullet = Instantiate(m_bullet2, m_aim + transform.position + up, Quaternion.Euler(m_aim)) as GameObject;

                newBullet.GetComponent<Rigidbody>().AddForce(m_aim * m_bulletSpeed);
                newBullet.GetComponent<Bullet>().SetTeam(Bullet.TEAM.PLAYER);
                m_timeBetweenShots = 0;
            }       
        }

        //SHOTGUN
        if ((int)m_currentWeapon == 2)
        {
            if (GetComponent<ColourController>().m_firstBulletSlot && m_timeBetweenShots >= m_fireRate)
            {
                //
            }

        }

        //LAUNCHER
        if ((int)m_currentWeapon == 3)
        {
            if (GetComponent<ColourController>().m_firstBulletSlot && m_timeBetweenShots >= launcherReload)
            {
                GameObject grenadeShot = Instantiate(m_bullet1, m_aim + transform.position + up, Quaternion.Euler(m_aim)) as GameObject;

                grenadeShot.GetComponent<Rigidbody>().AddForce(m_aim * launcherSpeed);
                grenadeShot.GetComponent<Rigidbody>().useGravity = true;
                grenadeShot.GetComponent<Rigidbody>().drag = launcherDrag;
                grenadeShot.GetComponent<Bullet>().SetTeam(Bullet.TEAM.PLAYER);
                m_timeBetweenShots = 0;
            }

            if (!GetComponent<ColourController>().m_firstBulletSlot && m_timeBetweenShots >= launcherReload)
            {
                GameObject grenadeShot = Instantiate(m_bullet2, m_aim + transform.position + up, Quaternion.Euler(m_aim)) as GameObject;

                grenadeShot.GetComponent<Rigidbody>().AddForce(m_aim * launcherSpeed);
                grenadeShot.GetComponent<Rigidbody>().useGravity = true;
                grenadeShot.GetComponent<Rigidbody>().drag = launcherDrag;
                grenadeShot.GetComponent<Bullet>().SetTeam(Bullet.TEAM.PLAYER);
                m_timeBetweenShots = 0;
            }       
        }

        //LASER
        if ((int)m_currentWeapon == 4)  
        {

        }
    }



}
