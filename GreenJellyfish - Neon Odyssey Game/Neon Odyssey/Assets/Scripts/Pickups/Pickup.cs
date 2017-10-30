using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject m_pickupEffect = null;

    protected virtual void ActivatePickup(GameObject other)
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null) // Picked up by player only
        {
            ActivatePickup(other.gameObject);

            if(m_pickupEffect!= null)
                Instantiate(m_pickupEffect, transform.position, Quaternion.identity); // create pickup after effect
            Destroy(this.gameObject);
        }
    }
}
