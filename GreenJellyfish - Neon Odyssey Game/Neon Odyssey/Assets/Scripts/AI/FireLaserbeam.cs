using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLaserbeam : BehaviourBase
{

    public GameObject m_laserbeam;
    private GameObject m_laserbeamHolder;

    public float m_chargeRate = 0.0f;
    private float m_time = 0.0f;

    private Vector3 laserDir = Vector3.zero;

    private bool m_behaviourSetup = true;
    //--------------------------------------------------------------------------------------
    // Update behaviours - Cone Fire Towards target
    //
    // Return:
    //		Returns a enum BehaviourStatus, current status of behaviour, Success, failed, pending
    //--------------------------------------------------------------------------------------
    public override BehaviourBase.BehaviourStatus Execute()
    {
        Debug.Log("Firing Laser");

        if (m_behaviourSetup)
        {
            //Start numbers of bullets to fire
            m_time = m_chargeRate;
            m_behaviourSetup = false;

            //Fire bullet
            laserDir = (GetComponent<Enemy>().m_target.transform.position - transform.position);
            m_laserbeamHolder = Instantiate(m_laserbeam, this.transform.position + laserDir / 2, Quaternion.Euler(laserDir));
            Vector3 scale = new Vector3(laserDir.magnitude * 0.9f, 1, 1);
            m_laserbeamHolder.transform.localScale = scale;
        }

        m_time -= Time.deltaTime;

        if (m_time > 0.0f)
            return BehaviourStatus.PENDING;

        FireLaser(laserDir, laserDir.magnitude);

        //Reset all varibles
        m_behaviourSetup = true;
        return BehaviourStatus.SUCCESS;
    }

    void FireLaser(Vector3 laserDir, float laserMagnitude)
    {
        // Make ray cast to check if hit
        RaycastHit hit;

        if (Physics.Raycast(transform.position, laserDir, out hit, laserMagnitude))
        {
            if (hit.collider.tag == "Player")
                Debug.Log("player hit");
        }
        Destroy(m_laserbeamHolder);
    }
}
