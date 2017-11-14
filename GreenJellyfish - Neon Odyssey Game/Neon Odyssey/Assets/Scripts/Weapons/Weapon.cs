using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class Weapon : MonoBehaviour
{   
    //XBOX INPUT
    public XboxController controller;

    //SHARED PROPERTIES
    public Vector3 m_aim;

    public float shotCooldown = 0;        //resets cooldown timer

    //DEFAULT WEAPON PROPERTIES
    public float defaultFireRate = 0.2f;
    public float defaultBulletSpeed = 1000;

    //SHOTGUN PROPERTIES 
    List<Quaternion> bList;                     //create list for shotgun bullets
    public int shotgunBulletCount = 6;          //number of bullets per shot
    public float spreadAngle = 20.0f;           //shotgun bullet spread
    public float shotgunFireRate = 0.5f;
    public int shotgunBulletSpeed = 15;

    //LAUNCHER PROPERTIES (for testing)
    public float launcherDrag = 0.2f;           //launcher projectile drag/air resistance
    public float launcherFireRate = 0.75f;
    public float launcherProjectileSpeed = 1000.0f;
    public float launcherExplosionRadius = 10.0f;
    public float launcherExplosionForce = 100f;

    //SPECIAL WEAPON PROPERTIES
    public float specialFireRate = .85f;
    public float specialBulletSpeed = 15f;
    public float detonateTimer = 1.25f;


    //BULLET PREFABS
    public GameObject m_bullet1;
    public GameObject m_bullet2;
    public GameObject m_specialBullet;
    
    //WEAPON LIST
    public enum currentWeapon
    {
        Default = 1,
        Shotgun = 2,
        Launcher = 3,
        Special_1 = 4
    }

    public currentWeapon m_currentWeapon;

    private currentWeapon prevWeapon;

    //Setup Shotgun bullets
    void Awake()
    {
        bList = new List<Quaternion>(shotgunBulletCount);
        for (int i = 0; i < shotgunBulletCount; i++)
        {
            bList.Add(Quaternion.Euler(Vector3.zero));
        }
    }

    // Use this for initialization
    void Start()
    {
        //set initial weapon
        m_currentWeapon = currentWeapon.Default;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<Player>().IsDead())
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

                shotCooldown += Time.deltaTime;
                fireWeapon(up);

            }
        }
    }


    public void fireWeapon(Vector3 up)
    {
        //DEFAULT 
        if ((int)m_currentWeapon == 1)
        {
            FireDefault();   
        }

        //SHOTGUN
        if ((int)m_currentWeapon == 2)
        {
            FireShotgun(m_aim);            
        }

        //LAUNCHER
        if ((int)m_currentWeapon == 3)
        {
            FireLauncher();  
        }

        //HOMING MISSILES
        if ((int)m_currentWeapon == 4)  
        {
            FireSpecial();
        }
    }

    void FireDefault()
    {
        Vector3 up = new Vector3(0, 0.9f);

        if (GetComponent<ColourController>().m_firstBulletSlot && shotCooldown >= defaultFireRate)
        {
            GameObject newBullet = Instantiate(m_bullet1, m_aim + transform.position + up, Quaternion.Euler(m_aim)) as GameObject;
        
            newBullet.GetComponent<Rigidbody>().AddForce(m_aim * defaultBulletSpeed);
            newBullet.GetComponent<Bullet>().SetTeam(Bullet.TEAM.PLAYER);
            shotCooldown = 0;
        }
        
        if (!GetComponent<ColourController>().m_firstBulletSlot && shotCooldown >= defaultFireRate)
        {
            GameObject newBullet = Instantiate(m_bullet2, m_aim + transform.position + up, Quaternion.Euler(m_aim)) as GameObject;
        
            newBullet.GetComponent<Rigidbody>().AddForce(m_aim * defaultBulletSpeed);
            newBullet.GetComponent<Bullet>().SetTeam(Bullet.TEAM.PLAYER);
            shotCooldown = 0;
        }
    }

    void FireShotgun(Vector3 m_aim)
    {
        Vector3 up = new Vector3(0, 0.9f);

        if (GetComponent<ColourController>().m_firstBulletSlot && shotCooldown >= shotgunFireRate)
        {
            for (int i = 0; i < shotgunBulletCount; i++)
            {
                Vector3 bulletDir = Quaternion.Euler(0, 0, (float)Random.Range(-spreadAngle, spreadAngle)) * m_aim;

                GameObject newBullet = Instantiate(m_bullet1, m_aim + transform.position + up, Quaternion.identity);
                newBullet.GetComponent<Bullet>().SetTeam(Bullet.TEAM.PLAYER);
                newBullet.GetComponent<Rigidbody>().velocity = bulletDir * shotgunBulletSpeed;
            }

            shotCooldown = 0;
        }

        if (!GetComponent<ColourController>().m_firstBulletSlot && shotCooldown >= shotgunFireRate)
        {
            for (int i = 0; i < shotgunBulletCount; i++)
            {
                Vector3 bulletDir = Quaternion.Euler(0, 0, (float)Random.Range(-spreadAngle, spreadAngle)) * m_aim;

                GameObject newBullet = Instantiate(m_bullet2, m_aim + transform.position + up, Quaternion.identity);
                newBullet.GetComponent<Bullet>().SetTeam(Bullet.TEAM.PLAYER);
                newBullet.GetComponent<Rigidbody>().velocity = bulletDir * shotgunBulletSpeed;
            }

            shotCooldown = 0;
        }

    }

    void FireLauncher()
    {
        Vector3 up = new Vector3(0, 0.9f);

        if (GetComponent<ColourController>().m_firstBulletSlot && shotCooldown >= launcherFireRate)
        {
            GameObject grenadeShot = Instantiate(m_bullet1, m_aim + transform.position + up, Quaternion.Euler(m_aim)) as GameObject;

            grenadeShot.GetComponent<Rigidbody>().AddForce(m_aim * launcherProjectileSpeed);
            grenadeShot.GetComponent<Rigidbody>().useGravity = true;
            grenadeShot.GetComponent<Rigidbody>().drag = launcherDrag;
            grenadeShot.GetComponent<Bullet>().isExplosive = true;
            grenadeShot.GetComponent<Bullet>().SetTeam(Bullet.TEAM.PLAYER);
            shotCooldown = 0;
        }

        if (!GetComponent<ColourController>().m_firstBulletSlot && shotCooldown >= launcherFireRate)
        {
            GameObject grenadeShot = Instantiate(m_bullet2, m_aim + transform.position + up, Quaternion.Euler(m_aim)) as GameObject;

            grenadeShot.GetComponent<Rigidbody>().AddForce(m_aim * launcherProjectileSpeed);
            grenadeShot.GetComponent<Rigidbody>().useGravity = true;
            grenadeShot.GetComponent<Rigidbody>().drag = launcherDrag;
            grenadeShot.GetComponent<Bullet>().isExplosive = true;
            grenadeShot.GetComponent<Bullet>().SetTeam(Bullet.TEAM.PLAYER);
            shotCooldown = 0;
        }
    }

    void FireSpecial()
    {
        Vector3 up = new Vector3(0, 0.9f);

        if (shotCooldown >= specialFireRate)
        {
            //GameObject newBullet = Instantiate(m_specialBullet, m_aim + transform.position + up, Quaternion.Euler(m_aim)) as GameObject;
            GameObject newBullet = Instantiate(m_specialBullet, m_aim + transform.position + up, Quaternion.Euler(m_aim)) as GameObject;
            newBullet.GetComponent<Rigidbody>().velocity = m_aim * specialBulletSpeed;
            //newBullet.GetComponent<HomingMissile>().TimedDetonation(detonateTimer);

            shotCooldown = 0;            
        }
    }
}

