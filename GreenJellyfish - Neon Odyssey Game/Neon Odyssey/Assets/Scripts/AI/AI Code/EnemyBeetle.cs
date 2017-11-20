using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeetle : Enemy
{
    //Movement
    public float m_moveTowardsRange = 0.0f;

    //Gun
    public float m_gunFireDistance = 0.0f;
    public int m_gunNumberOfShots = 0;
    public float m_gunBulletSpeed = 0.0f;
    public float m_gunTimeBetweenShots = 0.0f;
    public float m_gunCooldown = 0.0f;
    public Vector3 m_bulletSpawnPos = Vector3.up * 0.5f;

    public GameObject m_bulletPrefab = null;

    //Laser
    //public float m_laserFireDistance = 0.0f;
    //public float m_laserChargeTime = 0.0f;
    //public float m_laserCooldown = 0.0f;

    //public GameObject m_laserPrefab = null;

    //Nodes
    private BehaviourSequence m_sequenceTop;

    private BehaviourSelector m_selectorActions;

    //private BehaviourSequence m_sequenceLaser;
    private BehaviourSequence m_sequenceGun;
    private BehaviourSequence m_sequenceMove;

    private BehaviourBase m_actionGetTarget;

    //private IsTargetCloseEnough m_actionGetDisLaser;
    //private FireLaserbeam m_actionFireLaser;
    //private CoolDown m_actionLaserCooldown;

    private BehaviourSelector m_selectorFiringGun;
    private IsTargetCloseEnough m_actionGetDisGun;
    private InfrontOfLedge m_actionInfrontOfLedge;
    private FireGun m_actionFireGun;
    private CoolDown m_actionGunCooldown;

    private IsTargetCloseEnough m_actionGetDisMovement;
    private MoveTowardsTarget m_actionMovetowards;

    //-----------------------------------------------------
    // Setting up all AI behaviour components
    //
    // Move towards player, fire gun, repeat
    //-----------------------------------------------------
    void Start()
    {
        //Set health
        SetHealth(m_healthMax);

        //Set up varibles
        m_sequenceTop = gameObject.AddComponent<BehaviourSequence>();

        m_selectorActions = gameObject.AddComponent<BehaviourSelector>();

        //m_sequenceLaser = gameObject.AddComponent<BehaviourSequence>();
        m_sequenceGun = gameObject.AddComponent<BehaviourSequence>();
        m_sequenceMove = gameObject.AddComponent<BehaviourSequence>();

        //m_actionGetDisLaser = gameObject.AddComponent<IsTargetCloseEnough>();
        //m_actionFireLaser = gameObject.AddComponent<FireLaserbeam>();
        //m_actionLaserCooldown = gameObject.AddComponent<CoolDown>();

        m_selectorFiringGun = gameObject.AddComponent<BehaviourSelector>();

        m_actionGetDisGun = gameObject.AddComponent<IsTargetCloseEnough>();
        m_actionInfrontOfLedge = gameObject.AddComponent<InfrontOfLedge>();

        m_actionFireGun = gameObject.AddComponent<FireGun>();
        m_actionGunCooldown = gameObject.AddComponent<CoolDown>();

        m_actionGetDisMovement = gameObject.AddComponent<IsTargetCloseEnough>();
        m_actionMovetowards = gameObject.AddComponent<MoveTowardsTarget>();

        //Set up get target
        if (GameObject.FindWithTag("GameController").GetComponent<GameManager>().m_singlePlayer)
            m_actionGetTarget = gameObject.AddComponent<GetTargetSinglePlayer>();
        else
            m_actionGetTarget = gameObject.AddComponent<GetTargetEasy>();

        //Gun
        m_actionGetDisGun.m_targetDistance = m_gunFireDistance;
        m_actionFireGun.m_numberOfBullets = m_gunNumberOfShots;
        m_actionFireGun.m_timeBetweenShots = m_gunTimeBetweenShots;
        m_actionFireGun.m_bulletSpeed = m_gunBulletSpeed;
        m_actionFireGun.m_bulletSpawnPos = m_bulletSpawnPos;
        m_actionGunCooldown.m_coolDown = m_gunCooldown;

        m_actionFireGun.m_bullet = m_bulletPrefab;

        //Laser
        //m_actionGetDisLaser.m_targetDistance = m_laserFireDistance;
        //m_actionFireLaser.m_chargeRate = m_laserChargeTime;
        //m_actionLaserCooldown.m_coolDown = m_laserCooldown;

        //m_actionFireLaser.m_laserbeam = m_laserPrefab;

        //Movement
        m_actionGetDisMovement.m_targetDistance = m_moveTowardsRange;

        //Set up branches
        m_sequenceTop.m_behaviourBranches.Add(m_actionGetTarget as BehaviourBase);
        m_sequenceTop.m_behaviourBranches.Add(m_selectorActions);

        //m_selectorActions.m_behaviourBranches.Add(m_sequenceLaser);
        m_selectorActions.m_behaviourBranches.Add(m_sequenceGun);
        m_selectorActions.m_behaviourBranches.Add(m_sequenceMove);

        //m_sequenceLaser.m_behaviourBranches.Add(m_actionGetDisLaser);
        //m_sequenceLaser.m_behaviourBranches.Add(m_actionFireLaser);
        //m_sequenceLaser.m_behaviourBranches.Add(m_actionLaserCooldown);

        m_selectorFiringGun.m_behaviourBranches.Add(m_actionGetDisGun);
        m_selectorFiringGun.m_behaviourBranches.Add(m_actionInfrontOfLedge);

        m_sequenceGun.m_behaviourBranches.Add(m_selectorFiringGun);
        m_sequenceGun.m_behaviourBranches.Add(m_actionFireGun);
        m_sequenceGun.m_behaviourBranches.Add(m_actionGunCooldown);

        m_sequenceMove.m_behaviourBranches.Add(m_actionGetDisMovement);
        m_sequenceMove.m_behaviourBranches.Add(m_actionMovetowards);

        m_initalBehaviour = m_sequenceTop;
    }
}
