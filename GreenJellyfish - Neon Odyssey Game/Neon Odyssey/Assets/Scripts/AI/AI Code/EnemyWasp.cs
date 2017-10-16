using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWasp : Enemy {

    //Varibles
    //Movement
    public float m_moveTowardsRange = 0.0f;

    //Gun
    public float m_coneFireDistance = 0.0f;
    public int m_coneNumberOfBursts = 0;
    public float m_coneBulletSpeed = 0.0f;
    public float m_coneTimeBetweenShots = 0.0f;
    public float m_coneAngle = 0.0f;
    public float m_coneCooldown = 0.0f;
    public Vector3 m_bulletSpawnPos = Vector3.up * 0.5f;

    public GameObject m_bulletPrefab = null;

    //Fleeing
    public float m_fleeDistance = 0.0f;
    public float m_fleeMaxTime = 0.0f;

    //Nodes
    private BehaviourSequence m_sequenceTop;

    private BehaviourBase m_actionGetTarget;

    private BehaviourSelector m_selectorActions;

    private BehaviourSequence m_sequenceCone;
    private BehaviourSequence m_sequenceMove;

    private IsTargetCloseEnoughX m_actionGetDisCone;
    private FireCone m_actionFireCone;
    private FleeTarget m_actionFlee;
    private CoolDown m_actionConeCooldown;

    private IsTargetCloseEnoughX m_actionGetDisMovement;
    private MoveTowardsTargetFlying m_actionMovetowards;

    // Use this for initialization
    void Awake()
    {
        //Set up varibles
        m_sequenceTop = gameObject.AddComponent<BehaviourSequence>();

        m_selectorActions = gameObject.AddComponent<BehaviourSelector>();

        m_sequenceCone = gameObject.AddComponent<BehaviourSequence>();
        m_sequenceMove = gameObject.AddComponent<BehaviourSequence>();

        m_actionGetDisCone = gameObject.AddComponent<IsTargetCloseEnoughX>();
        m_actionFireCone = gameObject.AddComponent<FireCone>();
        m_actionFlee = gameObject.AddComponent<FleeTarget>();
        m_actionConeCooldown = gameObject.AddComponent<CoolDown>();

        m_actionGetDisMovement = gameObject.AddComponent<IsTargetCloseEnoughX>();
        m_actionMovetowards = gameObject.AddComponent<MoveTowardsTargetFlying>();

        //Set up get target
        GameObject[] players;
        players = GameObject.FindGameObjectsWithTag("Player");

        if (players.Length == 1)
            m_actionGetTarget = gameObject.AddComponent<GetTargetSinglePlayer>();
        else
            m_actionGetTarget = gameObject.AddComponent<GetTargetEasy>();

        //Cone
        m_actionGetDisCone.m_targetDistance = m_coneFireDistance;

        m_actionFireCone.m_numberOfBullets = m_coneNumberOfBursts;
        m_actionFireCone.m_timeBetweenShots = m_coneTimeBetweenShots;
        m_actionFireCone.m_bulletSpeed = m_coneBulletSpeed;
        m_actionFireCone.m_fireCone = m_coneAngle;
        m_actionFireCone.m_maxDis = m_coneFireDistance + 1;
        m_actionFireCone.m_bulletSpawnPos = m_bulletSpawnPos;

        m_actionFlee.m_fleeDistance = m_fleeDistance;
        m_actionFlee.m_maxFleeDuration = m_fleeMaxTime;

        m_actionConeCooldown.m_coolDown = m_coneCooldown;

        m_actionFireCone.m_bullet = m_bulletPrefab;

        //Movement
        m_actionGetDisMovement.m_targetDistance = m_moveTowardsRange;

        //Set up branches
        m_sequenceTop.m_behaviourBranches.Add(m_actionGetTarget as BehaviourBase);
        m_sequenceTop.m_behaviourBranches.Add(m_selectorActions);

        m_selectorActions.m_behaviourBranches.Add(m_sequenceCone);
        m_selectorActions.m_behaviourBranches.Add(m_sequenceMove);

        m_sequenceCone.m_behaviourBranches.Add(m_actionGetDisCone);
        m_sequenceCone.m_behaviourBranches.Add(m_actionFireCone);
        m_sequenceCone.m_behaviourBranches.Add(m_actionFlee);
        m_sequenceCone.m_behaviourBranches.Add(m_actionConeCooldown);

        m_sequenceMove.m_behaviourBranches.Add(m_actionGetDisMovement);
        m_sequenceMove.m_behaviourBranches.Add(m_actionMovetowards);

        m_initalBehaviour = m_sequenceTop;
    }
}
