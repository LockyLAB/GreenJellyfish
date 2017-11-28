using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---------------------------------------------------------
//-written by: Samuel
//-contributors:
//---------------------------------------------------------

public class FireLaserbeam : BehaviourBase
{

    public GameObject m_laserbeam = null;
    private GameObject m_laserbeamHolder = null;

    public bool m_laserFollowing = false;

    public float m_chargeRate = 0.0f;
    private float m_time = 0.0f;

    public bool m_laserFriendlyFire = false;

    private Vector3 laserDir = Vector3.zero;

    public Vector3 m_laserSpawnPos = Vector3.up * 0.5f;

    //--------------------------------------------------------------------------------------
    // Inital setup of behaviour, e.g. setting timer to 0.0f
    //--------------------------------------------------------------------------------------
    public override void BehaviourSetup()
    {
        gameObject.GetComponent<Animator>().SetTrigger("Laserbeam"); // Animation

        //Laser Effects
        laserDir = (GetComponent<Enemy>().m_target.transform.position - transform.position);

        if (m_laserbeamHolder != null)
            Destroy(m_laserbeamHolder);

        m_laserbeamHolder = Instantiate(m_laserbeam, transform.TransformPoint(m_laserSpawnPos), Quaternion.identity, gameObject.transform);
        m_laserbeamHolder.transform.LookAt(GetComponent<Enemy>().m_target.transform.position);

        //Laser Sound
        GetComponent<Enemy>().m_firingLaserAudio.GetComponent<AudioSource>().Play();

        m_time = 0.0f;
    }

    //--------------------------------------------------------------------------------------
    // Update behaviours - Fire laser beam towards player
    //
    // Return:
    //		Returns a enum BehaviourStatus, current status of behaviour, Success, failed, pending
    //--------------------------------------------------------------------------------------
    public override BehaviourBase.BehaviourStatus Execute()
    {
        m_time += Time.deltaTime;

        m_laserbeamHolder.transform.LookAt(GetComponent<Enemy>().m_target.transform.position); // Following laser

        if (m_time < m_chargeRate)
            return BehaviourStatus.PENDING;

        FireLaser(laserDir, laserDir.magnitude);

        return BehaviourStatus.SUCCESS;
    }

    //--------------------------------------------------------------------------------------
    // Fire a laser
    //
    // Param:
    //		laserDir: direction laser should travel
    //      laserMagnitude: how far to cast raycast
    //--------------------------------------------------------------------------------------
    void FireLaser(Vector3 laserDir, float laserMagnitude)
    {
        // Make ray cast to check if hit
        RaycastHit hit;

        if (Physics.Raycast(transform.position, laserDir, out hit, laserMagnitude))
        {
            if(GetComponent<Character>()!=null)
            {
                if (m_laserFriendlyFire)//Cases between frendly fire or not
                {
                    hit.collider.GetComponent<Character>().ChangeHealth(-1);
                }
                else if (hit.collider.tag != this.tag)
                {
                    if(hit.collider.gameObject.layer != gameObject.layer)
                        hit.collider.GetComponent<Character>().ChangeHealth(-1);
                }
            }
        }
    }
}
