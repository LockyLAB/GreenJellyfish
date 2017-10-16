using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScorpion : Enemy
{

    //Movement
    public float m_moveTowardsRange = 0.0f;

    //Gun
    public float m_gunFireDistance = 0.0f;
    public int m_gunNumberOfShots = 0;
    public float m_gunBulletSpeed = 0.0f;
    public float m_gunTimeBetweenShots = 0.0f;
    public float m_gunCooldown = 0.0f;

    public Vector3 m_leftClawPos = Vector3.zero;
    public Vector3 m_rightClawPos = Vector3.zero;

    public GameObject m_bulletPrefab = null;

    //Laser
    public float m_laserFireDistance = 0.0f;
    public float m_laserChargeTime = 0.0f;
    public float m_laserCooldown = 0.0f;

    public GameObject m_laserPrefab = null;

    //Nodes
    private BehaviourSequence m_sequenceTop;

    private BehaviourParallel m_firingParallel;

    private BehaviourSequence m_sequenceLeftGun;
    private BehaviourSequence m_sequenceRightGun;
    private BehaviourSequence m_sequenceLaser;

    private BehaviourBase m_actionGetTarget;

    //LeftClaw
    private BehaviourSelector m_selectorFiringLeftGun;
    private FireGun m_actionFireLeftGun;

    //RightClaw
    private BehaviourSelector m_selectorFiringRightGun;
    private FireGun m_actionFireRightGun;

    //Both Claws
    private IsTargetCloseEnough m_actionGetDisGun;
    private CoolDown m_actionGunCooldown;

    //Laser
    private IsTargetCloseEnough m_actionGetDisLaser;
    private FireLaserbeam m_actionFireLaser;
    private CoolDown m_actionLaserCooldown;

    // Use this for initialization
    void Awake()
    {
        m_sequenceTop = gameObject.AddComponent<BehaviourSequence>();

        m_firingParallel = gameObject.AddComponent<BehaviourParallel>();

        m_sequenceLeftGun = gameObject.AddComponent<BehaviourSequence>();
        m_sequenceRightGun = gameObject.AddComponent<BehaviourSequence>();
        m_sequenceLaser = gameObject.AddComponent<BehaviourSequence>();

        m_actionGetTarget = gameObject.AddComponent<BehaviourBase>();

        //LeftClaw
        m_selectorFiringLeftGun = gameObject.AddComponent<BehaviourSelector>();
        m_actionFireLeftGun = gameObject.AddComponent<FireGun>();

        //RightClaw
        m_selectorFiringRightGun = gameObject.AddComponent<BehaviourSelector>();
        m_actionFireRightGun = gameObject.AddComponent<FireGun>();

        //Both Claws
        m_actionGetDisGun = gameObject.AddComponent<IsTargetCloseEnough>();
        m_actionGunCooldown = gameObject.AddComponent<CoolDown>();

        //Laser
        m_actionGetDisLaser = gameObject.AddComponent<IsTargetCloseEnough>();
        m_actionFireLaser = gameObject.AddComponent<FireLaserbeam>();
        m_actionLaserCooldown = gameObject.AddComponent<CoolDown>();

        //Set up get target
        GameObject[] players;
        players = GameObject.FindGameObjectsWithTag("Player");

        if (players.Length == 1)
            m_actionGetTarget = gameObject.AddComponent<GetTargetSinglePlayer>();
        else
            m_actionGetTarget = gameObject.AddComponent<GetTargetEasy>();

        //Left gun
        m_actionGetDisGun.m_targetDistance = m_gunFireDistance;

        m_actionFireLeftGun.m_numberOfBullets = m_gunNumberOfShots;
        m_actionFireLeftGun.m_timeBetweenShots = m_gunTimeBetweenShots;
        m_actionFireLeftGun.m_bulletSpeed = m_gunBulletSpeed;
        m_actionFireLeftGun.m_bulletSpawnPos = m_leftClawPos;
        m_actionFireLeftGun.m_bullet = m_bulletPrefab;
        m_actionGunCooldown.m_coolDown = m_gunCooldown;


        //Right gun
        m_actionGetDisGun.m_targetDistance = m_gunFireDistance;
        m_actionFireRightGun.m_numberOfBullets = m_gunNumberOfShots;
        m_actionFireRightGun.m_timeBetweenShots = m_gunTimeBetweenShots;
        m_actionFireRightGun.m_bulletSpeed = m_gunBulletSpeed;
        m_actionFireRightGun.m_bulletSpawnPos = m_leftClawPos;
        m_actionFireRightGun.m_bullet = m_bulletPrefab;
        m_actionGunCooldown.m_coolDown = m_gunCooldown;

        //Laser
        m_actionGetDisLaser.m_targetDistance = m_laserFireDistance;
        m_actionFireLaser.m_chargeRate = m_laserChargeTime;
        m_actionLaserCooldown.m_coolDown = m_laserCooldown;

        m_actionFireLaser.m_laserbeam = m_laserPrefab;

        //Set up branches
        m_sequenceTop.m_behaviourBranches.Add(m_actionGetTarget as BehaviourBase);
        m_sequenceTop.m_behaviourBranches.Add(m_sequenceLeftGun);
        m_sequenceTop.m_behaviourBranches.Add(m_firingParallel);

        m_firingParallel.m_behaviourBranches.Add(m_sequenceLaser);
        m_firingParallel.m_behaviourBranches.Add(m_sequenceRightGun);

        //m_sequenceLeftGun.m_behaviourBranches.Add(m_selectorFiringGun);
        //m_sequenceLeftGun.m_behaviourBranches.Add(m_actionFireGun);
        //m_sequenceLeftGun.m_behaviourBranches.Add(m_actionGunCooldown);

        m_sequenceLaser.m_behaviourBranches.Add(m_actionGetDisLaser);
        m_sequenceLaser.m_behaviourBranches.Add(m_actionFireLaser);
        m_sequenceLaser.m_behaviourBranches.Add(m_actionLaserCooldown);

        m_initalBehaviour = m_sequenceTop;
    }
}
