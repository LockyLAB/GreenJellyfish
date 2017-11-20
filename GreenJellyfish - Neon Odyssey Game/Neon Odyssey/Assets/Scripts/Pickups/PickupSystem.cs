using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSystem : MonoBehaviour {

    public List<GameObject> m_pickup;
    public List<float> m_pickupRates;

    //--------------------------------------------------------------------------------------
    // Create a pickup based of chance
    //
    // Param:
    //		caller: Object that is creating pickup
    //--------------------------------------------------------------------------------------
    public void GeneratePickup(GameObject caller)
    {
        //Get value between 0-99
        float rollVal = Random.Range(0.0f, 99.0f);
        int pickupNum = 0;
        float pickupRateTotal = 0;

        //Get pickup chance
        while (pickupNum < m_pickup.Count)
        {
            pickupRateTotal += m_pickupRates[pickupNum];
            if (pickupRateTotal > rollVal)//Create pickup at caller location
            {
                Instantiate(m_pickup[pickupNum], caller.gameObject.transform.position + Vector3.up, Quaternion.identity); // create pickup
                break;
            }
            pickupNum++;
        }

    }
}
