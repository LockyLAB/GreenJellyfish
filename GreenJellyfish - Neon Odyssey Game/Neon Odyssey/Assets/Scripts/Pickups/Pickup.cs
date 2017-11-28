using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---------------------------------------------------------
//-written by: Samuel
//-contributors:
//---------------------------------------------------------

public class Pickup : MonoBehaviour
{
    public GameObject m_pickupEffect = null;
    public Vector3 m_pickupSpawnPos = Vector3.up * 0.5f;

    public float m_pickupUpwardsVelocity = 10.0f;
    public float m_pickupUpwardsAngle = 30.0f;

    //--------------------------------------------------------------------------------------
    // Fling pickup drop upwards
    //--------------------------------------------------------------------------------------
    private void Awake()
    {
        GetComponent<Rigidbody>().velocity = Quaternion.Euler(0, 0, Random.Range(-m_pickupUpwardsAngle, m_pickupUpwardsAngle)) * transform.up * m_pickupUpwardsVelocity;
    }

    //--------------------------------------------------------------------------------------
    // Action that pickup should do, example health adds health
    //
    // Param:
    //		other: Object that pickup has collided up
    //--------------------------------------------------------------------------------------
    protected virtual void ActivatePickup(GameObject other)
    {

    }

    //--------------------------------------------------------------------------------------
    // On trigger enter event 
    // on collision with player run the ActivatePickup function
    //
    // Param:
    //		other: Object that pickup has collided up
    //--------------------------------------------------------------------------------------
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null) // Picked up by player only
        {
            ActivatePickup(other.gameObject);

            if(m_pickupEffect!= null)
                Destroy(Instantiate(m_pickupEffect, other.transform.TransformPoint(m_pickupSpawnPos), Quaternion.identity, other.transform), 5.0f); //Destroy after a time
            Destroy(this.gameObject);
        }
    }
}
