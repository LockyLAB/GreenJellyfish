using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject m_pickupEffect = null;
    public Vector3 m_pickupSpawnPos = Vector3.up * 0.5f;

    public float m_pickupUpwardsVelocity = 10.0f;
    public float m_pickupUpwardsAngle = 30.0f;

    private void Awake()
    {
        GetComponent<Rigidbody>().velocity = Quaternion.Euler(0, 0, Random.Range(-m_pickupUpwardsAngle, m_pickupUpwardsAngle)) * transform.up * m_pickupUpwardsVelocity;
    }

    protected virtual void ActivatePickup(GameObject other)
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null) // Picked up by player only
        {
            ActivatePickup(other.gameObject);

            if(m_pickupEffect!= null)
                Destroy(Instantiate(m_pickupEffect, transform.TransformPoint(m_pickupSpawnPos), Quaternion.identity, other.transform), 5.0f); //Destroy after a time
            Destroy(this.gameObject);
        }
    }
}
