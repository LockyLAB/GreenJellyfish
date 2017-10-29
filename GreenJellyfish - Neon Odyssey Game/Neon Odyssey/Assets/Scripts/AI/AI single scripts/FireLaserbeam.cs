using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLaserbeam : BehaviourBase
{

    public GameObject m_laserbeam;
    public GameObject m_laserbeamHolder;

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
        //Start numbers of bullets to fire
        m_time = m_chargeRate;

        //Fire bullet
        laserDir = (GetComponent<Enemy>().m_target.transform.position - transform.position);
        m_laserbeamHolder = Instantiate(m_laserbeam, transform.TransformPoint(m_laserSpawnPos), Quaternion.identity);
        m_laserbeamHolder.transform.LookAt(GetComponent<Enemy>().m_target.transform.position);
    }

    //--------------------------------------------------------------------------------------
    // Update behaviours - Cone Fire Towards target
    //
    // Return:
    //		Returns a enum BehaviourStatus, current status of behaviour, Success, failed, pending
    //--------------------------------------------------------------------------------------
    public override BehaviourBase.BehaviourStatus Execute()
    {
        m_time -= Time.deltaTime;

        if (m_time > 0.0f)
            return BehaviourStatus.PENDING;

        FireLaser(laserDir, laserDir.magnitude);

        //Reset all varibles
        return BehaviourStatus.SUCCESS;
    }

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
                    //!!!! UPDATE WHEN SINLGE ENTITIY CREATED!!!!!
                    hit.collider.GetComponent<Character>().ChangeHealth(-1);
                }
                else if (hit.collider.tag != this.tag)
                {
                    if(hit.collider.gameObject.layer != gameObject.layer)
                        hit.collider.GetComponent<Character>().ChangeHealth(-1);
                }
            }
           
        }
        Destroy(m_laserbeamHolder.gameObject);
    }
}
