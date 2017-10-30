using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    protected virtual void ActivatePickup(GameObject other)
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null) // Picked up by player only
        {
            ActivatePickup(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
